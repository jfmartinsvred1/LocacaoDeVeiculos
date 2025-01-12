using LocacaoDeVeiculos.Dtos.Carro;
using LocacaoDeVeiculos.Enums;
using LocacaoDeVeiculos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoDeVeiculos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController:ControllerBase
    {
        private ICarroRepository _carroRepository;

        public CarroController(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [HttpGet("Compactos")]
        public async Task<IActionResult> GetCompactos()
        {
            var carros = await _carroRepository.GetCarros(true,TipoCarro.Compacto);
            return Ok(carros);
        }
        [HttpGet("Suv")]
        public async Task<IActionResult> GetSuv()
        {
            var carros = await _carroRepository.GetCarros(true, TipoCarro.Suv);
            return Ok(carros);
        }
        [HttpPost("/Carro")]
        public async Task<IActionResult> AddCarro(CreateCarroDto dto)
        {
            await _carroRepository.AddCar(dto);
            return Ok("Carro Adicionado Com Sucesso");
        }
    }
}
