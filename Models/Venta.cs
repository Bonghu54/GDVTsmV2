using System.ComponentModel.DataAnnotations;

namespace GDVTsmV3.Models
{
    public class Venta
    {
        [Key]
        public int Id_Venta { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaHora_Venta { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaHora_Entrega { get; set; }
        public string Estado_Seguimiento { get; set; }
        public decimal Total_Venta { get; set; }

        public ICollection<Detalle_de_venta> Detalles_de_venta { get; set; }
    }
}
