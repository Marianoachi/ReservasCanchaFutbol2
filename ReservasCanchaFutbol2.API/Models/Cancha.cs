namespace ReservasCanchaFutbol2.API.Models;
public class Cancha
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty; // ej futbol 5 futbol 7
    public decimal PrecioPorHora { get; set; }
    //public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
