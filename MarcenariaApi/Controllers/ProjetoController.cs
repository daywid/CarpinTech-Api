using MarcenariaApi.Data;
using MarcenariaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarcenariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private MarcenariaDbContext _dbContext;
        public ProjetoController(MarcenariaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Projeto>>> Listar()
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Projetos is null) return NotFound();
            return await _dbContext.Projetos.Include(e => e.Tarefas).ThenInclude(t => t.Materiais).ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Projeto>> Buscar(int id)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Projetos is null) return NotFound();
            var projetoTemp = await _dbContext.Projetos.Include(e => e.Tarefas).ThenInclude(t => t.Materiais).FirstOrDefaultAsync(e => e.id == id);
            if (projetoTemp is null) return NotFound();
            return projetoTemp;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Projeto projeto)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Projetos is null) return NotFound();
            await _dbContext.AddAsync(projeto);
            await _dbContext.SaveChangesAsync();
            return Created("", projeto);
        }

        [HttpPut()]
        [Route("atualizar/{id}")]
        public async Task<ActionResult> Alterar(int id,  Projeto projeto)
        {
            _dbContext.Entry(projeto).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetoExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete()]
        [Route("deletar/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Projetos is null) return NotFound();
            var projetoTemp = await _dbContext.Projetos.FindAsync(id);
            if (projetoTemp is null) return NotFound();
            _dbContext.Remove(projetoTemp);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        private bool ProjetoExists(int id)
        {
            return _dbContext.Projetos.Any(e => e.id == id);
        }
    }
}
