using ReservasCanchaFutbol2.API.Models;
public class Reserva
{
    public int Id { get; set; }
    public int CanchaId { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaHora { get; set; }
    public int DuracionHoras { get; set; }

    public Cancha? Cancha { get; set; }
    public Cliente? Cliente { get; set; }
}

