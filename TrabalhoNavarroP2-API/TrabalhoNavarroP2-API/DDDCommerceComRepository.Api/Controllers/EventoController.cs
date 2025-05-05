using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDCommerceComRepository.Api.RedeSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> ObterEventoPorId(Guid id)
        {
            var evento = await _eventoRepository.ObterEventoPorId(id);
            if (evento == null)
            {
                return NotFound();
            }
            return evento;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> ObterTodosEventos()
        {
            var eventos = await _eventoRepository.ObterTodosEventos();
            return Ok(eventos);
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarEvento([FromBody] Evento evento)
        {
            await _eventoRepository.AdicionarEvento(evento);
            return CreatedAtAction(nameof(ObterEventoPorId), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarEvento(Guid id, [FromBody] Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }
            await _eventoRepository.AtualizarEvento(evento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoverEvento(Guid id)
        {
            await _eventoRepository.RemoverEvento(id);
            return NoContent();
        }
    }
}
