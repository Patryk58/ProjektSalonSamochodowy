namespace ProjektSalonSamochodowy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Projekt Salon Samochodowy wykonany przez Patryk Chajec w68463";
            Vechicle car = new Car();
            Vechicle deliveryvan = new DeliveryVan();
            Person client = new Client();
            Person employee = new Employee();
            Agreement sales = new Sale();
            Agreement leasing = new Leasing();

            string choiseMenu = string.Empty;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu Wyboru");
                Console.WriteLine("0. <<Wyjście z programu>>");
                Console.WriteLine("1. Pojazdy");
                Console.WriteLine("2. Klienci/Pracownicy");
                Console.WriteLine("3. Umowy");
                Console.Write("Podaj wartość: ");

                choiseMenu = Console.ReadLine();

                switch(choiseMenu) 
                {
                    case "0": Environment.Exit(0); break;
                    case "1": Console.Clear(); VechicleMenu(); break;
                    case "2": Console.Clear(); PersonMenu(); break;
                    case "3": Console.Clear(); AgreementMenu(); break;
                    default: Console.WriteLine("\nNiepoprawna wartość\nKliknij <<ENTER>> aby kontynuować"); Console.ReadKey(); break;
                }
            }

            void VechicleMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("MENU POJAZDÓW");
                    Console.WriteLine("0. <<Powrót>>");
                    Console.WriteLine("SAMOCHODY OSOBOWE");
                    Console.WriteLine("1. Dodanie nowego samochodu osobowego");
                    Console.WriteLine("2. Wyświetlanie wszystkich samochodów osobowych");
                    Console.WriteLine("3. Aktualizacja danych samochodu osobowego");
                    Console.WriteLine("4. Usunięcie samochodu osobowego");
                    Console.WriteLine("SAMOCHODY DOSTAWCZE");
                    Console.WriteLine("5. Dodanie nowego samochodu dostawczego");
                    Console.WriteLine("6. Wyświetlanie wszystkich samochodów dostawczych");
                    Console.WriteLine("7. Aktualizacja danych samochodu dostawczego");
                    Console.WriteLine("8. Usunięcie samochodu dostawczego");
                    Console.Write("Podaj wartość: ");

                    choiseMenu = Console.ReadLine();

                    switch (choiseMenu)
                    {
                        case "0": return;
                        case "1": Console.Clear(); car.AddVechicle(); break;
                        case "2": Console.Clear(); car.ShowVechicles(); break;
                        case "3": Console.Clear(); car.UpdateVechicle(); break;
                        case "4": Console.Clear(); car.RemoveVechicle(); break;
                        case "5": Console.Clear(); deliveryvan.AddVechicle(); break;
                        case "6": Console.Clear(); deliveryvan.ShowVechicles(); break;
                        case "7": Console.Clear(); deliveryvan.UpdateVechicle(); break;
                        case "8": Console.Clear(); deliveryvan.RemoveVechicle(); break;
                        default: Console.WriteLine("\nNiepoprawna wartość\nKliknij <<ENTER>> aby kontynuować"); Console.ReadKey(); break;
                    }
                }
            }
            void PersonMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("MENU KLIENTÓW I PRACOWNIKÓW");
                    Console.WriteLine("0. <<Powrót>>");
                    Console.WriteLine("KLIENCI");
                    Console.WriteLine("1. Dodanie nowego klienta");
                    Console.WriteLine("2. Wyświetlanie wszystkich klientów");
                    Console.WriteLine("3. Aktualizacja danych klienta");
                    Console.WriteLine("4. Usunięcie klienta");
                    Console.WriteLine("PRACOWNICY");
                    Console.WriteLine("5. Dodanie nowego pracownika");
                    Console.WriteLine("6. Wyświetlanie wszystkich pracowników");
                    Console.WriteLine("7. Aktualizacja danych pracownika");
                    Console.WriteLine("8. Usunięcie pracownika");
                    Console.Write("Podaj wartość: ");

                    choiseMenu = Console.ReadLine();

                    switch (choiseMenu)
                    {
                        case "0": return;
                        case "1": Console.Clear(); client.AddPerson(); break;
                        case "2": Console.Clear(); client.ShowPersons(); break;
                        case "3": Console.Clear(); client.UpdatePerson(); break;
                        case "4": Console.Clear(); client.RemovePerson(); break;
                        case "5": Console.Clear(); employee.AddPerson(); break;
                        case "6": Console.Clear(); employee.ShowPersons(); break;
                        case "7": Console.Clear(); employee.UpdatePerson(); break;
                        case "8": Console.Clear(); employee.RemovePerson(); break;
                        default: Console.WriteLine("\nNiepoprawna wartość\nKliknij <<ENTER>> aby kontynuować"); Console.ReadKey(); break;
                    }
                }
            }
            void AgreementMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("MENU DOKUMENTÓW");
                    Console.WriteLine("0. <<Powrót>>");
                    Console.WriteLine("UMOWA SPRZEDAŻY");
                    Console.WriteLine("1. Dodanie nowej umowy sprzedaży");
                    Console.WriteLine("2. Wyświetlanie wszystkich umów sprzedaży");
                    Console.WriteLine("3. Aktualizacja umowy sprzedaży");
                    Console.WriteLine("4. Usunięcie umowy sprzedaży");
                    Console.WriteLine("UMOWA LEASINGU");
                    Console.WriteLine("5. Dodanie nowej umowy leasingu");
                    Console.WriteLine("6. Wyświetlanie wszystkich umów leasingu");
                    Console.WriteLine("7. Aktualizacja danych umowy leasingu");
                    Console.WriteLine("8. Usunięcie umowy leasingu");
                    Console.Write("Podaj wartość: ");

                    choiseMenu = Console.ReadLine();
                    
                    switch (choiseMenu)
                    {
                        case "0": return;
                        case "1": Console.Clear(); sales.AddAgreement(); break;
                        case "2": Console.Clear(); sales.ShowAgreements(); break;
                        case "3": Console.Clear(); sales.UpdateAgreement(); break;
                        case "4": Console.Clear(); sales.RemoveAgreement(); break;
                        case "5": Console.Clear(); leasing.AddAgreement(); break;
                        case "6": Console.Clear(); leasing.ShowAgreements(); break;
                        case "7": Console.Clear(); leasing.UpdateAgreement(); break;
                        case "8": Console.Clear(); leasing.RemoveAgreement(); break;
                        default: Console.WriteLine("\nNiepoprawna wartość\nKliknij <<ENTER>> aby kontynuować"); Console.ReadKey(); break;
                    }
                }
            }
        }
    }
}