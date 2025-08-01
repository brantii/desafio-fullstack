using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly AppDbContext _context;
    public EmpresaController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _context.Empresas.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Empresa empresa)
    {
        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = empresa.Id }, empresa);
    }
}
