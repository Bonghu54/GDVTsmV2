using System.ComponentModel.DataAnnotations;

namespace GDVTsmV3.Models
{
    public class Producto
    {
        [Key]
        public int Id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Descripcion { get; set; }
        public string Unidad_De_Venta { get; set; }
        public string Tipo_Producto { get; set; }
        public decimal Precio_Unitario { get; set; }
        public int Cantidad_En_Stock { get; set; }
        public ICollection<Detalle_Producto> Detalles_Producto { get; set; }

    }
}
