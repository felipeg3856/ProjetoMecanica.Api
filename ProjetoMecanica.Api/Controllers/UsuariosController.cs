using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMecanica.Api.Data;
using ProjetoMecanica.Api.Models;

namespace ProjetoMecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        { 
        _context = context;
        }
        
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            var user = _context.Mecanico.FirstOrDefault(u => u.username == usuario.username && u.Senha == usuario.Senha);

            if (user == null)
            {
                return Unauthorized("Credenciais invalidas!");
            }

            return Ok(new {Nome = user.Nome});
               
        }
    }
}
