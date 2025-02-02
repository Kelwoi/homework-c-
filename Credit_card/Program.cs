using Credit_Card;
internal class Program
{
    private static void Main(string[] args)
    {
        Credit_card albert = new Credit_card("John",4567939087653456,333,10,2026,0);
        albert.print();
        albert.add_cash(300);
        albert.print();
    }
}