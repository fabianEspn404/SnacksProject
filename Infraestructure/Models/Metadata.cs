using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
    

    internal partial class UsuarioMetadata
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Username { get; set; }
        [Display(Name = "Clave")]
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Clave { get; set; }
    }
}
