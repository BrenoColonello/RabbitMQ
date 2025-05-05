using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCommerceComRepository.Domain.RedeSocial.Interfaces
{
    // Interface do Repositório
    public interface IPostagemRepository
    {
        Task<Postagem> GetByIdAsync(Guid id);
        Task<IEnumerable<Postagem>> GetAllAsync();
        Task AddAsync(Postagem postagem);
        Task UpdateAsync(Postagem postagem);
        Task DeleteAsync(Guid id);
        Task AddCurtidaAsync(Guid postagemId, Guid usuarioId);
        Task AddComentarioAsync(Guid postagemId, string comentario);
    }
}
