using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingApp_v._2
{
    class Eater
    {
        public string Name { get; set; }

        static object locker = new object();

        public Fork Fork { get; set; }
        public bool GetFork = false;
        public Knife Knife { get; set; }
        public bool GetKnife = false;

        public Eater(string name)
        {
            Name = name;
        }


        public void Eat(Fork Fork, Knife Knife)
        {

                if (TakeCutlery(Fork, Knife) == true)
                {
                    Console.WriteLine($"{Name} Eating");
                }
          

            Thread.Sleep(4000);

            Fork.Freed();
            GetFork = false;
            Knife.Freed();
            GetKnife = false;
            Console.WriteLine($"{Name} Whaiting");
        }


        private bool TakeCutlery(Fork fork,Knife knife)
        {
            lock (locker)
            {
                while (true)
                {
                    if (fork.State == true)
                    {
                        fork.IsUsed();
                        GetFork = true;
                        Console.WriteLine($"{Name} take fork");
                    }
                    else if (knife.State == true)
                    {
                        knife.IsUsed();
                        GetKnife = true;
                        Console.WriteLine($"{Name} take knife");
                    }

                    else if (GetFork == true && GetKnife == true)
                    {
                        break;
                    }
                }
            }
                return true;
            
        }

    }
}
