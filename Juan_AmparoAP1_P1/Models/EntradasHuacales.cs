using System.ComponentModel.DataAnnotations;
using Juan_AmparoAP1_P1.DAL;
namespace Juan_AmparoAP1_P1.Models 
{
    public class EntradasHuacales
    {
        [Key]
        public int idEntrada{ get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El Nombre del cliente debe ser obligatorio")]
        public string? NombreCliente { get; set; }

        [Required(ErrorMessage = "La Cantidad es obligatoria")]
        public double Cantidad { get; set; }

        [Required(ErrorMessage = "El Precio es Obligatorio")]
        public double Precio { get; set; }
    }
}



