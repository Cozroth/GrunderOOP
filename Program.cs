// Tobias Skog .NET23
using GrunderOOP.Gemoetry.Shapes;

namespace GrunderOOP
{
  internal class Program
  {
    // The reason I choose to encapsulate the attributes is so that in future implementations
    // of the software we do not run the risk of accessing the attributes outside of the object.
    // We eliminate the risk of creating a new object and accidently setting the value of another
    // object causing unforseen errors or in the case of a user with the interest of accessing 
    // said attributes for usage in other ways than intended they will be restricted.
    // I choose to have public get accessors to some attributes so that we can use them for writing
    // to the console outside of the class or I.E passing in as arguments for algorithms where maybe the
    // radius of c_a is required to make the correct calculation
    // I decided to only have the _height attribute in the abstract super class Shape since it's the only
    // one currently being used by the two sub classes Circle and Triangle, but since we are using OOP
    // it's very easy to implement and build upon to add or remove attributes to the super class or the
    // sub classes as needed
    static void Main(string[] args)
    {
      // Creating 2 Circle objects where circle a have a radius of 5 and circle b have a radius of 6
      Circle c_a = new(5);
      Circle c_b = new(6);

      // Creating 3 Triangle Objects where
      // Triangle a is a equilateral triangle and have the 3 equal sides of the size 6
      // Triangle b is a isosceles triangle and have the baseWidth of 5 and 2 equal sides of 6
      // Triangle c have the baseWidth of 5, baseHeight of 6 and a Height of 7
      Triangle t_a = new(5);
      Triangle t_b = new(5, 6);
      Triangle t_c = new(5, 6, 7);

      // Creating a Triangle with values that we do not accept to test the functionality of the error handling class VerifiedUserInput
      // and it's methods GetPositveInt and GetPositveDouble
      Triangle t_faulty = new(4, 0, -2.718281828459045);

      // Writing to the console with the value returns of the method in the classes of Circle A, B and Triangle A, B, C
      // Since we return variables of the type ´double´ I decided to limit the amount of decimals to three by using `:#.###`
      // to limit the output to the console but not limiting the accuracy of the calculated results
      // By using `#.###` instead of `0.000` I only write out values to console IF there is a numerical value at that location of the string
      Console.WriteLine($"Cirkel A har en radie på: {c_a.Radius:#.###}");
      Console.WriteLine($"Cirkel A har arean: {c_a.GetArea():#.###}");
      Console.WriteLine($"Cirkel A har omkretsen: {c_a.GetCircumference():#.##}");
      Console.WriteLine($"Cirkel A har volymen: {c_a.GetVolume():#.###}");

      Console.WriteLine();

      Console.WriteLine($"Cirkel B har en radie på: {c_b.Radius:#.###}");
      Console.WriteLine($"Cirkel B har arean: {c_b.GetArea():#.###}");
      Console.WriteLine($"Cirkel B har omkretsen: {c_b.GetCircumference():#.###}");
      Console.WriteLine($"Cirkel B har volymen: {c_b.GetVolume():#.###}");

      Console.WriteLine();

      Console.WriteLine($"Triangel A har en basbredd, bashöjd och höjd på: " +
      $"[{t_a.BaseWidth:#.###}, {t_a.BaseHeight:#.###}, {t_a.Height:#.###}]");
      Console.WriteLine($"Triangel A har arean: {t_a.GetArea():#.###}");
      Console.WriteLine($"Triangel A har omkretsen: {t_a.GetCircumference():#.###}");
      Console.WriteLine($"Triangel A har volymen: {t_a.GetVolume():#.###}");

      Console.WriteLine();

      Console.WriteLine($"Triangel B har en basbredd, bashöjd och höjd på: " +
      $"[{t_b.BaseWidth:#.###}, {t_b.BaseHeight:#.###}, {t_b.Height:#.###}]");
      Console.WriteLine($"Triangel B har arean: {t_b.GetArea():#.###}");
      Console.WriteLine($"Triangel B har omkretsen: {t_b.GetCircumference():#.###}");
      Console.WriteLine($"Triangel B har volymen: {t_b.GetVolume():#.###}");

      Console.WriteLine();

      Console.WriteLine($"Triangel C har en basbredd, bashöjd och höjd på: " +
      $"[{t_c.BaseWidth:#.###}, {t_c.BaseHeight:#.###}, {t_c.Height:#.###}]");
      Console.WriteLine($"Triangel C har arean: {t_c.GetArea():#.###}");
      Console.WriteLine($"Triangel C har omkretsen: {t_c.GetCircumference():#.###}");
      Console.WriteLine($"Triangel C har volymen: {t_c.GetVolume():#.###}");

      Console.WriteLine();

      Console.WriteLine($"Triangeln med initieringsfel har en basbredd, bashöjd och höjd på: " +
      $"[{t_faulty.BaseWidth:#.###}, {t_faulty.BaseHeight:#.###}, {t_faulty.Height:#.###}]");
      Console.WriteLine($"Triangeln med initieringsfel har arean: {t_c.GetArea():#.###}");
      Console.WriteLine($"Triangeln med initieringsfel har omkretsen: {t_c.GetCircumference():#.###}");
      Console.WriteLine($"Triangeln med initieringsfel har volymen: {t_c.GetVolume():#.###}");

      // Console.ReadKey() so the software doesnt instantly shut down
      Console.ReadKey();
    }
  } 
}


