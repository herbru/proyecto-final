using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace proyecto_final_asp.Models
{
    public class Usuario
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre debe tener mas de 3 y menos de 60 caracteres")]
        public string Nombre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El apellido debe tener mas de 3 y menos de 60 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "La direccion de Email no es valida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacio")]
        [StringLength(40, MinimumLength = 8)]
        [DataType(DataType.EmailAddress, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string Contraseña { get; set; }

        public HttpPostedFileBase Imagen { get; set; }

        private decimal PlataDonada { get; set; }

        private int ProyectosDonados { get; set; } 

    }

}