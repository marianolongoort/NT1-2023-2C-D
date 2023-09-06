namespace NT1_2023_2C_D.Models
{
    public class Cliente : Persona
    {
        public long CUIT { get; set; }

        public Direccion Direccion { get; set; }

        public List<Estancia> Estancias { get; set; }

        public List<ClienteVehiculo> ClientesVehiculos { get; set; }
    }
}
