using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasCanchaFutbol2.Desktop.Models
{
    public class CrearReservaRequest
    {
        public int CanchaId { get; set; }
        public DateTime FechaHora { get; set; }
        public int DuracionHoras { get; set; }
        public int UsuarioId { get; set; }
    }

}
