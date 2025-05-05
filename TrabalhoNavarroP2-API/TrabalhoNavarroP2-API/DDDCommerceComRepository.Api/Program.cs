
using DDDCommerceComRepository.Domain.RedeSocial.Interfaces;
using DDDCommerceComRepository.Infra;
using DDDCommerceComRepository.Infra.RedeSocial.Repositories;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DDDCommerceComRepository.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. DI (Dependency Injection)
            builder.Services.AddDbContext<SqlContext>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();
            builder.Services.AddScoped<IEventoRepository, EventoRepository>();
            builder.Services.AddCors(o => o.AddDefaultPolicy(p => p.AllowAnyOrigin()));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
