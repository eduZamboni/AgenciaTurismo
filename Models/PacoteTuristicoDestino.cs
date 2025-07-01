namespace AgenciaTurismo.Models
{
    public class PacoteTuristicoDestino
    {
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; } = new PacoteTuristico();

        public int DestinoId { get; set; }
        public Destino Destino { get; set; } = new Destino();


    }
}
