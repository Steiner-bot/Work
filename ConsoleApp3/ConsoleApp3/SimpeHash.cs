using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    

    class SimpeHash
    {
        public List<List<string>> t;
        public int n;

        public SimpeHash()
        {
            n = 7;
            t = new List<List<string>>();
            for (int i = 0; i<n;i++)
            {

                t.Add(new List<string>());


            }

        }

        int GetHash(int v)
        {


            return 7 + 31 * v;


        }
        public void Add(string x)
        {

            t[GetHash(x) % 7].Add(x);

        }

        public bool Find(string x)
        {

            return t[GetHash(x) % 7].Contains(x);

        }
        
        public void Print()
        {

            for (int i=0;i<n;i++)
            {
                Console.Write($"{i}.");

                foreach (var item in t[i])
                {

                    Console.Write($"{item} ");


                }
                Console.WriteLine("");
            }

        }

        int GetHash(string s)
        {

            int g = 7;
            foreach(var i  in s)
            {

                g += i * 31;
                
            }


            return g;
        }

    }
}
