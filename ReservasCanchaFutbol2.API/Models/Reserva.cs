using ReservasCanchaFutbol2.API.Models;

public class Reserva
{
    public int Id { get; set; }
    public int CanchaId { get; set; }

    // nuevo campo para el nombre de quien reserva

    public DateTime FechaHora { get; set; }
    public int DuracionHoras { get; set; }

    public Cancha? Cancha { get; set; }
    public int UsuarioId { get; set; }
}

