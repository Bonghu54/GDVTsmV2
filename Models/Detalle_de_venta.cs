using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDVTsmV3.Models
{
    public class Detalle_de_venta
    {
        [Key]
        public int Id_Detalle { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Producto { get; set; }
        [ForeignKey("Venta")]
        public int Id_Venta { get; set; }
        public Venta Venta { get; set; }

        [ForeignKey("Producto")]
        public int Id_Producto { get; set; }
        public Producto Producto { get; set; }
    }
}
