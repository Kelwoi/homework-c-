using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritances
{
    abstract class MusicalInstrument
    {
        public string Name { get; set; }

        protected MusicalInstrument(string name)
        {
            Name = name;
        }

        public abstract void Sound();
        public void Show() => Console.WriteLine($"Instrument: {Name}");
        public abstract void Desc();
        public abstract void History();
    }

    class Violin : MusicalInstrument
    {
        public Violin() : base("Violin") { }
        public override void Sound() => Console.WriteLine("Screech Screech");
        public override void Desc() => Console.WriteLine("A string instrument played with a bow.");
        public override void History() => Console.WriteLine("Originated in the 16th century in Italy.");
    }

    class Trombone : MusicalInstrument
    {
        public Trombone() : base("Trombone") { }
        public override void Sound() => Console.WriteLine("Bwah Bwah");
        public override void Desc() => Console.WriteLine("A brass instrument with a telescoping slide.");
        public override void History() => Console.WriteLine("Used since the Renaissance period.");
    }

    class Ukulele : MusicalInstrument
    {
        public Ukulele() : base("Ukulele") { }
        public override void Sound() => Console.WriteLine("Plink Plink");
        public override void Desc() => Console.WriteLine("A small guitar-like instrument from Hawaii.");
        public override void History() => Console.WriteLine("Introduced to Hawaii in the 19th century.");
    }

    class Cello : MusicalInstrument
    {
        public Cello() : base("Cello") { }
        public override void Sound() => Console.WriteLine("Deep rich tones");
        public override void Desc() => Console.WriteLine("A large string instrument played with a bow.");
        public override void History() => Console.WriteLine("Evolved in the 16th century from the viola da gamba.");
    }
}
