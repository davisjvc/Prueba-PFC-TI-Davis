using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicios.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "Cliente Id")]
        public int ClienteId { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNac { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        public List<Orden> ordenes { get; set; }
    }
}