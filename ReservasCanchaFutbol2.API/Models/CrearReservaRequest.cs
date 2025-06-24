namespace ReservasCanchaFutbol2.API.Models
{
    public class CrearReservaRequest
    {
        public int CanchaId { get; set; }
        public DateTime FechaHora { get; set; }
        public int DuracionHoras { get; set; }
        public int UsuarioId { get; set; }
    }
}
