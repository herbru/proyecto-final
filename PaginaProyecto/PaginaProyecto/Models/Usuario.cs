using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace PaginaProyecto.Models
{
    public class Usuario
    {
        //declaro conexion

        private MySqlConnection Conexiondb = new MySqlConnection("server=localhost; Uid=root; Password=Proyecto; Database=dbProyecto; Port=3306");

        //propiedades de la clase
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(60, ErrorMessage = "El nombre debe tener menos de 60 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(60, ErrorMessage = "El apellido debe tener menos de 60 caracteres")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Direccion de Email invalida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Contraseña")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "La contraseña debe tener un minimo de 8 caracteres")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contraseña", ErrorMessage = "La contraseña y la confirmacion no son iguales")]
        public string ConfirmarContraseña { get; set; }

        public HttpPostedFileBase Imagen { get; set; }

        //metodos publicos

        //Agrega el usuario que ejecuta el metodo a la base de datos
        public void InsertarUsuario()
        {
            //abro conexion y declaro una transaccion
            Conexiondb.Open();
            MySqlTransaction transaccion = Conexiondb.BeginTransaction();
            try
            {
                // asigno el nombre de la consulta a el nombre de consulta que tengo guardado en la DB
                MySqlCommand Comando = new MySqlCommand("InsertarUsuario", Conexiondb, transaccion);
                Comando.CommandType = CommandType.StoredProcedure;

                //agrego los parametros
                Comando.Parameters.AddWithValue("PNombre", this.Nombre);
                Comando.Parameters.AddWithValue("PApellido", this.Apellido);
                Comando.Parameters.AddWithValue("PEmail", this.Email);
                Comando.Parameters.AddWithValue("PContrasena", this.Contraseña);

                //ejecuto la consulta que no devuelve nada
                Comando.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch (Exception)
            {
                try
                {
                    //pruebo la ejecucion de la consulta otra vez
                    transaccion.Rollback();
                }
                catch (Exception ex2)
                {
                    //este bloque de codigo va a manejar cualquier error que pudieran 
                    //ocurrir en el servidor que pudieran causar la falla del reintento,
                    //como por ejemplo una conexion cerrada.
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }
            Conexiondb.Close();
        }

        //devuelve un Usuario si el mail y la contraseña(parametros) coinciden con un mail y una contraseña de un registro en la DB
        public void LoguearUsuario()
        {
            //abro conexion y declaro una transaccion
            Conexiondb.Open();
            MySqlTransaction transaccion = Conexiondb.BeginTransaction();
            try
            {
                // asigno el nombre de la consulta a el nombre de consulta que tengo guardado en la DB
                MySqlCommand Comando = new MySqlCommand("LoguearUsuario", Conexiondb, transaccion);
                Comando.CommandType = CommandType.StoredProcedure;

                //agrego los parametros
                Comando.Parameters.AddWithValue("PEmail", this.Email);
                Comando.Parameters.AddWithValue("PContrasena", this.Contraseña);

                //ejecuto la consulta y obtengo un iterable con registros
                MySqlDataReader dr = Comando.ExecuteReader();
                transaccion.Commit();

                while (dr.Read())
                {
                    if (Email == dr["Email"].ToString() && Contraseña == dr["Contrasena"].ToString())
                    {
                        this.Nombre = dr["Nombre"].ToString();
                        this.Apellido = dr["Apellido"].ToString();
                        this.Email = dr["Email"].ToString();
                        this.Contraseña = dr["Contrasena"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    //pruebo la ejecucion de la consulta otra vez
                    transaccion.Rollback();
                }
                catch (Exception ex2)
                {
                    //este bloque de codigo va a manejar cualquier error que pudieran 
                    //ocurrir en el servidor que pudieran causar la falla del reintento,
                    //como por ejemplo una conexion cerrada.
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }
            Conexiondb.Close();
        }
    }
}