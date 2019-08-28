using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ProyectoWeb.Models;

namespace PruebaPFC.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "Cliente Id")]
        public int ClienteId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar un Nombre.")]
        [StringLength(100, ErrorMessage = "El {0} debe ser de al menos {2} caracteres y no debe sobrepasar los 100.", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(200, ErrorMessage = "La {0} debe ser debe ser menor de {1} caracteres.")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Debe ingresar un número de teléfono.")]
        [StringLength(9, ErrorMessage = "Debe ingresar un {0} válido.", MinimumLength = 9)]
        [DataType(DataType.PhoneNumber)]       
        public string Telefono { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}", NullDisplayText ="Prueba")]
        [DataType(DataType.DateTime)]
        public DateTime FechaNac { get; set; }

        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "El {0} debe ser debe ser menor de {1} caracteres.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Debe digitar un email válido.")]
        public string Email { get; set; }

        public List<Orden> ordenes { get; set; }
    }
}