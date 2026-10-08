using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProjetoMecanica.Api.Data;
using ProjetoMecanica.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoMecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamenController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamenController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamentos>>> GetAgendamento()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Agendamentos>> PostAgendamento(Agendamentos agendamentos)
        {
            _context.Agendamentos.Add(agendamentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAgendamento),
                new { id = agendamentos.Id },
                agendamentos
            );
        }

        [HttpPut]
        public async Task<IActionResult> PutAgendamento(int id, Agendamentos agendamentos)
        {
            var agendaExistente = await _context.Agendamentos.FindAsync(id);

            if (agendaExistente == null)
            {
                return NotFound("Agenda não encontrada.");
            }
            agendaExistente.Id = agendamentos.Id;
            agendaExistente.Data = agendamentos.Data;
            agendaExistente.servico = agendamentos.servico ;
            agendaExistente.VeiculoId = agendamentos.VeiculoId;

            await _context.SaveChangesAsync();

            return Ok(agendaExistente);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAgenda(int id)
        {
            var agenda = await _context.Agendamentos.FindAsync(id);

            if (agenda == null)
            {
                return NotFound("Agenda não encontrado.");
            }

            _context.Agendamentos.Remove(agenda);
            await _context.SaveChangesAsync();

            return Ok("Agendamento excluído com sucesso.");
        }
    }
}
