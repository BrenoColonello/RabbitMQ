using DDDCommerceComRepository.Domain;
using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using DDDCommerceComRepository.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DDDCommerceComRepository.Api.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Obtém todos os usuários cadastrados.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObterTodos()
        {
            var usuarios = await _usuarioRepository.ObterTodosAsync();
            return Ok(usuarios);
        }

        /// <summary>
        /// Obtém um usuário por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObterPorId(Guid id)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            if (usuario == null) return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Adicionar(Usuario usuario)
        {
            await _usuarioRepository.AdicionarAsync(usuario);
            return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(Guid id, Usuario usuario)
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

        /// <summary>
        /// Permite que um usuário siga outro usuário.
        /// </summary>
        [HttpPost("{usuarioId}/seguir/{seguidoId}")]
        public async Task<ActionResult> SeguirUsuario(Guid usuarioId, Guid seguidoId)
        {
            await _usuarioRepository.SeguirUsuarioAsync(usuarioId, seguidoId);
            return Ok("Agora você está seguindo esse usuário.");
        }

        /// <summary>
        /// Permite que um usuário pare de seguir outro usuário.
        /// </summary>
        [HttpPost("{usuarioId}/parar-de-seguir/{seguidoId}")]
        public async Task<ActionResult> PararDeSeguirUsuario(Guid usuarioId, Guid seguidoId)
        {
            await _usuarioRepository.PararDeSeguirAsync(usuarioId, seguidoId);
            return Ok("Você parou de seguir esse usuário.");
        }
    }
}
