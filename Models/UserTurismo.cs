using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurismoReactnetCore.Models
{
    public class UserTurismo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int Lanzamiento { get; set; }
        [Required]
        public string Propietario { get; set; }
        [Required]
        public string Desarrollador { get; set; }
        public List<Compras> Compras { get; set; }
        
        
    }
}
