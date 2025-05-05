
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using DDDCommerceComRepository.Domain.RedeSocial.Entidades;

namespace ConsoleApp1
{

    class ConsoleApp1
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqps://ywlcmpwn:p5lsey2O43JZhEuJBUE7T-mz79diECJZ@jackal.rmq.cloudamqp.com/ywlcmpwn") // A URL do RabbitMQ, substitua com sua URL real
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            string queueName = "minha-fila"; // Nome da fila onde as mensagens serão consumidas
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel); // Criando o consumidor para consumir as mensagens da fila

            // Evento que será disparado sempre que uma mensagem for recebida
            consumer.Received += (model, ea) =>
            {
                // O parâmetro `ea` contém a mensagem recebida
                var body = ea.Body.ToArray(); // O corpo da mensagem é um array de bytes

                // Converte o array de bytes em uma string (JSON)
                string jsonMessage = Encoding.UTF8.GetString(body);

                // Agora que temos a string JSON, vamos deserializá-la em um objeto
                var objeto = JsonSerializer.Deserialize<Cliente>(jsonMessage);

                // Exibe os dados recebidos para ver o conteúdo
                Console.WriteLine($"Recebido: {jsonMessage}");

                ClientRest.Enviar(jsonMessage);

                // Exemplo de como você poderia fazer um POST para uma API com os dados:
                // Você pode usar o HttpClient para enviar os dados a uma API (a implementação está comentada)
                // var client = new HttpClient();

                // var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
                // var response = await client.PostAsync("https://suaapi.com/endpoint", content);
            };

            // Inicia o consumo das mensagens da fila, com autoAck=true para confirmar automaticamente o recebimento
            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            Console.WriteLine("Aguardando mensagens. Pressione [enter] para sair.");
            Console.ReadLine(); // Impede que o programa termine imediatamente, aguardando o consumo das mensagens
        }
    }


}

/*
namespace RabbitMQ.Subscriber;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
class Subscriber
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory()
        {
            Uri = new Uri("amqps://ywlcmpwn:p5lsey2O43JZhEuJBUE7T-mz79diECJZ@jackal.rmq.cloudamqp.com/ywlcmpwn")
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        string queueName = "minha-fila";
        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Mensagem recebida: " + message);
        };
        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        Console.WriteLine("Aguardando mensagens. Pressione [enter] para sair.");
        Console.ReadLine();
    }
}
*/