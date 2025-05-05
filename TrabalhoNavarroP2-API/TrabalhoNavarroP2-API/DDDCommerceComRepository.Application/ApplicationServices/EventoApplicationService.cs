using DDDCommerceComRepository.Domain.RedeSocial.DomainServices;
using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCommerceComRepository.Application.RedeSocial.ApplicationServices
{
    public class EventoApplicationService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly EventoPolicyService _eventoPolicyService;

        public EventoApplicationService(IEventoRepository eventoRepository,IUsuarioRepository usuarioRepository,
            EventoPolicyService eventoPolicyService)
        {
            _eventoRepository = eventoRepository;
            _usuarioRepository = usuarioRepository;
            //_eventoPolicyService = eventoPolicyService;
        }

        //public async Task<Result> ParticiparDoEvento(Guid eventoId, Guid usuarioId)
        public async Task<bool> ParticiparDoEvento(Guid eventoId, Guid usuarioId)
        {
            var evento = await _eventoRepository.ObterEventoPorId(eventoId);
            var usuario = await _usuarioRepository.ObterPorIdAsync(usuarioId);

            if (evento == null || usuario == null)
                return false;
            //return Result.Failure("Evento ou usuário não encontrado.");

            var podeParticipar = await _eventoPolicyService.PodeParticipar(usuario, evento);
            if (!podeParticipar)
                //return Result.Failure("Usuário não pode participar do evento.");
                return false;

            evento.Participantes.Add(usuario);

            await _eventoRepository.AdicionarEvento(evento);

            //return Result.Success();
            return true;
        }

    }
}
