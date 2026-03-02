using System.ComponentModel.DataAnnotations;

namespace Juan_AmparoAP1_P1.Models
{
    public class EntradasHuacalesDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int EntradaId { get; set; }

        [Required(ErrorMessage = "El tipo de huacal es obligatorio")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public int Precio { get; set; }
    }
}