using LocacaoDeVeiculos.Dtos.Locacao;
using LocacaoDeVeiculos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoDeVeiculos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocacaoController:ControllerBase
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public LocacaoController(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateLocacaoDto dto)
        {
            try
            {
                await _locacaoRepository.Add(dto);
                return Ok("Locacao Criada Com Sucesso!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _locacaoRepository.GetLocacoes());
        }
    }
}
