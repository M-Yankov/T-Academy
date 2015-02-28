/*Problem 19. Dates from text in Canada

    Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
    Display them in the standard date format for Canada.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;


    class Canada
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-CA"); // English Canada . There are another time - French(Canada)
            string testDate = Console.ReadLine();

            Regex rgx = new Regex(@"\d{2}.\d{2}.\d{4}");
            Regex tupotioq = new Regex(@"\d{1}.\d{1}.\d{4}");
            Regex tupotioq1 = new Regex(@"\d{2}.\d{1}.\d{4}");
            
            
            MatchCollection mat = rgx.Matches(testDate);
            MatchCollection newmat = tupotioq.Matches(testDate);
            MatchCollection newmat1 = tupotioq1.Matches(testDate);
            

            Show(mat);
            Show(newmat);
            Show(newmat1);
            

            
            
           

        }
       static void Show(MatchCollection coll)
        {
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
        }
    }
