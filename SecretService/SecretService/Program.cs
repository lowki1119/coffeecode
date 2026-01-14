// See https://aka.ms/new-console-template for more information

// Get the environment variable
using SecretService;
using System.Text;
using System.Text.Json;

string? secret_id = Environment.GetEnvironmentVariable("SECRET_ID");
//string? role_id = Environment.GetEnvironmentVariable("ROLE_ID");
//string? secret_id = "3fe3a4ff-ebe1-b832-2fcd-437bb593e040";
string? role_id = "29bdd94a-b015-aff0-5285-f44ec726e3ef";
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
    Console.WriteLine("Starting Loop...");

    if (secret_id != null)
    {
        Console.WriteLine($" The secret id is {secret_id}");
    }
    else
    {
        Console.WriteLine(" The secret id is not set");
    }

    try
    {
        HttpResponseMessage response = await client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Get Response:");
        Console.WriteLine(responseBody);

        VaultResponse? vaultResponse = JsonSerializer.Deserialize<VaultResponse>(responseBody, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true 
        });

        string? clientToken = vaultResponse?.Auth?.ClientToken;

        Console.WriteLine("Client Token:");
        Console.WriteLine(clientToken);

        client.DefaultRequestHeaders.Add("X-Vault-Token", clientToken);

        HttpResponseMessage secretResponse = await client.GetAsync("http://151.145.51.221:8200/v1/secret-engine/data/my-test-secret");

        if (secretResponse.IsSuccessStatusCode)
        {
            string secretContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Secret Response:");
            Console.WriteLine(content);
        }
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine($"Request error: {e.Message}");
    }

    Thread.Sleep(60000);
}


