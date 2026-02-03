using System.ComponentModel.DataAnnotations;
using Juan_AmparoAP1_P1.DAL;
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
        public double Costo { get; set; }
    }
}