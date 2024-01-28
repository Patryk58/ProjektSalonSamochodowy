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
    internal class Leasing : Agreement
    {
        private readonly string filePath = @"LeasingsDataBase.txt";
        private string dataToFile = string.Empty;
        private string PeriodLeasing = "-brak danych-";
        private int RepaymentPrice = 0;
        public Leasing() { }
        private string SetAgreementProperties()
        {
            Console.Write("Podaj datę zawarcia umowy [dd.mm.yyyy]: ");
            DateConclusion = Console.ReadLine();

            Console.Write("Podaj numer umowy: ");
            ContractNumber = Console.ReadLine();

            Console.Write("Podaj numer rejestracyjny pojazdu: ");
            VechicleRegNumber = Console.ReadLine();

            Console.Write("Podaj okres leasingu: ");
            PeriodLeasing = Console.ReadLine();

            Console.Write("Podaj cenę spłaty: ");
            RepaymentPrice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj imię i nazwisko klienta: ");
            NameSurnameClient = Console.ReadLine();

            Console.Write("Podaj imię i nazwisko pracownika: ");
            NameSurnameEmployee = Console.ReadLine();

            dataToFile = "Data zawarcia umowy: " + DateConclusion + ", Numer umowy: " + ContractNumber + ", Numer rejestracyjny pojazdu: " + VechicleRegNumber + ", Okres leasingu: " + PeriodLeasing + ", Cena spłaty: " + RepaymentPrice + ", Imię i nazwisko klienta:" + NameSurnameClient + ", Imię i nazwisko pracownika" + NameSurnameEmployee;
            return dataToFile;
        }
        public override void AddAgreement()
        {
            Console.WriteLine("DODAWANIE NOWEJ UMOWY LEASINGU DO BAZY!");
            dataToFile = SetAgreementProperties();

            StreamWriter saveToFile;

            if (!File.Exists(filePath)) saveToFile = File.CreateText(filePath);

            else saveToFile = new StreamWriter(filePath, true);

            saveToFile.WriteLine(dataToFile);
            saveToFile.Close();

            Console.WriteLine("\nPomyślnie dodano nową umowę leasingu.\n");
            Console.WriteLine("Kliknij <<ENTER>> aby kontynuować");
            Console.ReadKey();
        }
        public override void ShowAgreements()
        {
            Console.WriteLine("WYŚWIETLANIE UMÓW LEASINGOWYCH Z BAZY!");

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
        public override void UpdateAgreement()
        {
            Console.WriteLine("AKTUALIZACJA UMOWY LEASINGU W BAZIE!");

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

                    Console.Write("\nWybierz umowę leasingu do aktualizacji: ");
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
                            dataToFile = SetAgreementProperties();
                            list.Insert(j, dataToFile);
                            list.Remove(data);
                            updateData = true;
                        }
                        j++;
                    }
                    if (updateData == true) Console.WriteLine("\nAktualizowanie danych umowy leasingowej wykonane pomyślnie!");
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
        public override void RemoveAgreement()
        {
            Console.WriteLine("USUWANIE UMOWY LEASINGOWEJ Z BAZY!");

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

                    Console.Write("\nWybierz umowę leasingu do usunięcia z bazy: ");
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
                    if (deleteData == true) Console.WriteLine("\nKasowanie umowy leasingowej wykonane pomyślnie!");
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