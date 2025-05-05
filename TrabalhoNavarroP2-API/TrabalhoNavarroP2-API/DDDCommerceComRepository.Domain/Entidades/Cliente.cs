using System.Text.Json.Serialization;

namespace DDDCommerceComRepository.Domain.RedeSocial.Entidades
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Curso { get; private set; }


        public Cliente(string nome, string email, string curso)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Curso = curso;
        }
    }
}
