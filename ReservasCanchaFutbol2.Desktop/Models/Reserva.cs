using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasCanchaFutbol2.Desktop.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int CanchaId { get; set; }
        public DateTime FechaHora { get; set; }
        public int DuracionHoras { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }

}
