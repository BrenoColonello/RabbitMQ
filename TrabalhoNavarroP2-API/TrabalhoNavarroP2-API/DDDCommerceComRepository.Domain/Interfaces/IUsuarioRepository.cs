using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDCommerceComRepository.Domain.RedeSocial.Interfaces
{


    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task RemoverAsync(Guid id);
        Task SeguirUsuarioAsync(Guid usuarioId, Guid seguidoId);
        Task PararDeSeguirAsync(Guid usuarioId, Guid seguidoId);
    }

}
