using System;
using System.IO;

namespace SleepData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            // specify path for data file
            /*string file = "/users/jgrissom/downloads/data.txt";*/
            string file = AppDomain.CurrentDomain.BaseDirectory + "data.txt";

            if (resp == "1")
            {
                // create data file

                // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));

                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter(file);
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                // TODO: parse data file
                StreamReader sr = new StreamReader(file);
                while (!sr.EndOfStream)
                {
                    string week = sr.ReadLine();
                    string[] arr = week.Split(',');
                    string date = arr[0];
                    string[] dates = date.Split('/');
                    string[] nums = arr[1].Split('|');
                    string month = "";
                    if (dates[0].Equals("1"))
                    {
                        month = "Jan";
                    }
                    else if (dates[0].Equals("2"))
                    {
                        month = "Feb";
                    }
                    else if (dates[0].Equals("3"))
                    {
                        month = "Mar";
                    }
                    else if (dates[0].Equals("4"))
                    {
                        month = "Apr";
                    }
                    else if (dates[0].Equals("5"))
                    {
                        month = "May";
                    }
                    else if (dates[0].Equals("6"))
                    {
                        month = "Jun";
                    }
                    else if (dates[0].Equals("7"))
                    {
                        month = "Jul";
                    }
                    else if (dates[0].Equals("8"))
                    {
                        month = "Aug";
                    }
                    else if (dates[0].Equals("9"))
                    {
                        month = "Sep";
                    }
                    else if (dates[0].Equals("10"))
                    {
                        month = "Oct";
                    }
                    else if (dates[0].Equals("11"))
                    {
                        month = "Nov";
                    }
                    else
                    {
                        month = "Dec";
                    }
                    int total;
                    double average;
                    int hours1, hours2, hours3, hours4, hours5, hours6, hours7;
                    hours1 = Convert.ToInt32(nums[0]);
                    hours2 = Convert.ToInt32(nums[1]);
                    hours3 = Convert.ToInt32(nums[2]);
                    hours4 = Convert.ToInt32(nums[3]);
                    hours5 = Convert.ToInt32(nums[4]);
                    hours6 = Convert.ToInt32(nums[5]);
                    hours7 = Convert.ToInt32(nums[6]);
                    total = hours1 + hours2 + hours3 + hours4 + hours5 + hours6 + hours7;
                    average = total / 7.0;
                    int day;
                    day = Convert.ToInt32(dates[1]);
                    if (day < 10)
                    {
                        dates[1] = "0" + dates[1];
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Week of {0,3}, {1,2}, {2,4}", month, dates[1], dates[2]);
                    Console.WriteLine(" Su Mo Tu We Th Fr Sa Tot Avg");
                    Console.WriteLine(" -- -- -- -- -- -- -- --- ---");
                    Console.WriteLine("{0,3}{1,3}{2,3}{3,3}{4,3}{5,3}{6,3}{7,4}{8,4:n1}", hours1, hours2, hours3, hours4, hours5, hours6, hours7, total, average);
                }
                Console.WriteLine("");
            }
        }
    }
}
