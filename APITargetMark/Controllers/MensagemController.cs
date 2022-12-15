using APITargetMark.Context;
using APITargetMark.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITargetMark.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        //banco de dados
        private readonly AppDbContext _context;
        //construtor
        public MensagemController(AppDbContext context)
        {
            _context = context;
        }

        //GET /Mensagem
        [HttpGet]
        //assincrono
        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagens()
        {
            return await _context.Mensagens.ToListAsync();
        }

        //POST /CriarMensagem
        [HttpPost("/CriarMensagem")]
        public async Task<ActionResult<Mensagem>> PostMensagem(Mensagem mensagem)
        {
            //verificando se a mensagem existe
            var mensagemTextoVerifica = await _context.Mensagens.AnyAsync(m => m.Texto == mensagem.Texto);
            var mensagemTituloVerifica = await _context.Mensagens.AnyAsync(m => m.Titulo == mensagem.Titulo);
            var mensagemCampanhaVerifica = await _context.Mensagens.AnyAsync(m => m.CampanhaId == mensagem.CampanhaId);
            
            if (mensagemTextoVerifica && mensagemTituloVerifica && mensagemCampanhaVerifica)
            {
                return BadRequest("Mensagem já cadastrada");
            }

            if (_context.Campanhas.Any(e => e.CampanhaId == mensagem.CampanhaId))
            {
                _context.Mensagens.Add(mensagem);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMensagem", new { id = mensagem.MensagemId }, mensagem);
            }
            else
            {
                return BadRequest();
            }


        }

        //PUT /EditarMensagem
        [HttpPut("/EditarMensagem/{id}")]
        public async Task<ActionResult<Mensagem>> PutMensagem(int id, Mensagem mensagem)
        {
            if (id != mensagem.MensagemId || _context.Campanhas.Any(e => e.CampanhaId == mensagem.CampanhaId))
            {
                return BadRequest();
            }

            _context.Entry(mensagem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //GET /Buscar/{id}
        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult<Mensagem>> GetMensagem(int id)
        {
            var mensagem = await _context.Mensagens.FindAsync(id);

            if (mensagem == null)
            {
                return NotFound();
            }

            return mensagem;
        }

        //DELETE /DeletarMensagem/{id}
        [HttpDelete("DeletarMensagem/{id}")]
        public async Task<ActionResult<Mensagem>> DeleteMensagem(int id)
        {
            var mensagem = await _context.Mensagens.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            _context.Mensagens.Remove(mensagem);
            await _context.SaveChangesAsync();

            return mensagem;
        }
    }
}
