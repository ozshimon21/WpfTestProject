using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static object syncRoot = new Object();
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new []{3,2,4}));


            Thread t = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    lock (syncRoot)
                    {
                        Console.WriteLine($"Thread 1 - {i}");
                    }
                }
            });

            t.Start();
            t.Join();

            new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    lock (syncRoot)
                    {
                        Console.WriteLine($"Thread 2 - {i}");
                    }                
                }
            }).Start();
            Console.ReadKey();
        }

        public static int solution(int[] A)
        {

            int[] B = new int[A.Length];

            foreach (var item in A)
            {
                if (item > 0)
                {
                    B[item]++;
                }
            }

            for (var i = 1; i < B.Length; i++)
            {
                if (B[i] == 0) return i;
            }

            return B.Length;
        }
    }
}
