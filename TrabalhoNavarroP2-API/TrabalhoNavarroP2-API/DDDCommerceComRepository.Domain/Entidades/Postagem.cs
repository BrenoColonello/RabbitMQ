using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace DDDCommerceComRepository.Domain.RedeSocial.Entidades
{
    public class Postagem
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataHora { get; set; }

        public Guid AutorId { get; set; }

        [JsonIgnore] // Isso vai esconder a propriedade Autor no Swagger e na serialização JSON
        public Usuario? Autor { get; set; } //Essa interrogação permite que não necessitemos de um Autor criado quando formos criar uma Postagem, mas ele é importante para mantermos o relacionamento entre Postagem e Autor. OU seja, podemos criar um Autor antes e setar somente seu id (guid) pela propriedade acima (AutorId)

        // Curtidas podem ser uma lista de Usuários sem relacionamento com cascata
        [JsonIgnore]
        public List<Usuario>? Curtidas { get; set; }

        public List<String> Comentarios { get; set; }
    }

}
