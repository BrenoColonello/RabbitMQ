using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDCommerceComRepository.Domain.RedeSocial.Interfaces
{


    public interface IClienteRepository
    {
        Task<Cliente> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Cliente>> ObterTodosAsync();
        Task AdicionarAsync(Cliente usuario);
        Task AtualizarAsync(Cliente usuario);
        Task RemoverAsync(Guid id);
    }

}
