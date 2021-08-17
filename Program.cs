using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClient
{
    class Program
    {
        static async Task GetOneName(string name)
        {
            try
            {
                var client = new HttpClient();

                var responseBodyAsStream = await client.GetStreamAsync($"https://api.openbrewerydb.org/breweries?by_name={name}");

                var item = await JsonSerializer.DeserializeAsync<Breweries>(responseBodyAsStream);

                Console.WriteLine($"Found a brewery named {item.Name} located in {item.City}, {item.State}. Their address is {item.Street}. It is a {item.BreweryType} brewery.");
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("I could not find that item");
            }
        }
        static async Task Main(string[] args)
        {
            var keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("How would you like to view breweries in the Open Breweries Database?");
                Console.WriteLine("[1] CITY");
                Console.WriteLine("[2] NAME");
                Console.WriteLine("[3] STATE");
                Console.WriteLine("[4] TYPE");
                Console.WriteLine("[5] QUIT");
                var choice = Convert.ToInt32(Console.ReadLine());

                var client = new HttpClient();
                var responseAsStream = await client.GetStreamAsync("https://api.openbrewerydb.org/breweries");
                var items = await JsonSerializer.DeserializeAsync<List<Breweries>>(responseAsStream);



                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Would you like to: ");
                        Console.WriteLine("[1] View all");
                        Console.WriteLine("[2] Search by city");
                        var cityChoice = Convert.ToInt32(Console.ReadLine());
                        switch (cityChoice)
                        {
                            case 1:
                                Console.WriteLine();
                                Console.WriteLine("Viewing all breweries by city");
                                Console.WriteLine();
                                foreach (var item in items)
                                {
                                    Console.WriteLine($"{item.Name} is in {item.City}.");
                                }
                                break;
                            case 2:
                                Console.WriteLine("What city would you like to search for? ");
                                var citySearch = Console.ReadLine();
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Would you like to: ");
                        Console.WriteLine("[1] View all");
                        Console.WriteLine("[2] Search by name");
                        var nameChoice = Convert.ToInt32(Console.ReadLine());
                        switch (nameChoice)
                        {
                            case 1:
                                Console.WriteLine();
                                Console.WriteLine("Viewing breweries by name");
                                Console.WriteLine();
                                foreach (var item in items)
                                {
                                    Console.WriteLine($"There is a brewery named {item.Name}.");
                                }
                                break;
                            case 2:
                                Console.WriteLine();
                                Console.WriteLine("What name would you like to search for? ");
                                var name = Console.ReadLine();
                                await GetOneName(name);
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Would you like to: ");
                        Console.WriteLine("[1] View all");
                        Console.WriteLine("[2] Search by state");
                        var stateChoice = Convert.ToInt32(Console.ReadLine());
                        switch (stateChoice)
                        {
                            case 1:
                                Console.WriteLine();
                                Console.WriteLine("Viewing breweries by state");
                                Console.WriteLine();
                                foreach (var item in items)
                                {
                                    Console.WriteLine($"{item.Name} is in {item.State}.");
                                }
                                break;
                            case 2:
                                Console.WriteLine();
                                Console.WriteLine("What state would you like to search for? ");
                                Console.ReadLine();
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Would you like to: ");
                        Console.WriteLine("[1] View all");
                        Console.WriteLine("[2] Search by type");
                        var typeChoice = Convert.ToInt32(Console.ReadLine());
                        switch (typeChoice)
                        {
                            case 1:
                                Console.WriteLine();
                                Console.WriteLine("Viewing breweries by type");
                                Console.WriteLine();
                                foreach (var item in items)
                                {
                                    Console.WriteLine($"{item.Name} is a {item.BreweryType} brewery.");
                                }
                                break;
                            case 2:
                                Console.WriteLine();
                                Console.WriteLine("What type would you like to search for? ");
                                Console.ReadLine();
                                break;
                        }
                        break;
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using Open Brewery Database!");
                        keepGoing = false;
                        break;
                }
            }
        }
    }
}
