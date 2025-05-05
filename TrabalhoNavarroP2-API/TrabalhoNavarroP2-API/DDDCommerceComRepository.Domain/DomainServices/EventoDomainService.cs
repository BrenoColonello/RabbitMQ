using DDDCommerceComRepository.Domain.RedeSocial.Entidades;
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCommerceComRepository.Domain.RedeSocial.DomainServices
{
    public class EventoPolicyService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public EventoPolicyService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public async Task<bool> PodeParticipar(Usuario usuario, Evento evento)
        {
            //Regra 1 do Caso de Uso
            if (evento.Participantes.Any(p => p.Id == usuario.Id))
                return false;

            //Regra 2 do Caso de Uso
            if (evento.Participantes.Count >= 50)
                return false;


            //var user = await _usuarioRepository.ObterPorIdAsync(usuario.Id);
            if (usuario.Curso != "Computação")
                return false;
            //foreach (var participante in evento.Participantes)
            //{
            //    var bloqueado = await _bloqueioRepository.ExisteBloqueio(participante.Id, usuario.Id);
            //    if (bloqueado)
            //        return false;
            //}

            return true;
        }
    }

}
