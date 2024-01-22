using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }
        
       
        public string Nom_Usuario { get; set; }

        
        public string Pass_Usuario { get; set; }

        public int Estado_Usuario { get; set; }
    }
}
