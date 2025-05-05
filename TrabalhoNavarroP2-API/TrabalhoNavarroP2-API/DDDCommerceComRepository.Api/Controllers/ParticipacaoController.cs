using DDDCommerceComRepository.Application.RedeSocial.ApplicationServices;
using DDDCommerceComRepository.Application.RedeSocial.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDCommerceComRepository.Api.RedeSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipacaoController : ControllerBase
    {
        private readonly EventoApplicationService _eventoAppService;

        public ParticipacaoController(EventoApplicationService eventoAppService)
        {
            _eventoAppService = eventoAppService;
        }

        [HttpPost]
        public async Task<ActionResult> Participar([FromBody] ParticipacaoDto participacao)
        {
            var resultado = await _eventoAppService.ParticiparDoEvento(participacao.UsuarioId, participacao.EventoId);
            if (!resultado)
            {
                return BadRequest("Erro ao definir uma participação");
            }
            return Ok(resultado);
        }
    }

}
