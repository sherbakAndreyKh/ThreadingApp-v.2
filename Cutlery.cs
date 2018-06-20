using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingApp_v._2
{
    public abstract class Cutlery
    {
        public bool State;

        public Cutlery()
        {
            State = true;

        }
       
        public void IsUsed()
        {
            State = false;
        }

        public void Freed()
        {
            State = true;
        }
    
    }
}
