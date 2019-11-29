using MoneyMenager.Db;
using MoneyMenager.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMenager
{
    class Program
    {
        //static File _file;
        static IReader _reader;
        static IWriter _writer;
        string path = $@"d:\test.txt";
        static void Main(string[] args)
        {
            //_file = new File();
            _reader = new Reader($@"d:\database.txt");
            _writer = new Writer($@"d:\database.txt");

            string selected= "";

            do
            {
                DisplayMenu();
                RunSelected(selected);
                selected = Console.ReadLine();
                
                
            } while (selected!="6");

        }
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Lista");
            Console.WriteLine("2 - Raport miesięczny");
            Console.WriteLine("3 - Dodaj wydatek");
            Console.WriteLine("4 - Dodaj dochód");
            Console.WriteLine("5 - Usuń pozycje");
            Console.WriteLine("6 - Zakończ");
            Console.WriteLine("Wybrana opcja:");
        }

        private static void RunSelected(string selected)
        {
            switch (selected)
            {
                case "1":

                    ShowList();
                    break;
                case "2":
                    ShowRaport(); 
                    break;
                case "3":
                    AddOutcome();
                    break;
                case "4":
                    AddIncome();
                    break;
                case "5":
                    RemoveItem();
                    break;
                default:
                    break;
            }
        }
        private static void ShowList()
        {
            Console.Clear();
            //List list = new List(_file);
            List list = new List(_reader);
            Console.WriteLine("Wszystkie pozycje:");
            list.DispalList();
            Console.ReadKey();
        }
        private static void ShowRaport()
        {
            Console.Clear();

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            //Summary report = new Summary(_file);
            Summary report = new Summary(_reader);
            report.DisplayRaport(year, month);

            Console.ReadKey();

        }
        private static void AddOutcome()
        {
            Console.Clear();
            Console.WriteLine("Nowy wydatek");

            Console.WriteLine("Nazwa:");
            string name = Console.ReadLine();

            Console.WriteLine("Kwota:");
            string value = Console.ReadLine();

            decimal amount = decimal.Parse(value);

            Console.WriteLine("Data:");
            value = Console.ReadLine();
            DateTime date = DateTime.Parse(value);

            //Service service = new Service(_file, _file);
            Service service = new Service(_reader, _writer);
            service.OutOutcome(amount, name, date);


            //Console.ReadKey();


        }
        private static void AddIncome()
        {
            Console.Clear();
            Console.WriteLine("Nowy dochód");

            Console.WriteLine("Nazwa:");
            string name = Console.ReadLine();

            Console.WriteLine("Kwota:");
            string value = Console.ReadLine();

            decimal amount = decimal.Parse(value);

            Console.WriteLine("Data:");
            value = Console.ReadLine();
            DateTime date = DateTime.Parse(value);

            //Service service = new Service(_file, _file);
            Service service = new Service(_reader, _writer);
            service.AddIncome(amount, name, date);

            


            Console.ReadKey();


        }
        private static void RemoveItem()
        {
            Console.Clear();
            Console.WriteLine("Podaj Id pozycji do usuniecia");
            string value = Console.ReadLine();
            int id = int.Parse(value);

            Service service = new Service(_reader, _writer);
            service.RemoveById(id);

        }
    }
}
