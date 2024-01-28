using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSalonSamochodowy
{
    internal class Client : Person
    {
        private readonly string filePath = @"ClientsDataBase.txt";
        private string dataToFile = string.Empty;
        public Client() { }
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

            dataToFile = "Imię: " + FirstName + ", Nazwisko: " + LastName + ", Adres zamieszkania: " + Address + ", Numer telefonu: " + PhoneNumber + ", Adres Email: " + Email;
            return dataToFile;
        }
        public override void AddPerson()
        {
            Console.WriteLine("DODAWANIE NOWEGO KLIENTA DO BAZY!");
            dataToFile = SetPersonProperties();

            StreamWriter saveToFile;
            
            if (!File.Exists(filePath)) saveToFile = File.CreateText(filePath);
            
            else saveToFile = new StreamWriter(filePath, true);

            saveToFile.WriteLine(dataToFile);
            saveToFile.Close();

            Console.WriteLine("\nPomyślnie dodano nowego klienta.\n");
            Console.WriteLine("Kliknij <<ENTER>> aby kontynuować");
            Console.ReadKey();
        }
        public override void ShowPersons()
        {
            Console.WriteLine("WYŚWIETLANIE KLIENTÓW Z BAZY!");

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
            Console.WriteLine("AKTUALIZACJA KLIENTA W BAZIE!");

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

                    Console.Write("\nWybierz klienta do aktualizacji: ");
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
                    if (updateData == true) Console.WriteLine("\nAktualizowanie danych klienta wykonane pomyślnie!");
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
            Console.WriteLine("USUWANIE KLIENTA Z BAZY!");

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

                    Console.Write("\nWybierz klienta do usunięcia z bazy: ");
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

                    if (deleteData == true) Console.WriteLine("\nKasowanie klienta wykonane pomyślnie!");

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