namespace PuntoDeVenta.Core.Dtos
{
    public class IdDto
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
