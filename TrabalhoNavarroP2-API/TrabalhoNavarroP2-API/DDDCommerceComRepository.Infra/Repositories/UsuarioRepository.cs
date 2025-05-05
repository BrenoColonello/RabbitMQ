using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DDDCommerceComRepository.Infra.RedeSocial.Repositories
{


    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlContext _context;

        public UsuarioRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterPorIdAsync(Guid id)
        {
            return await _context.Usuarios
                .Include(u => u.Seguidores)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var usuario = await ObterPorIdAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SeguirUsuarioAsync(Guid usuarioId, Guid seguidoId)
        {
            var usuario = await ObterPorIdAsync(usuarioId);
            var seguido = await ObterPorIdAsync(seguidoId);

            if (usuario != null && seguido != null && !usuario.Seguidores.Contains(seguido))
            {
                usuario.Seguidores.Add(seguido);
                await _context.SaveChangesAsync();
            }
        }

        public async Task PararDeSeguirAsync(Guid usuarioId, Guid seguidoId)
        {
            var usuario = await ObterPorIdAsync(usuarioId);
            var seguido = await ObterPorIdAsync(seguidoId);

            if (usuario != null && seguido != null && usuario.Seguidores.Contains(seguido))
            {
                usuario.Seguidores.Remove(seguido);
                await _context.SaveChangesAsync();
            }
        }
    }

}
