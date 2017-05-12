using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data.OleDb;

namespace PaginaProyecto.Models
{
    public class Usuario
    {
        //declaro conexion

        private MySqlConnection Conexiondb = new MySqlConnection("server=localhost; Uid=root; Password=Proyecto; Database=proyectodb; Port=3306");
        

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

        private OleDbCommand Consulta;
        private OleDbConnection Conexion;
        private void Abrirconexion()
        {
            string Proveedor = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|DbProyecto.mdb";
            Conexion = new OleDbConnection();
            Conexion.ConnectionString = Proveedor;
            Conexion.Open();
            Consulta = Conexion.CreateCommand();
        }

        //metodos publicos

        //Agrega el usuario que ejecuta el metodo a la base de datos
        public void InsertarUsuario()
        {
            //abro conexion y declaro una transaccion
            Abrirconexion();
            try
            {
                // asigno el nombre de la consulta a el nombre de consulta que tengo guardado en la DB
                Consulta.CommandType = CommandType.StoredProcedure;
                Consulta.CommandText = "InsertarUsuario";
                //Agrego los parametros
                Consulta.Parameters.Add(new OleDbParameter("pNombre", this.Nombre));
                Consulta.Parameters.Add(new OleDbParameter("pEmail", this.Email));
                Consulta.Parameters.Add(new OleDbParameter("pApellido",this.Apellido));
                Consulta.Parameters.Add(new OleDbParameter("pContraseña",this.Contraseña));

                //ejecuto la consulta que no devuelve nada
                Consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                  //este bloque de codigo va a manejar cualquier error que pudiera 
                  //ocurrir en el servidor que pudieran causar la falla del reintento,
                  //como por ejemplo una conexion cerrada.
                  Console.WriteLine("Exception Type: {0}", ex.GetType());
                  Console.WriteLine("  Message: {0}", ex.Message);
            }
            Conexion.Close();
        }

        //devuelve un Usuario si el mail y la contraseña(parametros) coinciden con un mail y una contraseña de un registro en la DB
        public Usuario LoguearUsuario(Usuario oUsuario)
        {
            Usuario retUsuario = new Usuario();
            //abro conexion y declaro una transaccion
            Abrirconexion();
            try
            {
                // asigno el nombre de la consulta a el nombre de consulta que tengo guardado en la DBConsulta.CommandType = CommandType.StoredProcedure;
                Consulta.CommandType = CommandType.StoredProcedure;
                Consulta.CommandText = "LoguearUsuario";
                //Agrego los parametros
                Consulta.Parameters.Add(new OleDbParameter("pEmail", oUsuario.Email));
                Consulta.Parameters.Add(new OleDbParameter("pContraseña", oUsuario.Contraseña));

                //ejecuto la consulta y obtengo un iterable con registros
                OleDbDataReader dr = Consulta.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        retUsuario.Nombre = dr["Nombre"].ToString();
                        retUsuario.Apellido = dr["Apellido"].ToString();
                        retUsuario.Email = dr["Email"].ToString();
                        retUsuario.Contraseña = dr["Contraseña"].ToString();
                    }
                    else
                    {
                        return retUsuario;
                    }
            }
            catch (Exception ex2)
            {
                {
                    //este bloque de codigo va a manejar cualquier error que pudieran 
                    //ocurrir en el servidor que pudieran causar la falla del reintento,
                    //como por ejemplo una conexion cerrada.
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }
            Conexion.Close();
            return retUsuario;
        }
    }
}