using CosmosDBExample.Models;
using CosmosDBExemple.Services;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDBExemple.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoasService _pessoasService;

        public PessoaController(ILogger<PessoaController> logger, IPessoasService pessoasService)
        {
            _pessoasService = pessoasService;
        }


        [HttpGet()]
        public async Task<IActionResult> Get() => Ok(await _pessoasService.GetPessoas());


        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name) => Ok(await _pessoasService.GetPessoasPorNome(name));


        [HttpPost()]
        public async Task<IActionResult> Add(Pessoa pessoa)
        {
            await _pessoasService.AddPessoa(pessoa);
            return Ok();
        }
    }
}