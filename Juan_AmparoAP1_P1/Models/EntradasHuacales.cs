using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juan_AmparoAP1_P1.Models
{
    public class EntradasHuacales
    {
        [Key]
        public int idEntrada { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El Nombre del cliente debe ser obligatorio")]
        public string? NombreCliente { get; set; }

        [ForeignKey("EntradaId")]
        public ICollection<EntradasHuacalesDetalle> EntradasDetalle { get; set; } = new List<EntradasHuacalesDetalle>();
    }
}