using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicios.Models
{
    public class Orden
    {
        [Key]
        [Display(Name = "Orden Id")]
        public int OrdenId { get; set; }

        [Display(Name = "Fecha Orden")]
        [DataType(DataType.Date)]
        public DateTime FechaOrden { get; set; }

        [Display(Name = "Tipo Pago")]
        public string TipoPago { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Entregada")]
        public bool Entregada { get; set; }

        [Display(Name = "Cliente Id")]
        public int ClienteId { get; set; }
    }
}