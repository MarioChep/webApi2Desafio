using Microsoft.EntityFrameworkCore;
using webApiDesadio2.Entidades;

namespace webApiDesadio2{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Cuenta> Cuentas {get;set;}
        public DbSet<Login> Logins {get;set;}
    }
}