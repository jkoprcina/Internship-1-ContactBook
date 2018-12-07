using System;
using System.Collections.Generic;

namespace Internship_1_ContactBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var accountBook = new Dictionary<string, string[]>();
            int choice;

            do
            {
                Console.Write("Izaberite jednu od sljedecih opcija:\n" +
                    "1) Dodavanje novog upisa\n" +
                    "2) Promjena imena, broja ili adrese\n" +
                    "3) Brisanje upisa\n" +
                    "4) Pretraga po broju\n" +
                    "5) Pretraga po imenu\n" +
                    "Za izaci iz menia i programa, upisite bilo koji cijeli broj koji nije naveden\n");
                choice = int.Parse(Console.ReadLine());
                string[] input = new string[4];
                string firstNumber, secondNumber;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Unesite broj, naziv i adresu");
                        Console.WriteLine("Unesi ime:");
                        input[0] = Console.ReadLine();
                        Console.WriteLine("Unesi prezime:");
                        input[1] = Console.ReadLine();
                        Console.WriteLine("Unesi adresu:");
                        input[2] = Console.ReadLine();
                        Console.WriteLine("Unesi broj:");
                        input[3] = Console.ReadLine();
                        Console.WriteLine("Unesite broj opet za potvrdu:");
                        var number = Console.ReadLine();
                        if (number != input[3])
                            break;
                        AddingANewContact(accountBook, input);
                        WriteOutContactBook(accountBook);
                        break;
                    case 2:
                        Console.WriteLine("Upisite broj za koji zelite nesto mijenjat");
                        firstNumber = Console.ReadLine();
                        Console.WriteLine("Unesite opet isti broj za potvrdu");
                        secondNumber = Console.ReadLine();
                        if (firstNumber != secondNumber)
                            break;
                        Console.WriteLine("Unesite je li zelite mijenjati ime, prezime, adresu ili broj");
                        var answer = Console.ReadLine();
                        answer.ToLower();
                        if (answer == "ime" || answer == "prezime" || answer == "adresa" || answer == "broj")
                        {
                            ChangingAUserInformation(accountBook, answer);
                            WriteOutContactBook(accountBook);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Unesite broj osobe koju zelite izbrisati");
                        firstNumber = Console.ReadLine();
                        Console.WriteLine("Unesite opet isti broj za potvrdu");
                        secondNumber = Console.ReadLine();
                        if (firstNumber != secondNumber)
                            break;
                        if (!accountBook.ContainsKey(firstNumber))
                        {
                            Console.WriteLine("Takav broj ne postoji u imeniku");
                            break;
                        }
                        ErasingAUser(accountBook, firstNumber);
                        WriteOutContactBook(accountBook);
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            } while (choice < 6);
        }

        static void WriteOutContactBook(Dictionary<string, string[]> accountBook)
        {
            foreach (var kvp in accountBook)
            {
                Console.WriteLine("Broj {0}, Osoba {1}", kvp.Key, kvp.Value);
            }
        }
        static Dictionary<string, string[]> AddingANewContact(Dictionary<string, string[]> accountBook, string[] input)
        {
            var number = input[3];

            string[] information = new string[3] { input[0], input[1], input[2] };

            if (!accountBook.ContainsKey(number))
            {
                accountBook.Add(number, information);
            }

            return accountBook;
        }

        static Dictionary<string, string[]> ErasingAUser(Dictionary<string, string[]> accountBook, string number)
        {
            accountBook.Remove(number);

            return accountBook;
        }

        static Dictionary<string, string[]> ChangingAUserInformation(Dictionary<string, string[]> accountBook, string inf)
        {
            if (inf== "ime")
            {

            }
            if (inf == "prezime")
            {

            }
            if (inf == "adresa")
            {

            }
            if (inf == "broj")
            {

            }
            return accountBook;
        }

        
    }
}
