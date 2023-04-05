using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading;
namespace ProblematicProblem
{
    internal class Program
    {
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "Lan Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            while (cont)
            {
                Console.WriteLine("Hello, welcome to the random activity genertaor! \n Would you like to generate a random activity? yes/no:");
                var contResponse = Console.ReadLine().ToLower();
                if (contResponse == "yes")
                {
                    cont = true;
                }
                else
                {
                    cont = false;
                    Environment.Exit(0);
                }
                Console.WriteLine();
                Console.WriteLine("We are going to need your information first! What is your name?");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("What is your age?");
                int userAge = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Would you like to see the current list of activities? Sure/No thanks:");
                contResponse = Console.ReadLine().ToLower();
                bool seeList = (contResponse == "sure") ? true : false;
                if (seeList)
                {
                    foreach (var i in activities)
                    {
                        Console.WriteLine($"{i} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add any activities before we generate one? yes/no:");
                    contResponse = Console.ReadLine().ToLower();
                    bool addToList = (contResponse == "yes");
                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add?");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (var i in activities)
                        {
                            Console.WriteLine($"{i} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no:");
                        contResponse = Console.ReadLine().ToLower();
                        addToList = (contResponse == "yes");
                    }
                }
                while (cont)
                {
                    Console.Write("connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Random rng = new Random();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivty = activities[randomNumber];
                    if (userAge < 21 && randomActivty == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivty}");
                        Console.WriteLine("Pick Something Else");
                        activities.Remove(randomActivty);
                        randomNumber = rng.Next(activities.Count);
                        randomActivty = activities[randomNumber];
                    }
                    Console.WriteLine($"Ah got it! {userName}, your random activty is: {randomActivty}! is this ok or do you want to grab another activty");
                    Console.WriteLine();
                    cont = (Console.ReadLine().ToLower() == "redo") ? true : false;
                        
                }
            }
        }
    }
}
 