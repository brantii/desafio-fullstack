using System.Linq;
using System.Threading.Tasks;
using Desafio.Data;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace Desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FornecedorController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? search)
        {
            var query = _context.Fornecedores.AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(f => f.Documento.Contains(search) || f.Nome.Contains(search));
                
            return Ok(await query.ToListAsync());
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            
            if (fornecedor == null)
                return NotFound();
                
            return Ok(fornecedor);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(Get), new { id = fornecedor.Id }, fornecedor);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
                return BadRequest("ID do fornecedor não corresponde ao ID na URL");
                
            var existingFornecedor = await _context.Fornecedores.FindAsync(id);
            if (existingFornecedor == null)
                return NotFound();
                
            _context.Entry(existingFornecedor).CurrentValues.SetValues(fornecedor);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
                    return NotFound();
                throw;
            }
            
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
                return NotFound();
                
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        private bool FornecedorExists(Guid id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}