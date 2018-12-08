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
                        input[3] = input[3].Replace(" ", "");
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
                        firstNumber = firstNumber.Replace(" ", "");
                        Console.WriteLine("Unesite opet isti broj za potvrdu");
                        secondNumber = Console.ReadLine();
                        secondNumber = secondNumber.Replace(" ", "");
                        if (firstNumber != secondNumber)
                            break;
                        string answer, change;
                        do
                        {
                            Console.WriteLine("Unesite je li zelite mijenjati ime, prezime, adresu ili broj");
                            answer = Console.ReadLine();
                            answer.ToLower();
                        } while (answer != "ime" && answer != "prezime" && answer != "adresa" && answer != "broj");
                        
                        Console.WriteLine("Unesite novu vrijednost");
                        change = Console.ReadLine();
                        if (answer == "ime" || answer == "prezime" || answer == "adresa" || answer == "broj")
                        {
                            ChangingAUserInformation(accountBook, answer, change, firstNumber);
                            WriteOutContactBook(accountBook);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Unesite broj osobe koju zelite izbrisati");
                        firstNumber = Console.ReadLine();
                        firstNumber = firstNumber.Replace(" ", "");
                        Console.WriteLine("Unesite opet isti broj za potvrdu");
                        secondNumber = Console.ReadLine();
                        secondNumber = secondNumber.Replace(" ", "");
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
                        Console.WriteLine("Unesite broj koji zelite da vam se ispise");
                        firstNumber = Console.ReadLine();
                        firstNumber = firstNumber.Replace(" ", "");
                        FindingASpecificOne(accountBook, firstNumber);
                        break;
                    case 5:
                        string choosingName;
                        do
                        {
                            Console.WriteLine("Unesi hoces li traziti po imenu ili prezimenu ( upisi 'ime' ili 'prezime')");
                            choosingName = Console.ReadLine().ToLower();
                        } while (choosingName != "ime" && choosingName != "prezime");
                        Console.WriteLine("Unesi koja imena/prezimena treba traziti");
                        var name = Console.ReadLine();
                        AllWithCertainName(accountBook, name, choosingName);
                        break;
                }
            } while (choice < 6);
        }

        //Used to output the whole dictionary to the user
        static void WriteOutContactBook(Dictionary<string, string[]> accountBook)
        {
            string[] info;
            foreach (var kvp in accountBook)
            {
                info = kvp.Value;
                Console.WriteLine("Broj {0}, Osoba {1} {2} {3}", kvp.Key, info[0], info[1], info[2]);
            }
        }

        //adds a new contact to the dictionary
        static void AddingANewContact(Dictionary<string, string[]> accountBook, string[] input)
        {
            var number = input[3];

            string[] information = new string[3] { input[0], input[1], input[2] };

            if (!accountBook.ContainsKey(number))
            {
                accountBook.Add(number, information);
            }
        }

        //erases a contact from the dictionary
        static void ErasingAUser(Dictionary<string, string[]> accountBook, string number)
        {
            accountBook.Remove(number);
        }

        //changes something about a certain contact in the dictionary
        static void ChangingAUserInformation(Dictionary<string, string[]> accountBook, string keyword, string newInfo, string number)
        {
            string[] information = new string[4];

            if (keyword == "ime")
            {
                foreach (var kvp in accountBook)
                {
                    if (kvp.Key == number)
                    {
                        information = kvp.Value;
                        information[0] = newInfo;
                    }
                }
                accountBook[number] = information;
            }
            else if (keyword == "prezime")
            {
                foreach (var kvp in accountBook)
                {
                    if (kvp.Key == number)
                    {
                        information = kvp.Value;
                        information[1] = newInfo;
                    }
                }
                accountBook[number] = information;
            }
            else if (keyword == "adresa")
            {
                foreach (var kvp in accountBook)
                {
                    if (kvp.Key == number)
                    {
                        information = kvp.Value;
                        information[2] = newInfo;
                    }
                }
                accountBook[number] = information;
            }
            else if (keyword == "broj")
            {
                foreach (var kvp in accountBook)
                {
                    if (kvp.Key == number)
                    {
                        information = kvp.Value;
                    }
                }
                information[3] = newInfo;
                
                ErasingAUser(accountBook, number);
                AddingANewContact(accountBook, information);
            }
            else
                Console.WriteLine("Taj broj ne postoji");
        }

        //finding a user with a specific number
        static void FindingASpecificOne(Dictionary<string, string[]> accountBook, string number)
        {
            foreach (var i in accountBook)
            {
                string[] info = i.Value;

                if(i.Key == number)
                    Console.WriteLine("Broj {0} Osobe {1} {2} {3}", i.Key, info[0], info[1], info[2]); 
            }
        }

        //finding everyone who's name or last name starts with a certain string
        static void AllWithCertainName(Dictionary<string, string[]> accountBook, string name, string choosing)
        {
            var listOfNumbers = new List<string>();
            var lenght = name.Length;
            if (choosing == "ime")
            {
                foreach (var i in accountBook)
                {
                    string[] info = i.Value;
                    string checking = "";
                    for (int j = 0; j < lenght; j++)
                    {
                        checking += info[0][j];
                    }
                    if(checking == name)
                        Console.WriteLine("Broj {0} Osobe {1} {2} {3}", i.Key, info[0], info[1], info[2]);
                }
            }
            else
            {
                foreach (var i in accountBook)
                {
                    string[] info = i.Value;
                    string checking = "";
                    if (info[1].Length >= lenght)
                    {
                        for (int j = 0; j < lenght; j++)
                        {
                            checking += info[1][j];
                        }
                        if (checking == name)
                            Console.WriteLine("Broj {0} Osobe {1} {2} {3}", i.Key, info[0], info[1], info[2]);
                    }
                }
            }
        }
        
    }
}
