using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWeek3Less21
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("Podaj swoje imię");
                //var name = Console.ReadLine();
                //Console.WriteLine("Podaj rok urodzenia");
                //var yearBirth = GetInput(DateTime.Now.Year - 5);
                //Console.WriteLine("Podaj miesiąc urodzenia");
                //var monthBirth = GetInput(12);
                //Console.WriteLine("Podaj dzień urodzenia");
                //var maxDay = GetMaxDay(monthBirth, yearBirth);
                //var dayBirth = GetInput(maxDay);
                //DateTime dtBirth;
                //if (!DateTime.TryParse($"{yearBirth}-{monthBirth}-{dayBirth}", out dtBirth))
                //    throw new Exception("Wprowadziłeś błędne dane");
                //Console.WriteLine("Podaj miejsce urodzenia");
                //var city = Console.ReadLine();
                //var yearsOld = YearsBetweenDates(dtBirth, DateTime.Today);
                //var yearsOld2 = YearsBetweenDates(dtBirth);
                //string info = $"Cześć {name}, urodziłeś się w miejscowości {city} dnia {dtBirth.ToShortDateString()}. Masz lat {yearsOld}( {yearsOld2})\nBył(a) to: {dtBirth.DayOfWeek}";
                //Console.WriteLine(info);

                //Console.WriteLine($"Wylosowałem właśnie liczę z zakresu 0-100, spróbuj ją odgadnąć.");
                //var randNum = RandomNumber();
                //CheckIsCorectNumber(randNum);

                while (true)
                {
                    Console.WriteLine($"Podaj dowolną liczbę całkowitą, w odpowiedzi otrzymasz informację czy jest parzysta.\nNaciśnij literę 'T' aby zamknąć.\n");
                    var num = GetInput(int.MaxValue, int.MinValue, true);
                    Console.WriteLine($"Podana przez Ciebie liczna jest {IsEven(num)}\n\n");
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Naciśnij dowolny klawisz aby zamknąć");
                Console.ReadKey();
            }
        }

        private static string IsEven (int num)
        {
            var info = "nieparzysta";
            if (num % 2 == 0)
                info = "parzysta"; ;
            return info;
        }

        private static bool IsDivedWith0(int num, int divByNum)
        {
            var fl = false;
            if (num % divByNum == 0)
                fl = true;
            return fl;
        }

        private static int RandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100);
        }

        private static void CheckIsCorectNumber(int numberRnd)
        {
            int num, min = 0, max = 100, count = 0;
            do
            {
                count++;
                var odp = $"Podałeś prawidłową liczbę w {count} próbach.";
                Console.WriteLine($"Podaj liczbę z zakresu {min}-{max}");
                num = GetInput(max, min);
                if (numberRnd > num)
                {
                    odp = "Podałeś za małą liczbę";
                    min = num + 1;
                }
                else if (numberRnd < num)
                {
                    odp = "Podałeś za dużą liczbę";
                    max = num - 1;
                }
                Console.WriteLine(odp);
            } while (numberRnd != num);
        }

        private static int YearsBetweenDates(DateTime dtBirth)
        {
            var years = DateTime.Now.Year - dtBirth.Year;
            if (DateTime.Now.DayOfYear < dtBirth.DayOfYear)
                years = years - 1;
            return years;
        }
        
        private static int YearsBetweenDates(DateTime start, DateTime end)
        {
            DateTime tmp = start;
            int years = -1;
            while (tmp <= end)
            {
                years++;
                tmp = tmp.AddYears(1);
            }
            return years;
        }

        private static int GetMaxDay(int month, int year)
        {
            if (month == 12)
                return 30;
            DateTime dt = new DateTime(year, month + 1, 1);
            dt = dt.AddDays(-1);
            return dt.Day;
        }

        private static int GetInput(int maxNum, int minNum = 1, bool withCloseByT = false)
        {
            while (true)
            {
                var userStr = Console.ReadLine();
                if (userStr.ToUpper() == "T" && withCloseByT)
                    throw new Exception ("Nastąpi wyjście z aplikacji");
                if (!int.TryParse(userStr, out int number) || number > maxNum || number < minNum)
                {
                    Console.WriteLine("Wprowadziłeś błędne dane\nSpróbuj ponownie.");
                    continue;
                }
                return number;
            }
            
        }
    }
}
