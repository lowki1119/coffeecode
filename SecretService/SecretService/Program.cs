// See https://aka.ms/new-console-template for more information

// Get the environment variable
using System.Text;
using System.Text.Json;

string? secret_id = Environment.GetEnvironmentVariable("SECRET_ID");
string? role_id = Environment.GetEnvironmentVariable("ROLE_ID");
string url = "http://151.145.51.221:8200/v1/auth/approle/login";
var payload = new
{
    role_id,
    secret_id
};

string jsonPayload = JsonSerializer.Serialize(payload);
using HttpClient client = new HttpClient();
StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

while (true)
{
    if (secret_id != null)
    {
        Console.WriteLine($" The secret id is {secret_id}");
    }
    else
    {
        Console.WriteLine(" The secret id is not set");
    }

    if (role_id != null)
    {
        Console.WriteLine($" The role id is {role_id}");
    }
    else
    {
        Console.WriteLine(" The role id is not set");
    }

    try
    {
        HttpResponseMessage response = await client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Response:");
        Console.WriteLine(responseBody);
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine($"Request error: {e.Message}");
    }

    Thread.Sleep(60000);
}


