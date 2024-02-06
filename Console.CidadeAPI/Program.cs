using System.Net.Http.Headers;
using System.Net.Http.Json;
using WebAPI.Cidades.Models;

class Program
{
        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:5178");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string op;
            do
            {
                // Print A Menu
                Console.WriteLine("Consumo API\n");
                Console.WriteLine("1 - Adicionar cidade\n");
                Console.WriteLine("2 - Atualizar uma cidade\n");
                Console.WriteLine("3 - Buscar uma cidade\n");
                Console.WriteLine("4 - Buscar todas as cidades\n");
                Console.WriteLine("5 - Deletar uma cidade\n");
                Console.WriteLine("0 - Digite 0 para sair\n");
                Console.WriteLine("Escolha (1,2,3,4,5 ou 0 para sair):\n");

                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        Console.WriteLine("Agora digite o come da cidade:\n");
                        var NomeInfo = Convert.ToString(Console.ReadLine());
                        await AddCityAsync(new Cidade
                        {
                            //Id = IdInfo,
                            Nome = NomeInfo
                        });
                        break;
                    case "2":
                        //Atualizo uma cidade
                        Console.WriteLine("Para atualixzar uma cidade digite o ID:\n");
                        var IdAtt = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Agora digite o come da cidade:\n");
                        var NomeAtt = Convert.ToString(Console.ReadLine());
                        await UpdateCityAsync(new Cidade
                        {
                            Id = IdAtt,
                            Nome = NomeAtt
                        });
                        break;
                    case "3":
                        //Buscar uma cidade
                        Console.WriteLine("Para buscar uma cidade digite o ID:\n");
                        var IdGet = Convert.ToInt32(Console.ReadLine());
                        await GetCityAsync(IdGet);
                        break;
                    case "4":
                        await GetCitiesAsync();
                        break;
                    case "5":
                        //Deleto uma cidade
                        Console.WriteLine("Para deletar uma cidade digite o ID:\n");
                        var IdDel = Convert.ToInt32(Console.ReadLine());
                        await DeleteCityAsync(IdDel);
                        break;
                    case "0":
                        Console.WriteLine("Programa finalizado.");
                        break;
                    default:
                        Console.WriteLine("Digite um valor valido", op);
                        break;
                }
                Console.Write("Precione uma tecla pra continuar...");
                Console.ReadLine();
                Console.WriteLine();
            } while (op != "0");
        }

        //Get
        static async Task GetCitiesAsync()
        {
            HttpResponseMessage response = await client.GetAsync("api/Cidade");
            if (response.IsSuccessStatusCode)
            {
                var cities = await response.Content.ReadAsAsync<IEnumerable<Cidade>>();
                foreach (var city in cities)
                {
                    Console.WriteLine($"Id: {city.Id}, Nome: {city.Nome}");
                }
            }
            else
            {
                Console.WriteLine("Falha ao obter as cidades: " + response.ReasonPhrase);
            }
        }

        //Get city
        static async Task GetCityAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/Cidade/{id}");
            if (response.IsSuccessStatusCode)
            {
                var cities = await response.Content.ReadAsAsync<IEnumerable<Cidade>>();
                foreach (var city in cities)
                {
                    Console.WriteLine($"Id: {city.Id}, Nome: {city.Nome}");
                }
            }
            else
            {
                Console.WriteLine("Falha ao obter a cidade: " + response.ReasonPhrase);
            }
        }

        //Add
        static async Task AddCityAsync(Cidade city)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Cidade", city);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Cidade adicionada com sucesso!");
        }

        //Update
        static async Task UpdateCityAsync(Cidade city)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Cidade/{city.Id}", city);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Cidade atualizada com sucesso!");
        }

        //Delete
        static async Task DeleteCityAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Cidade/{id}");
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Cidade deletada com sucesso!");
        }
}