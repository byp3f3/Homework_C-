using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr8
{
    class Cats
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }

        public Cats(string name, string color, int age)
        {
            Name = name;
            Color = color;
            Age = age;
        }
        public Cats() { }
    }
}
