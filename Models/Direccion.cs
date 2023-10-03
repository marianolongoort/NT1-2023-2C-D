using System.ComponentModel.DataAnnotations;

namespace NT1_2023_2C_D.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public string Departamento { get; set; }
        [Display(Name ="Código postal")]
        public string CodigoPostal { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
    }
}
