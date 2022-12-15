using APITargetMark.Context;
using APITargetMark.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITargetMark.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        //banco de dados
        private readonly AppDbContext _context;
        //construtor
        public RelatoriosController(AppDbContext context)
        {
            _context = context;
        }

        //Get /Relatorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relatorio>>> GetRelatorios()
        {
            return await _context.Relatorios.ToListAsync();
        }

        //Post /CriarRelatorio
        [HttpPost("/CriarRelatorio")]
        public async Task<ActionResult<Relatorio>> PostRelatorio(Relatorio relatorio)
        {
            var verificarEmpresa = _context.Empresas.Any(c => c.EmpresaId == relatorio.EmpresaId);
            var verificarCampanha = _context.Campanhas.Any(c => c.CampanhaId == relatorio.CampanhaId);         
            if (verificarEmpresa && verificarCampanha)
            {
                _context.Relatorios.Add(relatorio);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetRelatorio", new { id = relatorio.RelatorioId }, relatorio);
            }
            else
            {
                return BadRequest();
            }
        }

        //Delete /DeletarRelatorio
        [HttpDelete("/DeletarRelatorio/{id}")]
        public async Task<ActionResult<Relatorio>> DeleteRelatorio(int id)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);
            if (relatorio == null)
            {
                return NotFound();
            }

            _context.Relatorios.Remove(relatorio);
            await _context.SaveChangesAsync();

            return relatorio;
        }

        //Get /Relatorios/{id}  
        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult<Relatorio>> GetRelatorio(int id)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);

            if (relatorio == null)
            {
                return NotFound();
            }

            return relatorio;
        }
    }

}

