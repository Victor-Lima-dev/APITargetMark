using APITargetMark.Context;
using APITargetMark.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITargetMark.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        //GET:/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        //POST : /Cadastrar
        [HttpPost("Cadastrar")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            //verificar se o cliente ja existe
            var clienteNomeVerificacao = _context.Clientes.Any(x => x.Nome == cliente.Nome);
            var clienteIdadeVerificacao = _context.Clientes.Any(x => x.Idade == cliente.Idade);
            var clienteGeneroVerificacao = _context.Clientes.Any(x => x.Genero == cliente.Genero);
            var clienteRegiaoVerificacao = _context.Clientes.Any(x => x.Regiao == cliente.Regiao);

            if (clienteNomeVerificacao && clienteIdadeVerificacao && clienteGeneroVerificacao && clienteRegiaoVerificacao)
            {
                return BadRequest("Cliente já cadastrado");
            }

            //verifica se o genero foi digitado corretamente
            string[] generos = { "masculino", "feminino" };
            cliente.Genero.ToLower();
            if(!generos.Any(c => c == cliente.Genero))
            {
                return BadRequest("Digite um genero corretamente");
            }



            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        //PUT : /Editar
        [HttpPut("Editar/{id}")]

        public async Task<ActionResult<Cliente>> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            //verifica se o genero foi digitado corretamente
            string[] generos = { "masculino", "feminino" };
            cliente.Genero.ToLower();
            if (!generos.Any(c => c == cliente.Genero))
            {
                return BadRequest("Digite um genero corretamente");
            }



            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }            

        //GET : /Clientes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        //DELETE : /DeletarCliente/{id}
        [HttpDelete("Deletar")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }

        //GET : /Clientes/Buscar/{genero}
        [HttpGet("Buscar/Genero/{genero}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClienteGenero(string genero)
        {
            genero.ToLower();
            string[] generos = { "masculino", "feminino" };
            if(!generos.Any(c => c == genero))
            {
                return BadRequest("Digite um genero");
            }

            var cliente = await _context.Clientes.Where(x => x.Genero == genero).ToListAsync();
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        //Get : /Clientes/Buscar/{regiao}
        [HttpGet("Buscar/Regiao/{regiao}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClienteRegiao (string regiao)
        {
            var clientes = await _context.Clientes.Where(c => c.Regiao == regiao).ToListAsync();

            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes);
        }
    }
}
