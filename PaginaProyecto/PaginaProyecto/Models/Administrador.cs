using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace PaginaProyecto.Models
{
    public class Administrador
    {
        public int AdminstradorID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Este campo solo puede contener letras, guiones o espacios")]
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(60, ErrorMessage = "El nombre debe tener menos de 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [EmailAddress(ErrorMessage = "Direccion de Email invalida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "La contraseña debe tener un minimo de 8 caracteres y un maximo de 40")]
        [DataType(DataType.Password, ErrorMessage = "Debe ingresar una contraseña")]
        public string Contraseña { get; set; }

        public HttpPostedFileBase Imagen { get; set; }
    }
}