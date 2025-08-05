using System;
using System.Threading.Tasks;
using Desafio.Data;
using Desafio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmpresaController(AppDbContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var empresas = await _context.Empresas.ToListAsync();
        return Ok(empresas);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var empresa = await _context.Empresas.FindAsync(id);
        
        if (empresa == null)
            return NotFound();
            
        return Ok(empresa);
    }

    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Empresa empresa)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetById), new { id = empresa.Id }, empresa);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Empresa empresa)
    {
        if (id != empresa.Id)
            return BadRequest("ID da empresa não corresponde ao ID na URL");
            
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingEmpresa = await _context.Empresas.FindAsync(id);
        if (existingEmpresa == null)
            return NotFound();

        _context.Entry(existingEmpresa).CurrentValues.SetValues(empresa);
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmpresaExists(id))
                return NotFound();
            throw;
        }
        
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var empresa = await _context.Empresas
            .Include(e => e.Fornecedores)  // Carrega fornecedores relacionados
            .FirstOrDefaultAsync(e => e.Id == id);
            
        if (empresa == null)
            return NotFound();

        // Verifica se há fornecedores vinculados
        if (empresa.Fornecedores?.Count > 0)
            return BadRequest("Não é possível excluir a empresa pois existem fornecedores vinculados");

        _context.Empresas.Remove(empresa);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    private bool EmpresaExists(Guid id)
    {
        return _context.Empresas.Any(e => e.Id == id);
    }
}