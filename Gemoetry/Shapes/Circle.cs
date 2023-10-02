using GrunderOOP.VerifyUserInput;

namespace GrunderOOP.Gemoetry.Shapes
{
  // New class Circle that inherits the Shape class
  public class Circle : Shape
  {
    // The Circle class gets its own _radius attribute
    // since we don't require it in any other class
    // The access modifier is set to protected to keep
    // the attributes inside the class and encapsulate them
    protected int _radius { get; set; }

    // The constructor for the Circle class
    // takes an int as the radius as input
    public Circle(int radius)
    {
      // Creating a new int controlledRadius and setting it to the return of the
      // GetPositiveInt method wich takes the radius and a prompt
      // (incase we need to reassign the radius to a new value) as input
      int controlledRadius = VerifiedUserInput.GetPositveInt(radius,
                             "Fel format på radien vid skapande av Cirkel objektet\n" +
                             "Ange radien med ett positivt heltal: ");

      // Assigning _radius to controlledRadius
      _radius = controlledRadius;

      // Assigning _height to the controlledRadius * 2
      _height = controlledRadius * 2;
    }

    // A second constructor for the Circle Class that overloads the first one allowing the user
    // to pass in a radius and a height when creating the Circle
    public Circle(int radius, double height)
    {
      // Creating a new int controlledRadius and setting it to the return of the
      // GetPositiveInt method wich takes the radius and a prompt
      // (incase we need to reassign the radius to a new value) as input
      int controlledRadius = VerifiedUserInput.GetPositveInt(radius,
                             "Fel format på radien vid skapande av Cirkel objektet\n" +
                             "Ange radien med ett positivt heltal: ");

      // Creating a new double controlledHeight and setting it to the return of the
      // GetPositveDouble method wich takes the height and a prompt
      // (incase we need to reassign the height to a new value) as input
      double controlledHeight = VerifiedUserInput.GetPositveDouble(height,
                                "Fel format på höjden vid skapande av Cirkel objektet\n" +
                                "Ange höjden med en positiv siffra: ");

      // Assigning _radius to controlledRadius
      _radius = controlledRadius;

      // Assigning _height to controlledHeight
      _height = controlledHeight;
    }

    // Public int Radius is a accessor for users to be able to get the Radius of the Circle object outside
    // of the scope of the class
    public int Radius
    {
      get { return _radius; }
    }

    // The SuperClass method GetArea is being implemented here with the `override` keyword
    // to be able to define it for the Circle class
    public override double GetArea()
    {
      // Circle Area Formula: pi ∗ r²
      // Creating a new double area and assigning it to the value 
      // of the Circle Area Formula seen above
      // Using Math.Pow(_radius, 2) to calculate _radius²
      double area = Math.Pow(_radius, 2) * _PI;

      // returning the area
      return area;
    }

    // the SuperClass method GetCircumference is being implemented here with the `override`
    // keyword to be able to define it for the Circle class
    public override double GetCircumference()
    {
      // Circle Circumference Formula: O = 2 * pi * r
      // Creating a new double circumference and assigning it to 
      // the value of the Circle Circumference Formula seen above
      // Using our constant from the SuperClass Shape _pi
      double circumference = 2 * _PI * _radius;

      // returning the circumference
      return circumference;
    }
    // The SuperClass method GetVolume is being implemented here with the `override` keyword
    // to be able to define it for the Circle class

    public override double GetVolume()
    {
      // Circle Volume Formula: CV = pi ∗ r² ∗ h
      // Creating a new double volume and assigning and assigning 
      // it to  the value of the Circle Volume Formula seen above
      // Using our constant from the SuperClass Shape _pi
      // Using Math.Pow(_radius, 2) to calculate _radius²
      double volume = _PI * Math.Pow(_radius, 2) * _height;

      // returning the volume
      return volume;
    }
  }
}
