using GDVTsmV3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDVTsmV3.Models
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }
        [ForeignKey("Persona")]
        public int Id_Persona { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaHora_de_registro { get; set; }
        public string Tipo_Cliente { get; set; }
    }
}
