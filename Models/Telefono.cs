namespace NT1_2023_2C_D.Models
{
    public class Telefono
    {        
        public int Id { get; set; }
        public CodigoDeAreaEnum CodArea { get; set; }
        public int Numero { get; set; }

        public bool Principal { get; set; }
        public TipoTelefonoEnum Tipo { get; set; }
        public Persona Persona { get; set; }

        public int PersonaId { get; set; }

    }
}
