using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RabbitMQ.Publisher;
class Publisher
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqps://ywlcmpwn:p5lsey2O43JZhEuJBUE7T-mz79diECJZ@jackal.rmq.cloudamqp.com/ywlcmpwn")
        };
        using var connection = factory.CreateConnection(); 
        using var channel = connection.CreateModel();

        string queueName = "minha-fila";
        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);


        object classe = new  { nome = "Teste", email = "algo", curso ="curso"};
        string message = JsonSerializer.Serialize(classe);
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        Console.WriteLine("Mensagem enviada: " + message);
    }
}