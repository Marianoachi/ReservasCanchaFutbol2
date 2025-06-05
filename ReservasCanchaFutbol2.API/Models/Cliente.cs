namespace ReservasCanchaFutbol2.API.Models;
public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}

