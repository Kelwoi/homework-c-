namespace inheritances;
internal class Program
{

    private static void Main(string[] args)
    {

        Product apple = new Product("Apple", 3, 50);
        apple.Display();
        apple.ReducePrice(1, 30);
        apple.Display();


        Device[] devices = { new Kettle(), new Microwave(), new Car(), new Steamboat() };
        foreach (var device in devices)
        {
            device.Show();
            device.Sound();
            device.Desc();
        }


        MusicalInstrument[] instruments = { new Violin(), new Trombone(), new Ukulele(), new Cello() };
        foreach (var instrument in instruments)
        {
            instrument.Show();
            instrument.Sound();
            instrument.Desc();
            instrument.History();
        }


        Worker[] workers = { new President(), new Security(), new Manager(), new Engineer() };
        foreach (var worker in workers)
        {
            worker.Print();
        }
    }
}