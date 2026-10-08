using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Api.Data;
using ProjetoMecanica.Api.Models;

namespace ProjetoMecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamentos>>> GetAgendamento()
        {
            return await _context.Agendamentos.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Agendamentos>> PostCliente(Agendamentos agendamentos)
        {
            _context.Agendamentos.Add(agendamentos);
            await _context.SaveChangesAsync();
            return Ok("Cliente Cadastrado com sucesso");
        }
        [HttpPut]
        public async Task<ActionResult<Cliente>> AlterarCliente(int id, Agendamentos agendamentos)
        {
            var clienteAtual = await _context.Cliente.FindAsync(id);
            if (clienteAtual == null)
            {
                return NotFound();
            }
            agendamentoAtual.DataAgendamento = agendamentos.DataAgendamento;
            agendamentoAtual.servico = agendamentos.servico;

            await _context.SaveChangesAsync();

            return Ok("Cliente Alterado com sucesso");
        }
        [HttpDelete]
        public async Task<ActionResult<Agendamentos>> DeleteAgendamento(int id)
        {
            var agendamentos = await _context.Agendamentos.FindAsync(id);
            if (agendamentos == null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(agendamentos);
            await _context.SaveChangesAsync();

            return Ok("Cliente Deletado com sucesso");
        }
    }
}
}
