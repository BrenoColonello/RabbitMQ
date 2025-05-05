using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCommerceComRepository.Domain.RedeSocial.Interfaces
{
    public interface IEventoRepository
    {
        Task<Evento> ObterEventoPorId(Guid id);
        Task<IEnumerable<Evento>> ObterTodosEventos();
        Task AdicionarEvento(Evento evento);
        Task AtualizarEvento(Evento evento);
        Task RemoverEvento(Guid id);
    }
}
