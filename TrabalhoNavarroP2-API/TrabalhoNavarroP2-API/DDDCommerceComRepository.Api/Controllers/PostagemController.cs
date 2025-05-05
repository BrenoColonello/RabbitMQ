using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDCommerceComRepository.Api.RedeSocial.Controllers
{
    // Controller da Postagem
    [ApiController]
    [Route("api/[controller]")]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemRepository _postagemRepository;

        public PostagemController(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postagens = await _postagemRepository.GetAllAsync();
            return Ok(postagens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var postagem = await _postagemRepository.GetByIdAsync(id);
            if (postagem == null)
                return NotFound();
            return Ok(postagem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Postagem postagem)
        {
            await _postagemRepository.AddAsync(postagem);
            return CreatedAtAction(nameof(GetById), new { id = postagem.Id }, postagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Postagem postagem)
        {
            if (id != postagem.Id)
                return BadRequest();

            await _postagemRepository.UpdateAsync(postagem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _postagemRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/curtir/{usuarioId}")]
        public async Task<IActionResult> AddCurtida(Guid id, Guid usuarioId)
        {
            await _postagemRepository.AddCurtidaAsync(id, usuarioId);
            return NoContent();
        }

        [HttpPost("{id}/comentar")]
        public async Task<IActionResult> AddComentario(Guid id, [FromBody] string comentario)
        {
            await _postagemRepository.AddComentarioAsync(id, comentario);
            return NoContent();
        }
    }

}
