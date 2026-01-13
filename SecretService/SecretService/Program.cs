// See https://aka.ms/new-console-template for more information

// Get the environment variable
string? secret_id = Environment.GetEnvironmentVariable("SECRET_ID");
string? role_id = Environment.GetEnvironmentVariable("ROLE_ID");

foreach (System.Collections.DictionaryEntry env in Environment.GetEnvironmentVariables())
{
    Console.WriteLine($" The env variable is {env.Key} = {env.Value}");
}

