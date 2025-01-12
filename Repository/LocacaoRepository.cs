using AutoMapper;
using LocacaoDeVeiculos.Dtos.Locacao;
using LocacaoDeVeiculos.Models;
using LocacaoDeVeiculos.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LocacaoDeVeiculos.Repository
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly LocacaoDeVeiculosContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ILocacaoRepository> _logger;
        private readonly ICarroRepository _carroRepository;

        public LocacaoRepository(LocacaoDeVeiculosContext context, IMapper mapper, ILogger<ILocacaoRepository> logger, ICarroRepository carroRepository)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _carroRepository = carroRepository;
        }

        public async Task Add(CreateLocacaoDto model)
        {
            try
            {
                var locacao = _mapper.Map<Locacao>(model);
                if(locacao != null)
                {
                    var carro = await _carroRepository.GetCarById(locacao.CarroId);
                    if (carro.Locado)
                        throw new Exception("Carro não esta disponível");
                    await _carroRepository.LocarOuDevolver(locacao.CarroId);
                    locacao.CalcularValor(carro.Diaria);
                    await _context.Locacoes.AddAsync(locacao);
                    await _context.SaveChangesAsync();
                }
                
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<ReadLocacaoDto>> GetLocacoes()
        {
            try
            {
                var locacoes = await _context.Locacoes.Include(locacao => locacao.Carro).Include(locacao => locacao.Locador).ToListAsync();
                var dto = _mapper.Map<IEnumerable<ReadLocacaoDto>>(locacoes);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return Enumerable.Empty<ReadLocacaoDto>();
            }

        }
    }
}
