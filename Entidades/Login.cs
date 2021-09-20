using System;
using System.ComponentModel.DataAnnotations;

namespace webApiDesadio2.Entidades{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
        
    }
}