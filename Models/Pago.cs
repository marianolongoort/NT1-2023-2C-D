using System.ComponentModel.DataAnnotations.Schema;

namespace NT1_2023_2C_D.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public Estancia Estancia { get; set; }

        public int EstanciaId { get; set; }

        public decimal Monto { get; set; }
    }
}
