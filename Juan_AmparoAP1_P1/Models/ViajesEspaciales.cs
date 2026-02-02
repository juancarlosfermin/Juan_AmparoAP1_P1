using System.ComponentModel.DataAnnotations;

namespace Juan_AmparoAP1_P1.Models
{
    public class ViajesEspaciales
    {
        [Key]
        public int ViajeId { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El costo es obligatorio")]
        [Range(0.01, 10000000, ErrorMessage = "El costo debe ser mayor a 0")]
        public double Costo { get; set; }
    }
}