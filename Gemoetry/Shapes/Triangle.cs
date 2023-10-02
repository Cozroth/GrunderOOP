using GrunderOOP.VerifyUserInput;

namespace GrunderOOP.Gemoetry.Shapes
{
  // New class Triangle that inherits the Shape class
  public class Triangle : Shape
  {
    // The Triangle class gets its own _baseWidth and _baseHeight attribute
    // since we don't require it in any other class
    // The access modifier is set to protected to keep
    // the attributes inside the class and encapsulate them
    protected int _baseWidth { get; set; }
    protected int _baseHeight { get; set; }

    // The constructor for the Triangle class that asumes
    // we are creating an equilateral triangle and only require
    // one input to the constructor where we then assign the
    // base widh, base height and heigh to the same value

    public Triangle(int baseWidth)
    {
      // Asuming a Equilateral Triangle (Liksidig Triangel)

      // Creating a new int controlledBaseWidth and setting it to the return of the
      // GetPositiveInt method wich takes the baseWidth and a prompt
      // (incase we need to reassign the baseWidth to a new value) as input
      int controlledBaseWidth = VerifiedUserInput.GetPositveInt(baseWidth,
                                "Fel format på basen vid skapande av Triangel objektet\n" +
                                "Ange basen med ett positivt heltal: ");

      // Assigning _baseWidth to controlledBaseWidth
      _baseWidth = controlledBaseWidth;

      // Assigning _baseHeight to controlledBaseWidth
      _baseHeight = controlledBaseWidth;

      // Assigning _height to controlledBaseWidth
      _height = controlledBaseWidth;
    }
    // A second constructor for the Triangle Class that overloads the first one allowing the user
    // to pass in a baseWidth and a baseHeight when creating the Triangle
    // This asumes we are creating an isosceles triangle

    public Triangle(int baseWidth, int baseHeight)
    {
      // Asuming a Isosceles Triangle (Likbent Triangel)

      // Creating a new int controlledBaseWidth and setting it to the return of the
      // GetPositiveInt method wich takes the baseWidth and a prompt
      // (incase we need to reassign the baseWidth to a new value) as input
      int controlledBaseWidth = VerifiedUserInput.GetPositveInt(baseWidth,
                                "Fel format på basbredden vid skapande av Triangel objektet\n" +
                                "Ange basbredden med ett positivt heltal: ");

      // Creating a new int controlledBaseHeight and setting it to the return of the
      // GetPositiveInt method wich takes the baseHeight and a prompt
      // (incase we need to reassign the baseHeight to a new value) as input
      int controlledBaseHeight = VerifiedUserInput.GetPositveInt(baseHeight,
                                 "Fel format på bashöjden vid skapande av Triangel objektet\n" +
                                 "Ange bashöjden med ett positivt heltal: ");

      // Assigning _baseWidth to controlledBaseWidth
      _baseWidth = controlledBaseWidth;

      // Assigning _baseHeight to controlledBaseHeight
      _baseHeight = controlledBaseHeight;

      // Assigning _height to the return of the PythagorasFormula Method
      _height = PythagorasFormula();
    }

    public Triangle(int baseWidth, int baseHeight, double height)
    {
      // Creating a new int controlledBaseWidth and setting it to the return of the
      // GetPositiveInt method wich takes the baseWidth and a prompt
      // (incase we need to reassign the baseWidth to a new value) as input
      int controlledBaseWidth = VerifiedUserInput.GetPositveInt(baseWidth,
                                "Fel format på basbredden vid skapande av Triangel objektet\n" +
                                "Ange basbredden med ett positivt heltal: ");

      // Creating a new int controlledBaseHeight and setting it to the return of the
      // GetPositiveInt method wich takes the baseHeight and a prompt
      // (incase we need to reassign the baseHeight to a new value) as input
      int controlledBaseHeight = VerifiedUserInput.GetPositveInt(baseHeight,
                                 "Fel format på bashöjden vid skapande av Triangel objektet\n" +
                                 "Ange bashöjden med ett positivt heltal: ");

      // Creating a new double controlledHeight and setting it to the return of the
      // GetPositveDouble method wich takes the height and a prompt
      // (incase we need to reassign the height to a new value) as input
      double controlledHeight = VerifiedUserInput.GetPositveDouble(height,
                                "Fel format på höjden vid skapande av Triangel objektet\n" +
                                "Ange höjden med en positivt siffra: ");

      // Assigning _baseWidth to controlledBaseWidth
      _baseWidth = controlledBaseWidth;

      // Assigning _baseHeight to controlledBaseHeight
      _baseHeight = controlledBaseHeight;

      // Assigning _height to controlledHeight
      _height = controlledHeight;
    }

    // Public accessor for the user to get access to the value of BaseWidth
    public int BaseWidth
    {
      get { return _baseWidth; }
    }

    // Public accessor for the user to get access to the value of BaseHeight
    public int BaseHeight
    {
      get { return _baseHeight; }
    }

    // Public accessor for the user to get access to the value of Height
    public double Height
    {
      get { return _height; }
    }

    // Private method thats incase the user creates an Isosceles Triangle and wants
    // to calculate the area, we use this method to get the height of the triangle
    // to be able to calculate the Area
    // returns the height as a double

    private double PythagorasFormula()
    {
      // Pythagoras Forumla: c² = a² + b² 
      // To calculate the height for an Isosceles Triangle to be able to get the Area later
      // We know that A = 1.0 / 2 * b * h
      // So to get the height we need to use pythagoras formula
      // But first we need to get a new baseWidth to be able to use
      // pythagoras formula, we get the newBaseWidth like this newBase = _baseWidth / 2
      // height² + newBase² = _baseHeight²
      // height² = _baseHeight² - newBase²
      // height = Math.Sqrt(_baseHeight² - newBase²)

      // Creating a new double newBase and assigning it to the value of _baseWidth / 2.0
      // Ensuring that we force a double by dividing by 2.0 instead of 2
      double newBase = _baseWidth / 2.0;
      double height = Math.Sqrt(Math.Pow(_baseHeight, 2) - Math.Pow(newBase, 2));

      // returning the height
      return height;
    }

    // The SuperClass method GetArea is being implemented here with the `override` keyword
    // to be able to define it for the Triangle class
    public override double GetArea()
    {
      // Triangle Area Formula: A = 1/2 * b * h
      // Ensuring that we force a double by dividing by 1.0 instead of 1
      double area = 1.0 / 2 * _baseWidth * _height;

      // returning the area
      return area;
    }
    // the SuperClass method GetCircumference is being implemented here with the `override`
    // keyword to be able to define it for the Triangle class

    public override double GetCircumference()
    {
      // Creating a new double circumference that will be used later in the method
      double circumference;

      // Logic to be able to decide if we are dealing with a Equilateral Triangle
      // or a Isosceles Triangle
      if (_baseWidth == _height)
      {
        // Equilateral Triangle Circumference Formula: 3 * s
        // Worthy to note that we multiply _baseHeight with 3 because
        // in a Equilateral Triangle we have 3 sides where the values
        // are the same because of the way we create our object in the
        // constructor this is the _baseHeight
        circumference = 3 * _baseWidth;
      }
      else
      {
        // Isosceles Triangle Circumference Formula: 2 * a + b
        // Worthy to note that we multiply _baseHeight with 2 because
        // in a Isosceles Triangle we have 2 sides where the values are 
        // the same because of the way we create our object in the 
        // constructor the two sides that are equal is the _baseHeight
        circumference = 2 * _baseHeight + _baseWidth;
      }

      return circumference;
    }

    // The SuperClass method GetVolume is being implemented here with the `override` keyword
    // to be able to define it for the Triangle class
    public override double GetVolume()
    {
      // Triangle BaseArea: GetArea()
      // Triangle Volume Formula: TV = 1/3 * BaseArea * H

      // Creating a new double volume and assigning it by using the formula above
      // Ensuring that we force a double by dividing by 1.0 instead of 1
      // Using the GetArea method instead of writing it out the formula for the triangle
      // area when we already did that work earlier
      double volume = 1.0 / 3 * GetArea() * _height;

      // returning the volume
      return volume;
    }

  }
}
