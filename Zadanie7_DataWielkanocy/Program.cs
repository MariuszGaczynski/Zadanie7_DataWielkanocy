using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie7_DataWielkanocy
{
    class Program
    {


   
        static void Main(string[] args)
        {

            //szyld graficzny
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#");
            Console.WriteLine("#X#X#X#X#X#                                             #X#X#X#X#X#X#X#");
            Console.WriteLine("#X#X#X#X#X#    When is Easter Sunday ??? - Calculator   #X#X#X#X#X#X#X#");
            Console.WriteLine("#X#X#X#X#X#                                             #X#X#X#X#X#X#X#");
            Console.WriteLine("#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#\n\n");
            Console.ResetColor();

            // powitanie, wytłumaczenie

            Console.WriteLine("  In Western Christianity, using the Gregorian calendar, Easter always\n" +
                "  falls on a Sunday between 22 March and 25 April, within seven days\n"  +
                "  after the astronomical full moon\n");

            // pytanie o rok do sprawdzenia
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" When is Easter Sunday ??? - Calculator ");
            Console.ResetColor();
            Console.WriteLine(" can easily calculate specific date\nof Easter Sunday for given year.\n");
        OnceAgain1:
            Restart:
            Console.WriteLine("\nYou can choose a year from 1582 (when Gregorian Calendar" +
                " was ntroduced\nby Pope Gregory III) up to a half of the third millenium (which is 2499).");
            Console.Write("\n\t\tType a year to check : ...  ");
            bool isParsable = Int32.TryParse(Console.ReadLine(), out int givenYear);
            if (isParsable && givenYear>=1582 && givenYear<2500)
            {

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\t\tIncorrect year input. Try again.\t\t\t\n");
                Console.ResetColor();
                goto OnceAgain1;
            }

            // zastosowanie metody wyliczjącej date i wyświetlenie wyniku
            
            DateTime dateOfEasterSunday = WnenIsEaster(givenYear); // data w formacie DateTime szukanej wielkanocy


            string monthOfEasterSunday = dateOfEasterSunday.Month == 3 ? "March" : "April"; // nazwa miesiąca

            string dayOfEasterSunday;  // liczebnik porządkowy dnia
            if (dateOfEasterSunday.Day == 1|| dateOfEasterSunday.Day == 21 || dateOfEasterSunday.Day == 31 )
            {
                dayOfEasterSunday = dateOfEasterSunday.Day.ToString() + "st";
            }
            else if (dateOfEasterSunday.Day == 2 || dateOfEasterSunday.Day == 22 )
            {
                dayOfEasterSunday = dateOfEasterSunday.Day.ToString() + "nd";
            }
            else if (dateOfEasterSunday.Day == 3 || dateOfEasterSunday.Day == 23)
            {
                dayOfEasterSunday = dateOfEasterSunday.Day.ToString() + "rd";
            }
            else if (dateOfEasterSunday.Day == 20 || dateOfEasterSunday.Day == 30)
            {
                dayOfEasterSunday = dateOfEasterSunday.Day.ToString() + "ieth";
            }
            else
            {
                dayOfEasterSunday = dateOfEasterSunday.Day.ToString() + "th";
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("\t\tIn year {0} Easter Sunday fall on {1} of {2}.",
                dateOfEasterSunday.Year, dayOfEasterSunday, monthOfEasterSunday);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------------------------------------------------------------------------\n");
            Console.ResetColor();

            // restart
            Console.Write("Would you like to check another year ? (Y)es or (N)o ? ...");
            OnceAgain2:
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                goto Restart;
            }
            else if (answer == "n")
            {

            }
            else
            {
                Console.Write("Press 'Y' for another check or press 'N' to exit : ... ");
                goto OnceAgain2;
            }

            // pożegnanie
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\n\n#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#\n");
            Console.ResetColor();
            Console.Write("    Thank you for using ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" When is Easter Sunday ??? - Calculator ");
            Console.ResetColor();
            Console.WriteLine(" !!!");
            Console.WriteLine("\n\t\t\t    Have a good day !");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#X#\n\n");
            Console.ResetColor();



            Console.ReadKey();
        }


        static DateTime WnenIsEaster (int givenYear)  // metoda obliczania daty wielkanocy według algorytu gaussa
        {
            // tabela do metody gaussa
            //Zakres lat     A B
            //- 1582	    15	6
            //1583 - 1699	22	2
            //1700 - 1799	23	3
            //1800 - 1899	23	4
            //1900 - 2099	24	5
            //2100 - 2199	24	6
            //2200 - 2299	25	0
            //2300 - 2399	26	1
            //2400 - 2499	25	1
            int A= 0;
            int B = 0;

            if (givenYear <= 1582 )
            {
                A = 15;
                B = 6;
            }
            if (givenYear >= 1583 && givenYear <= 1699)
            {
                A = 22;
                B = 2;
            }
            if (givenYear >= 1700 && givenYear <= 1799)
            {
                A = 23;
                B = 3;
            }
            if (givenYear >= 1800 && givenYear <= 1899)
            {
                A = 23;
                B = 4;
            }
            if (givenYear >= 1900 && givenYear <= 2099)
            {
                A = 24;
                B = 5;
            }
            if (givenYear >= 2100 && givenYear <= 2199)
            {
                A = 24;
                B = 6;
            }
            if (givenYear >= 2200 && givenYear <= 2299)
            {
                A = 25;
                B = 0;
            }
            if (givenYear >= 2300 && givenYear <= 2399)
            {
                A = 26;
                B = 1;
            }
            if (givenYear >= 2400 && givenYear <= 2499)
            {
                A = 25;
                B = 1;
            }


            int a = givenYear % 19;
            int b = givenYear % 4;
            int c = givenYear % 7;
            int d = ((a * 19) + A) % 30;
            int e = ((2 * b) + (4 * c) + (6 * d) + B) % 7;
            int f = 22 + d + e;
            int month = 3;
                        
            if ((d == 29 && e ==6) || (d == 28 && e == 6))  // dwa warunki szczególne
            {
                month = 4;
                f -= 7;
            }
            else if (f > 31) // warunek zmiany miesiąca na kwiecień (tylko jak nie zaszedł ten poprzedni)
            {
                month = 4;
                f -= 31;
            }

            DateTime easterSunday = new DateTime(givenYear, month, f);
           
            return easterSunday;
        }


                //   Algorytm gaussa na dzien Wielkiej Nocy

                //    a = rok mod 19
                //    b = rok mod 4
                //    c = rok mod 7
                //    d = (a*19 + A) mod 30
                //    e = (2b + 4c + 6d + B) mod 7
                //    wielkanoc = 22 marzec + d + e
                //Zatem suma zmiennych d oraz e oznacza ile dni po 22 marca przypada wielkanoc.
                //dla podanej metody mamy dwa wyjątki:
                //    jeżeli d = 29 oraz e = 6 to Wielkanoc miałaby przypaść na dzień 26 kwietnia.Wtedy zawsze obchodzi się ją tydzień wcześniej, tzn. 19 kwietnia
                //   jeżeli d = 28 oraz e = 6 to Wielkanoc miałaby przypaść 25 kwietnia.Wtedy zawsze obchodzi się ją tydzień wcześniej, tzn. 18 kwietnia
                //Do obliczeń potrzebne są dwie liczby A i B  z tabelki 
                

                

    }
}
