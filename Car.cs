using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjektSalonSamochodowy
{
    internal class Car : Vechicle
    {
        private readonly string filePath = @"CarsDataBase.txt";
        private string dataToFile = string.Empty;
        private string Type = "-brak danych-";
        public Car() { }
        private string SetVechicleProperties()
        {
            Console.Write("Podaj markę: ");
            Brand = Console.ReadLine();

            Console.Write("Podaj model: ");
            Model = Console.ReadLine();

            Console.Write("Podaj rocznik: ");
            Year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj kolor: ");
            Color = Console.ReadLine();

            Console.Write("Podaj rodzaj paliwa: ");
            Fuel = Console.ReadLine();

            Console.Write("Podaj przebieg [km]: ");
            MileAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj moc silnika [kW]: ");
            HorsePower = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj typ auta [Kombi/Sedan itd.]: ");
            Type = Console.ReadLine();

            Console.Write("Podaj cenę pojazdu [PLN]: ");
            Price = Convert.ToSingle(Console.ReadLine());

            Console.Write("Podaj numer rejestracyjny: ");
            RegNumber = Console.ReadLine();

            dataToFile = "Marka: " + Brand + ", Model: " + Model + ", Rocznik: " + Year + ", Kolor: " + Color + ", Paliwo: " + Fuel + ", Przebieg: " + MileAge + " [km], Moc silnika: " + HorsePower + " [kW], Typ auta: " + Type + ", Cena pojazdu: " + Price + " PLN" + ", Numer rejestracyjny: " + RegNumber;
            return dataToFile;
        }
        public override void AddVechicle()
        {
            Console.WriteLine("DODAWANIE NOWEGO SAMOCHODU DO BAZY!");
            dataToFile = SetVechicleProperties();

            StreamWriter saveToFile;
            //plik zostal utworzony
            if (!File.Exists(filePath)) saveToFile = File.CreateText(filePath);
            //plik zostal otwarty
            else saveToFile = new StreamWriter(filePath, true);

            saveToFile.WriteLine(dataToFile);
            saveToFile.Close();

            Console.WriteLine("\nPomyślnie dodano nowy samochód.\n");
            Console.WriteLine("Kliknij <<ENTER>> aby kontynuować");
            Console.ReadKey();
        }
        public override void ShowVechicles()
        {
            Console.WriteLine("WYŚWIETLANIE SAMOCHODÓW Z BAZY!");
            
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
        public override void UpdateVechicle()
        {
            Console.WriteLine("AKTUALIZACJA SAMOCHODU W BAZIE!");
            
            if (!File.Exists(filePath)) Console.WriteLine("\nPodany plik nie istnieje! Skontaktuj się z Administratorem!");
            else
            {
                var lines = File.ReadAllLines(filePath);
                if (!lines.Any()) Console.WriteLine("\nBrak jakichkolwiek danych do aktualizacji w bazie!");
                else
                {
                    //stworzenie kontenera na dane z pliku - do modyfikacji
                    List<string> list = new List<string>();

                    //dodanie poszczegolnej lini z pliku do listy
                    foreach (string data in lines) list.Add(data);

                    //wyswietlenie listy tak aby uzytkownik mail podglad co jest w danym pliku
                    int i = 1;
                    Console.WriteLine("0. <<Powrót>>");
                    foreach (string data in list)
                    {
                        Console.WriteLine($"{i}. {data}");
                        i++;
                    }

                    Console.Write("\nWybierz pojazd do aktualizacji: ");
                    int choise = Convert.ToInt32(Console.ReadLine());

                    if (choise == 0) return;
                    //usuniecie wybranych danych z listy
                    int j = 1;
                    bool updateData = false;
                    //zamiana lini w liscie
                    foreach (string data in lines)
                    {
                        if (j == choise)
                        {
                            Console.WriteLine($"\nAktualizowana linia {j}: \n{data}");
                            Console.WriteLine("\nNowe wartości: ");
                            dataToFile = SetVechicleProperties();
                            list.Insert(j, dataToFile);
                            list.Remove(data);
                            updateData = true;
                        }
                        j++;
                    }
                    //komunikat po kasowaniu
                    if (updateData == true) Console.WriteLine("\nAktualizowanie danych samochodu wykonane pomyślnie!");
                    else Console.WriteLine("\nNie można odnaleść takich danych!");
                    //zapisanie danych z listy do pliku po aktualizacji lini
                    StreamWriter saveToFile;

                    saveToFile = new StreamWriter(filePath);

                    foreach (string data in list) saveToFile.WriteLine(data);

                    saveToFile.Close();
                }
            }
            Console.WriteLine("\nKliknij <<ENTER>> aby kontynuować");
            Console.ReadKey();
        }
        public override void RemoveVechicle()
        {
            Console.WriteLine("USUWANIE SAMOCHODU Z BAZY!");

            //zaladowanie wszystkich lini z pliku
            if (!File.Exists(filePath)) Console.WriteLine("\nPodany plik nie istnieje! Skontaktuj się z Administratorem!");
            else
            {
                var lines = File.ReadAllLines(filePath);
                if (!lines.Any()) Console.WriteLine("\nBrak jakichkolwiek danych do usunięcia w bazie!");
                else
                {
                    //stworzenie kontenera na dane
                    List<string> list = new List<string>();

                    //dodanie poszczegolnej lini z pliku do listy
                    foreach (string data in lines) list.Add(data);

                    //wyswietlenie listy w ktorej sa zapisane linie z pliku txt
                    int i = 1;
                    Console.WriteLine("0. <<Powrót>>");
                    foreach (string data in list)
                    {
                        Console.WriteLine($"{i}. {data}");
                        i++;
                    }

                    Console.Write("\nWybierz samochód do usunięcia z bazy: ");
                    int choise = Convert.ToInt32(Console.ReadLine());

                    //jezeli wybor = 0 to konczy dzialanie funkcji
                    if (choise == 0) return;
                    //usuniecie wybranych danych z listy
                    int j = 1;
                    bool deleteData = false;
                    foreach (string data in lines)
                    {
                        //Console.WriteLine(i);//sprawdzenie
                        if (j == choise)
                        {
                            list.Remove(data);
                            deleteData = true;
                            Console.WriteLine($"\nSkasowana linia {j}: \n{data}");
                        }
                        j++;
                    }
                    //komunikat po kasowaniu
                    if (deleteData == true) Console.WriteLine("\nKasowanie samochodu wykonane pomyślnie!");
                    else Console.WriteLine("\nNie można odnaleść takich danych!");
                    /*wyswietlenie danych po kasowaniu - test
                    foreach(string data in list) Console.WriteLine(data); */

                    //zapisanie danych z listy po kasowaniu do pliku
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