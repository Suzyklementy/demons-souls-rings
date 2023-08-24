using PerformanceTest.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                string command = Console.ReadLine().ToLower();

                if(command == "api")
                {
                    string command1 = Console.ReadLine().ToLower();

                    var test = new ApiPerformanceTest();

                    if (command1 == "test1")
                    {
                        test.GetAllRings10Times();
                    }
                    else if (command1 == "test2")
                    {
                        test.GetRingbyName10Times();
                    }
                }
                else if(command == "webapp")
                {
                    var test = new WebAppPerformanceTest();
                    test.AccessWebApp100Times();
                }
                else if(command == "exit")
                {
                    Environment.Exit(1);
                }


            }
        }
    }
}
