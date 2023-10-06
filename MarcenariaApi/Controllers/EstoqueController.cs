﻿using MarcenariaApi.Data;
using MarcenariaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarcenariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private MarcenariaDbContext _dbContext;
        public EstoqueController(MarcenariaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Estoque>>> Listar()
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Estoques is null) return NotFound();
            return await _dbContext.Estoques.Include(e => e.materiais).ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Estoque>> Buscar(int id)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Estoques is null) return NotFound();
            var estoqueTemp = await _dbContext.Estoques.Include(e => e.materiais).FirstOrDefaultAsync(e => e.id == id);
            if (estoqueTemp is null) return NotFound();
            return estoqueTemp;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Estoque estoque)
        {
            if (_dbContext is null) return NotFound();
            if (_dbContext.Estoques is null) return NotFound();

            await _dbContext.AddAsync(estoque);
            await _dbContext.SaveChangesAsync();
            return Created("Estoque cadastrado com sucesso!", estoque);
        }

        [HttpPut()]
        [Route("atualizar/{id}")]
        public async Task<ActionResult> Alterar(int id, Estoque estoque)
        {
            _dbContext.Entry(estoque).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstoqueExists(id))
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
            if (_dbContext.Estoques is null) return NotFound();
            var estoqueTemp = await _dbContext.Estoques.FindAsync(id);
            if (estoqueTemp is null) return NotFound();
            _dbContext.Remove(estoqueTemp);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        private bool EstoqueExists(int id)
        {
            return _dbContext.Estoques.Any(e => e.id == id);
        }
    }
}
