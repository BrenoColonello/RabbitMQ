using System.Text.Json.Serialization;

namespace DDDCommerceComRepository.Domain.RedeSocial.Entidades
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Curso { get; private set; }

        public List<Usuario> Seguidores { get; private set; } = new();

        [JsonIgnore] //nao pede no swagger
        public List<Postagem> Curtidas { get; set; } = new(); 
        // Lista de postagens que o usuário curtiu, só inicializamos para permitir que um 
        // Usuário possa ser criado sem depender de criar também uma Curtida.

        public Usuario(string nome, string email, string curso)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Curso = curso;
        }
    }
}
