using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSalonSamochodowy
{
    internal class Employee : Person
    {
        private readonly string filePath = @"EmployeesDataBase.txt";
        private string dataToFile = string.Empty;
        private string DateOfEmployment = "-brak danych-";
        private int Reward = 0;
        public Employee() { }
        private string SetPersonProperties()
        {
            Console.Write("Podaj imię: ");
            FirstName = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");
            LastName = Console.ReadLine();

            Console.Write("Podaj adres zamieszkania: ");
            Address = Console.ReadLine();

            Console.Write("Podaj numer telefonu ");
            PhoneNumber = Console.ReadLine();

            Console.Write("Podaj adres mail: ");
            Email = Console.ReadLine();

            Console.Write("Podaj datę zatrudnienia [dd.mm.yyyy]: ");
            DateOfEmployment = Console.ReadLine();

            Console.Write("Podaj wynagrodzenie: ");
            Reward = Convert.ToInt32(Console.ReadLine());

            dataToFile = "Imię: " + FirstName + ", Nazwisko: " + LastName + ", Adres zamieszkania: " + Address + ", Numer telefonu: " + PhoneNumber + ", Adres Email: " + Email + ", Data zatrudnienia: " + DateOfEmployment + ", Wynagrodzenie: " + Reward + " PLN";           
            return dataToFile;
        }
        public override void AddPerson()
        {
            Console.WriteLine("DODAWANIE NOWEGO PRACOWNIKA DO BAZY!");
            dataToFile = SetPersonProperties();

            StreamWriter saveToFile;
            
            if (!File.Exists(filePath)) saveToFile = File.CreateText(filePath);
            
            else saveToFile = new StreamWriter(filePath, true);

            saveToFile.WriteLine(dataToFile);
            saveToFile.Close();

            Console.WriteLine("\nPomyślnie dodano nowego pracownika.\n");
            Console.WriteLine("Kliknij <<ENTER>> aby kontynuować");
            Console.ReadKey();
        }
        public override void ShowPersons()
        {
            Console.WriteLine("WYŚWIETLANIE PRACOWNIKÓW Z BAZY!");

            if (!File.Exists(filePath)) Console.WriteLine("\nPodany plik nie istnieje! Skontaktuj się z Administratorem!\n");
            else
            {
                StreamReader loadFromFile1 = File.OpenText(filePath);

                if (loadFromFile1.ReadLine() == null)
                {
                    Console.WriteLine("\nNie znaleziono żądnych danych!\n");
                    loadFromFile1.Close();
                }
                else
                {
                    loadFromFile1.Close();
                    StreamReader loadFromFile2 = File.OpenText(filePath);
                    string dataGetLine;
                    int i = 1;
                    while ((dataGetLine = loadFromFile2.ReadLine()) != null)
                    {
                        Console.WriteLine(i + ". " + dataGetLine);
                        i++;
                    }
                    loadFromFile2.Close();
                    Console.WriteLine("\nPomyślnie wyświetlono dane z bazy.\n");
                }
            }
            Console.WriteLine("Kliknij <<ENTER>> aby kontynuować");
            Console.ReadKey();
        }
        public override void UpdatePerson()
        {
            Console.WriteLine("AKTUALIZACJA PRACOWNIKA W BAZIE!");

            if (!File.Exists(filePath)) Console.WriteLine("\nPodany plik nie istnieje! Skontaktuj się z Administratorem!");
            else
            {
                var lines = File.ReadAllLines(filePath);
                if (!lines.Any()) Console.WriteLine("\nBrak jakichkolwiek danych do aktualizacji w bazie!");
                else
                {
                    List<string> list = new List<string>();

                    foreach (string data in lines) list.Add(data);

                    int i = 1;
                    Console.WriteLine("0. <<Powrót>>");
                    foreach (string data in list)
                    {
                        Console.WriteLine($"{i}. {data}");
                        i++;
                    }

                    Console.Write("\nWybierz pracownika do aktualizacji: ");
                    int choise = Convert.ToInt32(Console.ReadLine());

                    if (choise == 0) return;
                    int j = 1;
                    bool updateData = false;

                    foreach (string data in lines)
                    {
                        if (j == choise)
                        {
                            Console.WriteLine($"\nAktualizowana linia {j}: \n{data}");
                            Console.WriteLine("\nNowe wartości: ");
                            dataToFile = SetPersonProperties();
                            list.Insert(j, dataToFile);
                            list.Remove(data);
                            updateData = true;
                        }
                        j++;
                    }
                    if (updateData == true) Console.WriteLine("\nAktualizowanie danych pracownika wykonane pomyślnie!");
                    else Console.WriteLine("\nNie można odnaleść takich danych!");

                    StreamWriter saveToFile;

                    saveToFile = new StreamWriter(filePath);

                    foreach (string data in list) saveToFile.WriteLine(data);

                    saveToFile.Close();
                }
            }
            Console.WriteLine("\nKliknij <<ENTER>> aby kontynuować");
            Console.ReadKey();
        }
        public override void RemovePerson()
        {
            Console.WriteLine("USUWANIE PRACOWNIKA Z BAZY!");

            if (!File.Exists(filePath)) Console.WriteLine("\nPodany plik nie istnieje! Skontaktuj się z Administratorem!");
            else
            {
                var lines = File.ReadAllLines(filePath);
                if (!lines.Any()) Console.WriteLine("\nBrak jakichkolwiek danych do usunięcia w bazie!");
                else
                {
                    List<string> list = new List<string>();

                    foreach (string data in lines) list.Add(data);

                    int i = 1;
                    Console.WriteLine("0. <<Powrót>>");
                    foreach (string data in list)
                    {
                        Console.WriteLine($"{i}. {data}");
                        i++;
                    }

                    Console.Write("\nWybierz pracownika do usunięcia z bazy: ");
                    int choise = Convert.ToInt32(Console.ReadLine());

                    if (choise == 0) return;

                    int j = 1;
                    bool deleteData = false;
                    foreach (string data in lines)
                    {
                        if (j == choise)
                        {
                            list.Remove(data);
                            deleteData = true;
                            Console.WriteLine($"\nSkasowana linia {j}: \n{data}");
                        }
                        j++;
                    }

                    if (deleteData == true) Console.WriteLine("\nKasowanie pracownika wykonane pomyślnie!");

                    StreamWriter saveToFile;

                    saveToFile = new StreamWriter(filePath);

                    foreach (string data in list) saveToFile.WriteLine(data);

                    saveToFile.Close();
                }
            }
            Console.WriteLine("\nKliknij <<ENTER>> aby kontynuować");
            Console.ReadKey();
        }
    }
}