// See https://aka.ms/new-console-template for more information

// Get the environment variable
string? secret_id = Environment.GetEnvironmentVariable("SECRET_ID");
string? role_id = Environment.GetEnvironmentVariable("ROLE_ID");


while(true)
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

    foreach (System.Collections.DictionaryEntry env in Environment.GetEnvironmentVariables())
    {
        Console.WriteLine($" The env variable is {env.Key} = {env.Value}");
    }

    Thread.Sleep(60000);
}


