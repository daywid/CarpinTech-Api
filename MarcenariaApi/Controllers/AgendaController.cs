using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarcenariaApi.Data;
using MarcenariaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarcenariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly MarcenariaDbContext _context;

        public AgendaController(MarcenariaDbContext context)
        {
            _context = context;
        }

        // GET: api/Agenda
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Agenda>>> GetAgendas()
        {
            return await _context.Agendas.ToListAsync();
        }

        // GET: api/Agenda/5
        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Agenda>> GetAgenda(int id)
        {
            var agenda = await _context.Agendas.FindAsync(id);

            if (agenda == null)
            {
                return NotFound();
            }

            return agenda;
        }

        // POST: api/Agenda
        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult<Agenda>> PostAgenda(Agenda agenda)
        {
            // Verificar se o FuncionarioId existe na tabela Funcionario
            if (!_context.Funcionarios.Any(f => f.Id == agenda.FuncionarioId))
            {
                return BadRequest("O FuncionarioId especificado não existe na tabela Funcionario.");
            }

            _context.Agendas.Add(agenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgenda", new { id = agenda.Id }, agenda);
        }

        // PUT: api/Agenda/5
        [HttpPut()]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> PutAgenda(int id, Agenda agenda)
        {
            if (id != agenda.Id)
            {
                return BadRequest();
            }

            // Verificar se o FuncionarioId existe na tabela Funcionario
            if (!_context.Funcionarios.Any(f => f.Id == agenda.FuncionarioId))
            {
                return BadRequest("O FuncionarioId especificado não existe na tabela Funcionario.");
            }

            _context.Entry(agenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Agenda/5
        [HttpDelete()]
        [Route("deletar/{id}")]
        public async Task<IActionResult> DeleteAgenda(int id)
        {
            var agenda = await _context.Agendas.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }

            _context.Agendas.Remove(agenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgendaExists(int id)
        {
            return _context.Agendas.Any(e => e.Id == id);
        }
    }
}
