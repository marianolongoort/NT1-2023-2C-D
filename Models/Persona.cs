﻿using Microsoft.AspNetCore.Identity;
using NT1_2023_2C_D.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NT1_2023_2C_D.Models
{
    public class Persona : IdentityUser<int>
    {        
        //public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.ReqMsg)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = ErrorMessages.StringMinMax)]
        public string Nombre { get; set; } = "ND";

        [Required(ErrorMessage = ErrorMessages.ReqMsg)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessages.StringMinMax)]
        public string Apellido { get; set; } = "ND";


        [Range(10000000,99999999,ErrorMessage = ErrorMessages.Range)]
        [Display(Name = "Documento")]
        public int DNI { get; set; }

        public List<Telefono> Telefonos { get; set; } 

        [Required(ErrorMessage = ErrorMessages.ReqMsg)]
        [Display(Name ="Imagen")]
        public string Foto { get; set; } = "default.png";

        [NotMapped]
        public string NombreCompleto { 
            get {
                return $"{Apellido}, {Nombre}";
            }
        }
    }
}
