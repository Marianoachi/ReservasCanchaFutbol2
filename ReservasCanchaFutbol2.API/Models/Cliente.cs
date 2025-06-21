using System.ComponentModel.DataAnnotations;

namespace ReservasCanchaFutbol2.API.Data.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Email { get; set; }

        [Phone]
        public string Telefono { get; set; }
    }
}

