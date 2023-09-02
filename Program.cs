namespace GrunderOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c_a = new Circle(5);
            Circle c_b = new Circle(6);
            Console.WriteLine($"Cirkel A har en radie på: {c_a._Radius}");
            Console.WriteLine($"Cirkel A har arean: {c_a.getArea():#.000}");
            Console.WriteLine();
            Console.WriteLine($"Cirkel B har en radie på: {c_b._Radius}");
            Console.WriteLine($"Cirkel B har arean: {c_b.getArea():#.000}");
            Console.ReadKey();
        }
    }


    public class Circle
    {
        public int _Base { get; private set; }
        public int _Radius { get; private set; }
        public const double _pi = Math.PI;
        public Circle(int radius)
        {
            _Radius = radius;
        }
        public double getArea()
        {
            double area = Math.Pow(_Radius, 2) * _pi;
            return area;
        }
    }
}