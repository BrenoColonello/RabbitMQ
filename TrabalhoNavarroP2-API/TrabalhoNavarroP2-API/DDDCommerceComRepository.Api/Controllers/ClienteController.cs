using DDDCommerceComRepository.Domain;
using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using DDDCommerceComRepository.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DDDCommerceComRepository.Api.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _usuarioRepository;

        public ClienteController(IClienteRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Obtém todos os usuários cadastrados.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> ObterTodos()
        {
            var usuarios = await _usuarioRepository.ObterTodosAsync();
            return Ok(usuarios);
        }

        /// <summary>
        /// Obtém um usuário por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> ObterPorId(Guid id)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            if (usuario == null) return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Adicionar(Cliente usuario)
        {
            await _usuarioRepository.AdicionarAsync(usuario);
            return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(Guid id, Cliente usuario)
        {
            if (id != usuario.Id) return BadRequest("IDs não correspondem.");

            await _usuarioRepository.AtualizarAsync(usuario);
            return NoContent();
        }

        /// <summary>
        /// Remove um usuário pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover(Guid id)
        {
            await _usuarioRepository.RemoverAsync(id);
            return NoContent();
        }
    }
}
