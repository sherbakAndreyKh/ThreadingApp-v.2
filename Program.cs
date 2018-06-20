using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingApp_v._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            Knife knife1 = new Knife();
            Knife knife2 = new Knife();

            Fork fork1 = new Fork();
            Fork fork2 = new Fork();

            List<Eater> eaters = new List<Eater>()
            {
                new Eater("John 1"),
                new Eater("Sam 1"),

                new Eater("Jane 2"),
                new Eater("Sarah 2")
            };

            while (i < 2) {
                Thread thread1 = new Thread(() => eaters[0].Eat(fork1, knife1));
                thread1.Start();
                Thread thread2 = new Thread(() => eaters[1].Eat(fork1, knife1));
                thread2.Start();

                Thread thread3 = new Thread(() => eaters[2].Eat(fork2, knife2));
                thread3.Start();
                Thread thread4 = new Thread(() => eaters[3].Eat(fork2, knife2));
                thread4.Start();
                Console.WriteLine();
                i++;
            }

        }
    }
}
