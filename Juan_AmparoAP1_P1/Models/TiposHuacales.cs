using System.ComponentModel.DataAnnotations;

namespace Juan_AmparoAP1_P1.Models
{
    public class TiposHuacales
    {
        [Key]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string? Descripcion { get; set; }

        public int Existencia { get; set; }
    }
}