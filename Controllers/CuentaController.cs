using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiDesadio2.Entidades;

namespace webApiDesadio2.Controllers 
{

    [Route("")]
    [ApiController]
    public class CuentaController : ControllerBase 
    {
        private static List<Cuenta> cuen = new List<Cuenta> 
        {
            new Cuenta
            {
                Usuario= "Error Existe"
            }
        };
        private readonly ApplicationDbContext context;
        public CuentaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("api/lista")]
        public async Task<ActionResult<List<Cuenta>>> Get()
        {
            return await context.Cuentas.ToListAsync();
        }

        [HttpGet("api/data/{usuario}")]
        public async Task<IActionResult> Get(string usuario)
        {
            var cRep = await context.Cuentas.FindAsync(usuario);
           

            if(cRep == null)
            {
                return BadRequest("ERROR");
            }
            else
            {
                var res = new CuentaDTO 
                {
                    Apellido = cRep.Apellido,
                    Email = cRep.Email,
                    Nombre = cRep.Nombre
                };
                return Ok(res);
            }
            
        }

        [HttpPost("api/register")]
        public async Task<ActionResult> Post(Cuenta cuenta)
        {
            var siExiste = cuen.Find(item =>item.Usuario.Equals(cuenta.Usuario, StringComparison.InvariantCultureIgnoreCase));
            if(siExiste == null)
            {
                return BadRequest("ERROR");
            }
            else
            {
                context.Add(cuenta);
                await context.SaveChangesAsync();
                return Ok("CORRECTO");  
            }

        }
    }
    

}