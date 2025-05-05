using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DDDCommerceComRepository.Infra.RedeSocial.Repositories
{


    public class ClienteRepository : IClienteRepository
    {
        private readonly SqlContext _context;

        public ClienteRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<Cliente> ObterPorIdAsync(Guid id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task AdicionarAsync(Cliente usuario)
        {
            await _context.Clientes.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Cliente usuario)
        {
            _context.Clientes.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var usuario = await ObterPorIdAsync(id);
            if (usuario != null)
            {
                _context.Clientes.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }

}
