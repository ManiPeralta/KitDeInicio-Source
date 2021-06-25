using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kitDeInicioDos.ModelsView
{
    public class ContactModel
    {
        [Required(ErrorMessage = "El campo 'Nombre' es requerido")]
        [MaxLength(80, ErrorMessage = "Nombre debe tener menos de 80 carácteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo 'Email' es requerido")]
        [MaxLength(100, ErrorMessage = "Email debe tener menos de 100 carácteres")]
        [EmailAddress(ErrorMessage = "Provea un email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo 'Tema' es requerido")]
        [MaxLength(150, ErrorMessage = "El Tema debe tener menos de 150 carácteres")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "El campo 'Mensaje' es requerido")]
        [MaxLength(500, ErrorMessage = "Mensaje debe tener menos de 500 carácteres")]
        public string Mensaje { get; set; }

        public string RecaptchaSiteKey { get; set; }
    }
}