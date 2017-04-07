using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Lesson5.HomeTask
{
    

    class Program
    {
        static string dataPath = @"d:\timestamps.txt";

        static void Main(string[] args)
        {
            CreateSampleFile();

            var JulyWeekends = from line in File.ReadLines(dataPath)
                               where (line.StartsWith("Суббота") ||
                               line.StartsWith("воскресенье")) &
                               line.Contains("июля")
                               select line;

            File.WriteAllLines(@"d:\selectedDays.txt", JulyWeekends);

            var MarchMondays = from line in File.ReadLines(dataPath)
                               where line.StartsWith("понедельник") &&
                               line.Contains("марта")
                               select line;

            File.AppendAllLines(@"d:\selectedDays.txt", MarchMondays);
        }

        static void CreateSampleFile()
        {
            DateTime TimeStamp = new DateTime(1700, 1, 1);
            using (StreamWriter sw = new StreamWriter(dataPath))
            {
                CultureInfo myCulture = new CultureInfo("en-US");
                for (int i = 0; i < 500; i++)
                {
                    DateTime TS1 = TimeStamp.AddYears(i);
                    DateTime TS2 = TS1.AddMonths(i);
                    DateTime TS3 = TS2.AddDays(i);
                    //string temp = TS3.ToLongDateString();
                    //string temp1 = temp.ToString(myCulture);
                    sw.WriteLine(TS3.ToLongDateString());
                    //sw.WriteLine(TS3.ToLongDateString(),myCulture.Name);
                }
            }
        }
    }
}
