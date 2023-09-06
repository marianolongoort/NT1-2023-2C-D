namespace NT1_2023_2C_D.Models
{
    public class Telefono
    {        
        public int Id { get; set; }
        public CodigoDeArea CodArea { get; set; }
        public int Numero { get; set; }

        public bool Principal { get; set; }
        public TipoTelefono Tipo { get; set; }
        public Persona Persona { get; set; }

        public int PersonaId { get; set; }

    }
}
