using LocacaoDeVeiculos.Dtos.Locador;
using LocacaoDeVeiculos.Repository;
using LocacaoDeVeiculos.Dtos.Locacao;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoDeVeiculos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocadorController:ControllerBase
    {
        private readonly ILocadorRepository _locadorRepository;

        public LocadorController(ILocadorRepository locadorRepository)
        {
            _locadorRepository = locadorRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CreateLocadorDto dto)
        {
            try
            {
                await _locadorRepository.CriarLocador(dto);
                return Ok("Locador criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Locador(string cpf)
        {
            ReadLocadorDto dto = await _locadorRepository.GetLocador(cpf);
            return Ok(dto);
        }
    }
}
