using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoReactnetCore.Models
{
    public class Compras
    {
        [Key]
        public int IdCompra { get; set; }
        [Required]
        public string Producto { get; set; }
        public int Cantidad { get; set; }
     
        public int FK_Turismo { get; set; }

       
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public UserTurismo UserTurismo { get; set; }

    }
}
