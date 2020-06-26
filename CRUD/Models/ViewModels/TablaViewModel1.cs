using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModels
{
    public class TablaViewModel1
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }
    }
}