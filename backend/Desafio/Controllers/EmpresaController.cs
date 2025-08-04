using System.Threading.Tasks;
using Desafio.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class EmpresaController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await context.Empresas.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Empresa empresa)
    {
        context.Empresas.Add(empresa);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = empresa.Id }, empresa);
    }
}