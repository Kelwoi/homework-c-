using vector_home;
internal class Program
{
    private static void Main(string[] args)
    {
        MyVector vector = new MyVector(3,6);
        MyVector vector2 = new MyVector(2,7);
        bool vector_ = vector != vector2;
        Console.WriteLine(vector_);
        MyVector vector3 = vector + vector2;
        vector3.print();
        double doub = (double)vector3;
        Console.WriteLine(doub);
        vector3 = doub;
        vector3.print();
        vector3++;
        vector3.print();
    }
}