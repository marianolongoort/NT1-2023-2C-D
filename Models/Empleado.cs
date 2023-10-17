using System.ComponentModel.DataAnnotations;

namespace NT1_2023_2C_D.Models
{
    public class Empleado : Persona
    {
        [Required]
        public string CodigoEmpleado { get; set; }
    }
}
