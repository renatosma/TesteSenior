using Microsoft.AspNetCore.Mvc;
using TesteSenior.Models;
using TesteSenior.Repositories.Interfaces;

namespace TesteSenior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoa()
        {
            return Ok(await _pessoaRepository.GetPessoa());
        }

        [HttpGet("GetPessoa/{estado}")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoaEstado(string estado)
        {
            return await _pessoaRepository.GetPessoaEstado(estado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoaId(int id)
        {
            
            var Pessoa = await _pessoaRepository.GetPessoaId(id);

            if (Pessoa == null)
            {
                return NotFound();
            }

            return Pessoa;
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            await _pessoaRepository.PostPessoa(pessoa);

            return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pessoa>> PutPessoa(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest();
            }
            await _pessoaRepository.PutPessoa(id, pessoa);

            return await GetPessoaId(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            await _pessoaRepository.DeletePessoa(id);

            return NoContent();
        }
    }
}
