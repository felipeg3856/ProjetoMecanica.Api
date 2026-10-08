using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Api.Data;
using ProjetoMecanica.Api.Models;

namespace ProjetoMecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculo.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            _context.Veiculo.Add(veiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetVeiculos),
                new { id = veiculo.Id },
                veiculo
            );
        }

        [HttpPut]
        public async Task<IActionResult> PutVeiculo(int id, Veiculo veiculo)
        {
            var veiculoExistente = await _context.Veiculo.FindAsync(id);

            if (veiculoExistente == null)
            {
                return NotFound("Veículo não encontrado.");
            }
            veiculoExistente.ClienteId = veiculo.ClienteId;
            veiculoExistente.Marca = veiculo.Marca;
            veiculoExistente.Modelo = veiculo.Modelo;
            veiculoExistente.Placa = veiculo.Placa;

            await _context.SaveChangesAsync();

            return Ok(veiculoExistente);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound("Veículo não encontrado.");
            }

            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();

            return Ok("Veículo excluído com sucesso.");
        }
    }
}