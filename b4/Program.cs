namespace b4;

using Newtonsoft.Json;
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter username: ");
        string? username = Console.ReadLine();
        while (string.IsNullOrEmpty(username))
        {
            Console.Write("Username cannot be empty. Enter username: ");
            username = Console.ReadLine();
        }

        Console.Write("Enter password: ");
        string? password = Console.ReadLine();
        while (string.IsNullOrEmpty(password))
        {
            Console.Write("Password cannot be empty. Enter password: ");
            password = Console.ReadLine();
        }

        Console.Write("Enter IP: ");
        string? ip = Console.ReadLine();
        while (string.IsNullOrEmpty(ip))
        {
            Console.Write("IP cannot be empty. Enter IP: ");
            ip = Console.ReadLine();
        }

        HttpCamClient client = new HttpCamClient(ip, username, password);
        var b = client.A.Login().GetAwaiter().GetResult();
        if (b is null)
        {
            Console.WriteLine("Login failed");
            return;
        }
        else
        {
            client.F.OpenStream().GetAwaiter().GetResult();
            client.A.SendHeartbeat(b).GetAwaiter().GetResult();
            client.F.GetRealTimeTemp().GetAwaiter().GetResult();

        }
    }

    
}
