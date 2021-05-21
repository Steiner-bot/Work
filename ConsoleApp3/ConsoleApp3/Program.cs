using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            ////var init = new int[] { 1, 2, 4, 9, 17, 87, 23, 41, 14, 58 };
            //var i = new string[] {"Alexander", "Danil", "Dmitrin", "Tania", "Evgeni", "Elvira", "Ruslan", "Sergei" };
            //var t = new SimpeHash();
            //foreach(var item in i)
            //{

            //    t.Add(item);

            //}

            //t.Print();

            Dict<string, int> dict = new Dict<string, int>(5);
            var init = new string[] { "Alexander", "Danil", "Dmitrin", "Tania", "Evgeni", "Elvira", "Ruslan", "Sergei" };

            foreach (var item in init)
            {

                dict.Add(item, 1);

            }
            dict.Print();
        }
    }
}
