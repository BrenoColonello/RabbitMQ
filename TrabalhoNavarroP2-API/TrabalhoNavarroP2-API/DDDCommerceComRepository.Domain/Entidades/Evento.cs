using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCommerceComRepository.Domain.RedeSocial.Entidades
{

    public class Evento
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Local { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataHora { get; private set; }
        public List<Usuario>? Participantes { get; private set; } = new();

        public Evento(string nome, string local, string descricao, DateTime dataHora)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Local = local;
            Descricao = descricao;
            DataHora = dataHora;
        }
    }
}
