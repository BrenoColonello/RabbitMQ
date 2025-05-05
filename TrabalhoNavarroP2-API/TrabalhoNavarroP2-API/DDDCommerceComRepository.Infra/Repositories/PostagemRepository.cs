using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDDCommerceComRepository.Infra.RedeSocial.Repositories
{
    // Implementação do Repositório
    public class PostagemRepository : IPostagemRepository
    {
        private readonly SqlContext _context;

        public PostagemRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<Postagem> GetByIdAsync(Guid id)
        {
            return await _context.Postagens.Include(p => p.Autor)
                                           .Include(p => p.Curtidas)
                                           .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Postagem>> GetAllAsync()
        {
            return await _context.Postagens.Include(p => p.Autor)
                                            .Include(p => p.Curtidas)
                                            .ToListAsync();
        }

        public async Task AddAsync(Postagem postagem)
        {
            await _context.Postagens.AddAsync(postagem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Postagem postagem)
        {
            _context.Postagens.Update(postagem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var postagem = await GetByIdAsync(id);
            if (postagem != null)
            {
                _context.Postagens.Remove(postagem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddCurtidaAsync(Guid postagemId, Guid usuarioId)
        {
            var postagem = await GetByIdAsync(postagemId);
            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (postagem != null && usuario != null)
            {
                postagem.Curtidas ??= new List<Usuario>();
                postagem.Curtidas.Add(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddComentarioAsync(Guid postagemId, string comentario)
        {
            var postagem = await GetByIdAsync(postagemId);
            if (postagem != null)
            {
                postagem.Comentarios ??= new List<string>();
                postagem.Comentarios.Add(comentario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
