using APITargetMark.Context;
using APITargetMark.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITargetMark.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CampanhasController : ControllerBase
    {
        private readonly AppDbContext _context;
        //construtor
        public CampanhasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Campanhas
        [HttpGet]
        //assincrono
        public async Task<ActionResult<IEnumerable<Campanha>>> GetCampanhas()
        {
            return await _context.Campanhas.ToListAsync();
        }

        // POST: /CriarCampanha
        [HttpPost("/CriarCampanha")]
        public async Task<ActionResult<Campanha>> PostCampanha(Campanha campanha)
        {
            _context.Campanhas.Add(campanha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampanha", new { id = campanha.CampanhaId }, campanha);
        }

        // PUT: /EditarCampanha
        [HttpPut("/EditarCampanha/{id}")]
        public async Task<ActionResult<Campanha>> PutCampanha(int id, Campanha campanha)
        {
            if (id != campanha.CampanhaId)
            {
                return BadRequest();
            }

            _context.Entry(campanha).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Get: /Campanhas/{id}
        [HttpGet("Buscar/id/{id}")]
        public async Task<ActionResult<Campanha>> GetCampanha(int id)
        {
            var campanha = await _context.Campanhas.FindAsync(id);

            if (campanha == null)
            {
                return NotFound();
            }

            return campanha;
        }

        // DELETE: /DeletarCampanha/{id}
        [HttpDelete("DeletarCampanha/{id}")]
        public async Task<ActionResult<Campanha>> DeleteCampanha(int id)
        {
            var campanha = await _context.Campanhas.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }

            _context.Campanhas.Remove(campanha);
            await _context.SaveChangesAsync();

            return Ok(campanha);
        }

        //Get: /Campanhas/BuscarPorNome/{nome}
        [HttpGet("Buscar/nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Campanha>>> GetCampanhaPorNome(string nome)
        {
            var campanha = await _context.Campanhas.Where(x => x.Nome == nome).ToListAsync();

            if (campanha == null)
            {
                return NotFound();
            }

            return campanha;
        }

        //Get: /Campanhas/BuscarPorData/{data}
        [HttpGet("Buscar/data/{data}")]
        public async Task<ActionResult<IEnumerable<Campanha>>> GetCampanhaPorData(DateTime data)
        {
            var campanha = await _context.Campanhas.Where(x => x.Data == data).ToListAsync();

            if (campanha == null)
            {
                return NotFound();
            }

            return campanha;
        }

        //Get: /Campanhas/Buscar/{publicoAlvo}
        [HttpGet("Buscar/{publicoAlvo}")]
        public async Task<ActionResult<IEnumerable<Campanha>>> GetCampanhaPorPublicoAlvo(string publicoAlvo)
        {
            var campanha = await _context.Campanhas.Where(x => x.PublicoAlvo == publicoAlvo).ToListAsync();

            if (campanha == null)
            {
                return NotFound();
            }

            return campanha;
        }
        
        

    }
}
