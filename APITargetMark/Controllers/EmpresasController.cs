using APITargetMark.Context;
using APITargetMark.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITargetMark.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        //banco de dados appdbcontext
        private readonly AppDbContext _context;
        //construtor
        public EmpresasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Empresas
        [HttpGet]
        //assincrono
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        // GET: Empresas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }

        // PUT: Empresas/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Empresa>> PutEmpresas(int id, Empresa empresa)
        {
            if (id != empresa.EmpresaId)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return empresa;
        }

        // POST: Empresas
        [HttpPost("CadastrarEmpresa")]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresa", new { id = empresa.EmpresaId }, empresa);
        }

        // DELETE: Empresas/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empresa>> DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return empresa;
        }


    }
}
