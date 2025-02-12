using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


abstract class Car
{
    public string Name { get; set; }
    public int Speed { get; protected set; }
    public int Position { get; private set; }
    private static Random rand = new Random();
    public event Action<Car> Finished;

    public Car(string name, int minSpeed, int maxSpeed)
    {
        Name = name;
        Speed = rand.Next(minSpeed, maxSpeed);
        Position = 0;
    }

    public void Drive()
    {
        while (Position < 100)
        {
            Position += rand.Next(1, Speed);
            Console.WriteLine($"{Name} is at position {Position}");
            Thread.Sleep(500);
        }
        Finished?.Invoke(this);
    }
}


class SportsCar : Car
{
    public SportsCar(string name) : base(name, 10, 20) { }
}

class PassengerCar : Car
{
    public PassengerCar(string name) : base(name, 5, 15) { }
}

class Truck : Car
{
    public Truck(string name) : base(name, 3, 10) { }
}

class Bus : Car
{
    public Bus(string name) : base(name, 4, 12) { }
}


class Race
{
    private List<Car> Cars = new List<Car>();
    private bool raceFinished = false;

    public void AddCar(Car car)
    {
        car.Finished += OnRaceFinished;
        Cars.Add(car);
    }

    public void Start()
    {
        Console.WriteLine("The race has started!");
        List<Thread> threads = new List<Thread>();
        foreach (var car in Cars)
        {
            Thread thread = new Thread(car.Drive);
            threads.Add(thread);
            thread.Start();
        }
    }

    private void OnRaceFinished(Car winner)
    {
        if (!raceFinished)
        {
            raceFinished = true;
            Console.WriteLine($"Race winner: {winner.Name}!");
            
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Race race = new Race();
        race.AddCar(new SportsCar("SportsCar 1"));
        race.AddCar(new PassengerCar("PassengerCar 1"));
        race.AddCar(new Truck("Truck 1"));
        race.AddCar(new Bus("Bus 1"));

        race.Start();
    }
}