using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Api.Data;
using ProjetoMecanica.Api.Models;

namespace ProjetoMecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
                       return Ok("Cliente Cadastrado com sucesso");
        }
        [HttpPut]
        public async Task<ActionResult<Cliente>> AlterarCliente(int id, Cliente cliente)
        {
            var clienteAtual = await _context.Cliente.FindAsync(id);
            if (clienteAtual == null)
            {
                return NotFound();
            }
            clienteAtual.CPF = cliente.CPF;
            clienteAtual.Nome = cliente.Nome;
            clienteAtual.Telefone = cliente.Telefone;
            clienteAtual.CPF = cliente.CPF;

            await _context.SaveChangesAsync();

            return Ok("Cliente Alterado com sucesso");
        }   
        [HttpDelete]    
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente Deletado com sucesso");
        }
    }
}

