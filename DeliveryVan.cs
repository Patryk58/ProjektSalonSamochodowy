using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSalonSamochodowy
{
    internal class DeliveryVan : Vechicle
    {
        private readonly string filePath = @"DeliveryVansDataBase.txt";
        private string dataToFile = string.Empty;
        private float PermissibleWeight = 0f;
        public DeliveryVan() { }
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
            
            Console.Write("Podaj dopuszczalną wagę [T]: ");
            PermissibleWeight = Convert.ToSingle(Console.ReadLine());

            Console.Write("Podaj cenę pojazdu [PLN]: ");
            Price = Convert.ToSingle(Console.ReadLine());

            Console.Write("Podaj numer rejestracyjny: ");
            RegNumber = Console.ReadLine();

            dataToFile = "Marka: " + Brand + ", Model: " + Model + ", Rocznik: " + Year + ", Kolor: " + Color + ", Paliwo: " + Fuel + ", Przebieg: " + MileAge + " [km], Moc silnika: " + HorsePower + " [kW], Dopuszczalna waga: " + PermissibleWeight + " [T]" + ", Cena pojazdu: " + Price + " PLN" + ", Numer rejestracyjy : " + RegNumber;
            return dataToFile;
        }
        public override void AddVechicle()
        {
            Console.WriteLine("DODAWANIE NOWEGO SAMOCHODU DOSTAWCZEGO DO BAZY!");
            dataToFile = SetVechicleProperties();

            StreamWriter saveToFile;

            if (!File.Exists(filePath)) saveToFile = File.CreateText(filePath);

            else saveToFile = new StreamWriter(filePath, true);

            saveToFile.WriteLine(dataToFile);
            saveToFile.Close();

            Console.WriteLine("\nPomyślnie dodano nowy samochód dostawczy.\n");
            Console.WriteLine("Kliknij <<ENTER>> aby kontynuować");
            Console.ReadKey();
        }
        public override void ShowVechicles()
        {
            Console.WriteLine("WYŚWIETLANIE SAMOCHODÓW DOSTAWCZYCH Z BAZY!");

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
            Console.WriteLine("AKTUALIZACJA SAMOCHODU DOSTAWCZEGO W BAZIE!");

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

                    Console.Write("\nWybierz samochód dostawczy do aktualizacji: ");
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
                            dataToFile = SetVechicleProperties();
                            list.Insert(j, dataToFile);
                            list.Remove(data);
                            updateData = true;
                        }
                        j++;
                    }
                    if (updateData == true) Console.WriteLine("\nAktualizowanie danych samochodu dostawczego wykonane pomyślnie!");
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
        public override void RemoveVechicle()
        {
            Console.WriteLine("USUWANIE SAMOCHODU DOSTAWCZEGO Z BAZY!");

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

                    Console.Write("\nWybierz samochód dostawczy do usunięcia z bazy: ");
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
                    if (deleteData == true) Console.WriteLine("\nKasowanie samochodu dostawczego wykonane pomyślnie!");
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
    }
}