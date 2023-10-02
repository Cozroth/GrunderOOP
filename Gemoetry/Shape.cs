namespace GrunderOOP.Gemoetry
{
  /// <summary>
  /// Creating an abstract class Shape that will hold all the base functionality that the subclasses will use
  /// I choose to set it to abstract due to not wanting the user to be able to create a Shape object, but only the classes who inherits from Shape
  /// </summary>
  public abstract class Shape
  {
    // Attributes for all the shapes with the protected access modifiers so that
    // we can access the attributes inside the encapsulated fields but cannot
    // be accessed outside of the class
    // The only attribute that is reused in all subclasses is _height
    // It would not make sense to have _radius in the Shape super class since
    // the triangle class have no need for a _radius variable
    protected double _height { get; set; }

    // Making _PI to a constant since it will always be the same no matter what
    // assigning it to the Math.PI value to be able to do more accurate calculations
    // than the suggested `_pi = 3.141f` 
    protected const double _PI = Math.PI;

    // Creating 3 abstract methods that all the subclasses must inherit
    // All 3 methods have a public access modifier so that they 
    // can be called outside of the scope of the class
    public abstract double GetArea();
    public abstract double GetCircumference();
    public abstract double GetVolume();
  }
}
