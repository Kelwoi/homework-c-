namespace Vectors_3_level;
internal class Program
{

    private static void Main(string[] args)
    {
        Vectors_3 res = new Vectors_3(5,4,5);
        Vectors_3 res2 = new Vectors_3(2,2,2);
        Vectors_3 res1 = res.plus(res2);
        res1.Show();
    }
}