namespace ReservasCanchaFutbol.API.Services;
using ReservasCanchaFutbol2.API.Interfaces;
using ReservasCanchaFutbol2.API.Models;

public class ReservaService : IReservaService
{
    private readonly IReservaRepository _reservaRepo;
    private readonly ICanchaRepository _canchaRepo;
    private readonly IClienteRepository _clienteRepo;

    //inyeccion de las dependencias, le doy a la clase los objetos que necesita
    public ReservaService(IReservaRepository reservaRepo, ICanchaRepository canchaRepo, IClienteRepository clienteRepo)
    {
        _reservaRepo = reservaRepo;
        _canchaRepo = canchaRepo;
        _clienteRepo = clienteRepo;
    }

    public IEnumerable<Reserva> ObtenerTodas()
    {
        return _reservaRepo.ObtenerTodas();
    }
    //creo una reserva recibiendo datos necesarios
    public Reserva Crear(int canchaId, int clienteId, DateTime fechaHora, int duracionHoras)
    {
        // Valido que la cancha exista
        var cancha = _canchaRepo.ObtenerPorId(canchaId);
        if (cancha == null)
            throw new ArgumentException($"No existe la cancha con id {canchaId}");

        // Validar que el cliente exista
        var cliente = _clienteRepo.ObtenerPorId(clienteId);
        if (cliente == null)
            throw new ArgumentException($"No existe el cliente con id {clienteId}");

        // Validar que la cancha esté libre en el horario solicitado
        var reservas = _reservaRepo.ObtenerTodas()
            .Where(r => r.CanchaId == canchaId); //filtro las reservas para quedarme con las q pertenecen a la misma cancha

        bool estaOcupada = reservas.Any(r =>
            (fechaHora < r.FechaHora.AddHours(r.DuracionHoras)) &&
            (fechaHora.AddHours(duracionHoras) > r.FechaHora) //si la nueva reserva empieza antes q termine otra y termina despues q empiece otra, esta ocupada
        );

        if (estaOcupada)
            throw new InvalidOperationException("La cancha no esta disoponible en el horario solicitado.");

        // Crear la reserva
        var reserva = new Reserva
        {
            CanchaId = canchaId,
            ClienteId = clienteId,
            FechaHora = fechaHora,
            DuracionHoras = duracionHoras
        };

        _reservaRepo.Crear(reserva);

        return reserva;
    }
}

