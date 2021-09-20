using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiDesadio2.Entidades;

namespace webApiDesadio2.Controllers 
{

    [Route("api/")]
    [ApiController]

 public class LoginController : ControllerBase 
    {
        private static List<Cuenta> log = new List<Cuenta> 
        {
            new Cuenta
            {
                Usuario= "no",
                Password= "NO"
            }
        };
        private readonly ApplicationDbContext context;
        public LoginController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Login>>> Get()
        {
            return await context.Logins.ToListAsync();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Post(Cuenta cuenta)
        {
           
            var siExisteUsuario = log.Find(item => item.Usuario == cuenta.Usuario && item.Password == cuenta.Password);
            if(siExisteUsuario == null)
            {
                var res = new Login 
                {
                    Usuario = cuenta.Usuario,
                    Fecha = DateTime.Now,
                    Resultado = "ERROR"
                };
                context.Add(res);
                await context.SaveChangesAsync();
                return BadRequest("ERROR");
            }
            else
            {
                var res = new Login 
                {
                    Usuario = cuenta.Usuario,
                    Fecha = DateTime.Now,
                    Resultado = "CORRECTO"
                };
                context.Add(res);
                await context.SaveChangesAsync();
                return Ok("CORRECTO");
            }

        }
    }
}