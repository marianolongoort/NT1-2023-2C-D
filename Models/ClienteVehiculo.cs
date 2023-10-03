using System.ComponentModel.DataAnnotations;

namespace NT1_2023_2C_D.Models
{
    public class ClienteVehiculo
    {
        [Key]
        [Display(Name ="Cliente")]
        public int ClienteId { get; set; }

        [Key]
        [Display(Name = "Vehiculo")]
        public int VehiculoId { get; set; }

        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }

    }
}