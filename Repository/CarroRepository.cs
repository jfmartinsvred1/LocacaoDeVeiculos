using AutoMapper;
using LocacaoDeVeiculos.Dtos.Carro;
using LocacaoDeVeiculos.Enums;
using LocacaoDeVeiculos.Models;
using LocacaoDeVeiculos.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace LocacaoDeVeiculos.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly LocacaoDeVeiculosContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ICarroRepository> _logger;
        public CarroRepository(LocacaoDeVeiculosContext context, IMapper mapper, ILogger<ICarroRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddCar(CreateCarroDto dto)
        {
            try
            {
                var carro = _mapper.Map<Carro>(dto);
                await _context.Carros.AddAsync(carro);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
            }
        }

        public async Task<Carro> GetCarById(string carroId)
        {
            try
            {
                var carro = await _context.Carros.FirstOrDefaultAsync(c=>c.CarroId==carroId);
                if (carro == null)
                    throw new Exception("Carro não existe!");
                return carro;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception("Erro ao buscar o carro!");
            }
        }

        public async Task<IEnumerable<Carro>> GetCarros(bool disponiveis,TipoCarro tipo)
        {
            try
            {
                var carros = await _context.Carros.Where(carro => carro.Tipo==tipo).ToListAsync();
                if (disponiveis)
                {
                    return carros.Where(carro => carro.Locado == false).ToList();
                }

                return carros;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, ex.Message);
                return Enumerable.Empty<Carro>();
            }
        }

        public async Task LocarOuDevolver(string carroId)
        {
            try
            {
                var carro = await _context.Carros.FirstOrDefaultAsync(carro=>carro.CarroId==carroId);
                if (carro == null)
                    throw new NullReferenceException("Carro não existe!");
                carro.Locado = !carro.Locado;
                _context.Carros.Update(carro);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
