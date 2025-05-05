using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1{
    public class ClientRest
    {
        public static async void Enviar(string message)
        {

            // Instanciando o HttpClient
            using (var client = new HttpClient())
            {
                // A URL da API para a qual você vai fazer o POST
                string url = "http://localhost:5184/api/cliente";

                // Criando o objeto para ser enviado no POST
                
                // Serializando o objeto para JSON usando System.Text.Json
                var json = JsonSerializer.Serialize(message);

                // Criando o conteúdo do corpo da requisição
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Fazendo o POST
                    var response = await client.PostAsync(url, content);

                    // Verificando se a resposta foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Requisição POST bem-sucedida!");
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Resposta da API: " + responseBody);
                    }
                    else
                    {
                        Console.WriteLine("Falha na requisição: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao fazer a requisição: " + ex.Message);
                }
            }
        }
    }
}