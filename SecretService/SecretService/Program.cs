// See https://aka.ms/new-console-template for more information

// Get the environment variable
string? secret_id = Environment.GetEnvironmentVariable("SECRET_ID");
string? role_id = Environment.GetEnvironmentVariable("ROLE_ID");


if (secret_id != null)
{
    Console.WriteLine($"Value: {secret_id}");
}
else
{
    Console.WriteLine("Environment variable not found for secret id");
}

if (role_id != null)
{
    Console.WriteLine($"Value: {role_id}");
}
else
{
    Console.WriteLine("Environment variable not found for role id");
}

