using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingApp_v._2
{
    class Eater
    {
        public string Name { get; set; }

        static object locker = new object();

        public Fork Fork { get; set; }
        public Knife Knife { get; set; }

        public Eater(string name)
        {
            Name = name;
        }


        public void Eat(Fork Fork, Knife Knife)
        {
            lock (locker)
            {
                if (Fork.State == true && Knife.State == true)
                {

                    Fork.IsUsed();
                    Knife.IsUsed();

                    Console.WriteLine($"{Name} omnomonomonom");

                    Fork.Freed();
                    Knife.Freed();

                }
                else
                {
                    Console.WriteLine($"{Name} Can't Eating Cutlery State is false(((");
                }
            }
        }

    }
}
