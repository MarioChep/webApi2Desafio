using System.ComponentModel.DataAnnotations;

namespace webApiDesadio2.Entidades{
    public class Cuenta
    {
        [Key]
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        
    }
}