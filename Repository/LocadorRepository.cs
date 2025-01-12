using AutoMapper;
using LocacaoDeVeiculos.Dtos.Locador;
using LocacaoDeVeiculos.Models;
using LocacaoDeVeiculos.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LocacaoDeVeiculos.Repository
{
    public class LocadorRepository : ILocadorRepository
    {
        private readonly IMapper _mapper;
        private readonly LocacaoDeVeiculosContext _context;
        private readonly ILogger<ILocadorRepository> _logger;

        public LocadorRepository(IMapper mapper, LocacaoDeVeiculosContext context, ILogger<ILocadorRepository> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task CriarLocador(CreateLocadorDto dto)
        {
            try
            {
                var locador = _mapper.Map<Locador>(dto);
                var loc = await GetLocador(locador.Cpf);
                if (loc != null)
                    throw new Exception("Locador já existe!");
                await _context.Locadores.AddAsync(locador);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        public async Task<ReadLocadorDto> GetLocador(string cpf)
        {
            try
            {
                var locador = await _context.Locadores.Include(l => l.Locacoes).FirstOrDefaultAsync(l => l.Cpf == cpf);
                var dto = _mapper.Map<ReadLocadorDto>(locador);
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}
