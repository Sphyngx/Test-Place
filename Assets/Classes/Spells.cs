using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Assets.Classes
{
    internal class Spells
    {
        public string Name;
        public string Inputs;
        public Spells(string Name,string Inputs)
        {
            this.Name = Name;
            this.Inputs = Inputs;
        }
    }
}
