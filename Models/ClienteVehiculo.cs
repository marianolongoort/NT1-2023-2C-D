using System.ComponentModel.DataAnnotations;

namespace NT1_2023_2C_D.Models
{
    public class ClienteVehiculo
    {
        [Key]
        public int ClienteId { get; set; }

        [Key]
        public int VehiculoId { get; set; }

        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }

    }
}