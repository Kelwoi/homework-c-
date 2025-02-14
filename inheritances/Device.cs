using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritances
{
    abstract class Device
    {
        public string Name { get; set; }

        protected Device(string name)
        {
            Name = name;
        }

        public abstract void Sound();
        public void Show() => Console.WriteLine($"Device: {Name}");
        public abstract void Desc();
    }

    class Kettle : Device
    {
        public Kettle() : base("Kettle") { }
        public override void Sound() => Console.WriteLine("Whistling");
        public override void Desc() => Console.WriteLine("Used for boiling water.");
    }

    class Microwave : Device
    {
        public Microwave() : base("Microwave") { }
        public override void Sound() => Console.WriteLine("Beeping");
        public override void Desc() => Console.WriteLine("Used for heating food.");
    }

    class Car : Device
    {
        public Car() : base("Car") { }
        public override void Sound() => Console.WriteLine("Vroom Vroom");
        public override void Desc() => Console.WriteLine("Used for transportation.");
    }

    class Steamboat : Device
    {
        public Steamboat() : base("Steamboat") { }
        public override void Sound() => Console.WriteLine("Toot Toot");
        public override void Desc() => Console.WriteLine("Used for water travel.");
    }
}
