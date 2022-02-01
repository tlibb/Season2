using System;
using GreetingService.API;
using System.Net.Http.Json;
using System.Text.Json;

namespace GreetingService.API.Client;

public class Program
{
    private static HttpClient _httpClient = new();

    private static async Task GetGreetingsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("http://localhost:5159/api/Greeting");
            response.EnsureSuccessStatusCode();                                                 //throws exception if HTTP response status is not a success status
            var responseBody = await response.Content.ReadAsStringAsync();

            //Do something with response
            var greetings = JsonSerializer.Deserialize<IEnumerable<Greeting>>(responseBody);

            foreach (var greeting in greetings)
            {
                Console.WriteLine($"[{greeting.id}] [{greeting.TimeStamp}] ({greeting.From} -> {greeting.To}) - {greeting.Message}");
            }

            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Get greetings failed: {e.Message}\n");
        }
    }

    private static async Task GetGreetingAsync(Guid id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"http://localhost:5159/api/Greeting{id}");
            response.EnsureSuccessStatusCode();                                                 //throws exception if HTTP response status is not a success status
            var responseBody = await response.Content.ReadAsStringAsync();

            //Do something with response
            var greeting = JsonSerializer.Deserialize<Greeting>(responseBody);

            Console.WriteLine($"The greeting with {id} has message {greeting.Message} and was sent from {greeting.From} -> {greeting.To}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong: {ex.Message}");
        }
    }
    //private static async Task WriteGreetingAsync(string message)
    //private static async Task UpdateGreetingAsync(Guid id, string message)

    public static void PrintAndReadOptions()
    {
        Console.WriteLine("Which task to you want to execute?");
        Console.WriteLine("1 - Print all greetings from repo to console");
        Console.WriteLine("2 - Print a given greeting according to ID");
    }

    public static async Task Main(string[] args)
    {
        Console.WriteLine("===============");
        Console.WriteLine("Greeting Client");
        Console.WriteLine("===============");
        Console.WriteLine();
        PrintAndReadOptions();
        string res = Console.ReadLine();

        switch (res)
        {
            case "1":
                await GetGreetingsAsync();
                break;
            case "2": 
                Console.WriteLine("What is the ID of the greeting?");
                var myID = Console.ReadLine();
                GetGreetingAsync(Guid.Parse(myID));
                break;

        }





        


    }
}