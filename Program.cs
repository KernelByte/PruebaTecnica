using System;
using System.Text;
using System.Net.Http.Headers;


class Program
{
    static async Task Main(string[] args)
    {
        // URL de la API ejemplo
        var baseAddres = new Uri("http//prueba_api.com/api/");

        // Definicion de valores pra el usuario
        var userName = "oscar Martinez";
        var email = "oscar1243@gmail.com";
        var password = "sfdddsf3434r2ewr";

        // Uso del servicio HttpClient
        using var httpClient = new HttpClient { BaseAddress = baseAddres };
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appplication/json"));

        // Variable para añadir a la url el endpoint users
        var createUserUrl = "users";

        //Creacion del nuevo user
        var newUser = new
        {
            userName,
            email,
            password
        };

        // Añadir usuario y conversion en formato JSON
        var newUserJson = Newtonsoft.Json.JsonConvert.SerializeObject(newUser);
        var httpContent = new StringContent(newUserJson, Encoding.UTF8, "appplication/json");
        var createResponse = await httpClient.PostAsync(createUserUrl, httpContent);
        createResponse.EnsureSuccessStatusCode();

        // Obtener todos los usuarios creados
        var getusers = "users";
        var getResponse = await httpClient.GetAsync(getusers);
        getResponse.EnsureSuccessStatusCode();
        var responseBody = await getResponse.Content.ReadAsStringAsync();

        // Conversion a JSON
        var users = Newtonsoft.Json.JsonConvert.SerializeObject(responseBody);
        Console.WriteLine("Consulta: {users}");
    }
}