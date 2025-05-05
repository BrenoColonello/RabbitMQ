using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDDCommerceComRepository.Infra.RedeSocial.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly SqlContext _context;

        public EventoRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<Evento> ObterEventoPorId(Guid id)
        {
            return await _context.Eventos.FindAsync(id);
        }

        public async Task<IEnumerable<Evento>> ObterTodosEventos()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task AdicionarEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarEvento(Evento evento)
        {
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverEvento(Guid id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
