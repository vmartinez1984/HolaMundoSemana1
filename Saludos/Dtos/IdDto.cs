namespace Saludos.Dtos
{
    public class IdDto
    {
        public string Id { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
