using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class FornecedorController : ControllerBase
{
    private readonly AppDbContext _context;
    public FornecedorController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? search)
    {
        var query = _context.Fornecedores.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(f => f.Documento.Contains(search) || f.Nome.Contains(search));

        return Ok(await query.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = fornecedor.Id }, fornecedor);
    }
}
