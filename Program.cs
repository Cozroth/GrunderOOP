namespace GrunderOOP
{
    internal class Program
    {
        // Developers note on the naming of the methods and variable names
        // To use PascalCase for methods and camelCase for variables

        // I would not have named the class methods getArea...
        // I would have preferred to name them GetArea.... 
        // Í would not have named the protected or private variables _Radius...
        // I would have preferred to name them _radius...

        // The reason I choose to encapsulate the attributes is so that in future implementations
        // of the software we do not run the risk of accessing the attributes outside of the object.
        // We eliminate the risk of creating a new object and accidently setting the value of another
        // object causing unforseen errors or in the case of a user with the interest of accessing 
        // said attributes for usage in other ways than intended they will be restricted.
        // I choose to have public get accessors to some attributes so that we can use them for writing
        // to the console outside of the class or I.E passing in as arguments for algorithms where maybe the
        // radius of c_a is required to make the correct calculation
        // I decided to only have the _Height attribute in the abstract super class Shape since it's the only
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
            Console.WriteLine($"Cirkel A har arean: {c_a.getArea():#.###}");
            Console.WriteLine($"Cirkel A har omkretsen: {c_a.getCircumference():#.##}");
            Console.WriteLine($"Cirkel A har volymen: {c_a.getVolume():#.###}");

            Console.WriteLine();

            Console.WriteLine($"Cirkel B har en radie på: {c_b.Radius:#.###}");
            Console.WriteLine($"Cirkel B har arean: {c_b.getArea():#.###}");
            Console.WriteLine($"Cirkel B har omkretsen: {c_b.getCircumference():#.###}");
            Console.WriteLine($"Cirkel B har volymen: {c_b.getVolume():#.###}");

            Console.WriteLine();

            Console.WriteLine($"Triangel A har en basbredd, bashöjd och höjd på: " +
            $"[{t_a.BaseWidth:#.###}, {t_a.BaseHeight:#.###}, {t_a.Height:#.###}]");
            Console.WriteLine($"Triangel A har arean: {t_a.getArea():#.###}");
            Console.WriteLine($"Triangel A har omkretsen: {t_a.getCircumference():#.###}");
            Console.WriteLine($"Triangel A har volymen: {t_a.getVolume():#.###}");

            Console.WriteLine();

            Console.WriteLine($"Triangel B har en basbredd, bashöjd och höjd på: " +
            $"[{t_b.BaseWidth:#.###}, {t_b.BaseHeight:#.###}, {t_b.Height:#.###}]");
            Console.WriteLine($"Triangel B har arean: {t_b.getArea():#.###}");
            Console.WriteLine($"Triangel B har omkretsen: {t_b.getCircumference():#.###}");
            Console.WriteLine($"Triangel B har volymen: {t_b.getVolume():#.###}");

            Console.WriteLine();

            Console.WriteLine($"Triangel C har en basbredd, bashöjd och höjd på: " +
            $"[{t_c.BaseWidth:#.###}, {t_c.BaseHeight:#.###}, {t_c.Height:#.###}]");
            Console.WriteLine($"Triangel C har arean: {t_c.getArea():#.###}");
            Console.WriteLine($"Triangel C har omkretsen: {t_c.getCircumference():#.###}");
            Console.WriteLine($"Triangel C har volymen: {t_c.getVolume():#.###}");

            Console.WriteLine();

            Console.WriteLine($"Triangeln med initieringsfel har en basbredd, bashöjd och höjd på: " +
            $"[{t_faulty.BaseWidth:#.###}, {t_faulty.BaseHeight:#.###}, {t_faulty.Height:#.###}]");
            Console.WriteLine($"Triangeln med initieringsfel har arean: {t_c.getArea():#.###}");
            Console.WriteLine($"Triangeln med initieringsfel har omkretsen: {t_c.getCircumference():#.###}");
            Console.WriteLine($"Triangeln med initieringsfel har volymen: {t_c.getVolume():#.###}");

            // Console.ReadKey() so the software doesnt instantly shut down
            Console.ReadKey();
        }
    }

    // Creating an abstract class Shape that will hold all the base functionality
    // that the subclasses will use
    // I choose to set it to abstract due to not wanting the user to be able to
    // create a Shape object, but only the classes who inherits from Shape
    public abstract class Shape
    {
        // Attributes for all the shapes with the protected access modifiers so that
        // we can access the attributes inside the encapsulated fields but cannot
        // be accessed outside of the class
        // The only attribute that is reused in all subclasses is _Height
        // It would not make sense to have _Radius in the Shape super class since
        // the triangle class have no need for a _Radius variable

        protected double _Height { get; set; }

        // Making _PI to a constant since it will always be the same no matter what
        // assigning it to the Math.PI value to be able to do more accurate calculations
        // than the suggested `_pi = 3.141f` 
        protected const double _PI = Math.PI;

        // Creating 3 abstract methods that all the subclasses must inherit
        // All 3 methods have a public access modifier so that they 
        // can be called outside of the scope of the class
        public abstract double getArea();
        public abstract double getCircumference();
        public abstract double getVolume();
    }

    // New class Circle that inherits the Shape class
    public class Circle : Shape
    {
        // The Circle class gets its own _Radius attribute
        // since we don't require it in any other class
        // The access modifier is set to protected to keep
        // the attributes inside the class and encapsulate them
        protected int _Radius { get; set; }

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

            // Assigning _Radius to controlledRadius
            _Radius = controlledRadius;

            // Assigning _Height to the controlledRadius * 2
            _Height = controlledRadius * 2;
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

            // Assigning _Radius to controlledRadius
            _Radius = controlledRadius;

            // Assigning _Height to controlledHeight
            _Height = controlledHeight;
        }

        // Public int Radius is a accessor for users to be able to get the Radius of the Circle object outside
        // of the scope of the class
        public int Radius
        {
            get { return _Radius; }
        }

        // The SuperClass method getArea is being implemented here with the `override` keyword
        // to be able to define it for the Circle class
        public override double getArea()
        {
            // Circle Area Formula: pi ∗ r²
            // Creating a new double area and assigning it to the value 
            // of the Circle Area Formula seen above
            // Using Math.Pow(_Radius, 2) to calculate _Radius²
            double area = Math.Pow(_Radius, 2) * _PI;

            // returning the area
            return area;
        }

        // the SuperClass method getCircumference is being implemented here with the `override`
        // keyword to be able to define it for the Circle class
        public override double getCircumference()
        {
            // Circle Circumference Formula: O = 2 * pi * r
            // Creating a new double circumference and assigning it to 
            // the value of the Circle Circumference Formula seen above
            // Using our constant from the SuperClass Shape _pi
            double circumference = 2 * _PI * _Radius;

            // returning the circumference
            return circumference;
        }
        // The SuperClass method getVolume is being implemented here with the `override` keyword
        // to be able to define it for the Circle class

        public override double getVolume()
        {
            // Circle Volume Formula: CV = pi ∗ r² ∗ h
            // Creating a new double volume and assigning and assigning 
            // it to  the value of the Circle Volume Formula seen above
            // Using our constant from the SuperClass Shape _pi
            // Using Math.Pow(_Radius, 2) to calculate _Radius²
            double volume = _PI * Math.Pow(_Radius, 2) * _Height;

            // returning the volume
            return volume;
        }
    }
    // New class Triangle that inherits the Shape class

    public class Triangle : Shape
    {
        // The Triangle class gets its own _BaseWidth and _BaseHeight attribute
        // since we don't require it in any other class
        // The access modifier is set to protected to keep
        // the attributes inside the class and encapsulate them
        protected int _BaseWidth { get; set; }
        protected int _BaseHeight { get; set; }

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

            // Assigning _BaseWidth to controlledBaseWidth
            _BaseWidth = controlledBaseWidth;

            // Assigning _BaseHeight to controlledBaseWidth
            _BaseHeight = controlledBaseWidth;

            // Assigning _Height to controlledBaseWidth
            _Height = controlledBaseWidth;
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

            // Assigning _BaseWidth to controlledBaseWidth
            _BaseWidth = controlledBaseWidth;

            // Assigning _BaseHeight to controlledBaseHeight
            _BaseHeight = controlledBaseHeight;

            // Assigning _Height to the return of the PythagorasFormula Method
            _Height = PythagorasFormula();
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

            // Assigning _BaseWidth to controlledBaseWidth
            _BaseWidth = controlledBaseWidth;

            // Assigning _BaseHeight to controlledBaseHeight
            _BaseHeight = controlledBaseHeight;

            // Assigning _Height to controlledHeight
            _Height = controlledHeight;
        }

        // Public accessor for the user to get access to the value of BaseWidth
        public int BaseWidth
        {
            get { return _BaseWidth; }
        }

        // Public accessor for the user to get access to the value of BaseHeight
        public int BaseHeight
        {
            get { return _BaseHeight; }
        }

        // Public accessor for the user to get access to the value of Height
        public double Height
        {
            get { return _Height; }
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
            // pythagoras formula, we get the newBaseWidth like this newBase = _BaseWidth / 2
            // height² + newBase² = _BaseHeight²
            // height² = _BaseHeight² - newBase²
            // height = Math.Sqrt(_BaseHeight² - newBase²)

            // Creating a new double newBase and assigning it to the value of _BaseWidth / 2.0
            // Ensuring that we force a double by dividing by 2.0 instead of 2
            double newBase = _BaseWidth / 2.0;
            double height = Math.Sqrt(Math.Pow(_BaseHeight, 2) - Math.Pow(newBase, 2));

            // returning the height
            return height;
        }

        // The SuperClass method getArea is being implemented here with the `override` keyword
        // to be able to define it for the Triangle class
        public override double getArea()
        {
            // Triangle Area Formula: A = 1/2 * b * h
            // Ensuring that we force a double by dividing by 1.0 instead of 1
            double area = 1.0 / 2 * _BaseWidth * _Height;

            // returning the area
            return area;
        }
        // the SuperClass method getCircumference is being implemented here with the `override`
        // keyword to be able to define it for the Triangle class

        public override double getCircumference()
        {
            // Creating a new double circumference that will be used later in the method
            double circumference;

            // Logic to be able to decide if we are dealing with a Equilateral Triangle
            // or a Isosceles Triangle
            if (_BaseWidth == _Height)
            {
                // Equilateral Triangle Circumference Formula: 3 * s
                // Worthy to note that we multiply _BaseHeight with 3 because
                // in a Equilateral Triangle we have 3 sides where the values
                // are the same because of the way we create our object in the
                // constructor this is the _BaseHeight
                circumference = 3 * _BaseWidth;
            }
            else
            {
                // Isosceles Triangle Circumference Formula: 2 * a + b
                // Worthy to note that we multiply _BaseHeight with 2 because
                // in a Isosceles Triangle we have 2 sides where the values are 
                // the same because of the way we create our object in the 
                // constructor the two sides that are equal is the _BaseHeight
                circumference = 2 * _BaseHeight + _BaseWidth;
            }

            return circumference;
        }

        // The SuperClass method getVolume is being implemented here with the `override` keyword
        // to be able to define it for the Triangle class
        public override double getVolume()
        {
            // Triangle BaseArea: getArea()
            // Triangle Volume Formula: TV = 1/3 * BaseArea * H

            // Creating a new double volume and assigning it by using the formula above
            // Ensuring that we force a double by dividing by 1.0 instead of 1
            // Using the getArea method instead of writing it out the formula for the triangle
            // area when we already did that work earlier
            double volume = 1.0 / 3 * getArea() * _Height;

            // returning the volume
            return volume;
        }

    }

    // Public static class VerifiedUserInput that will is in place to help
    // us help the user to get acceptable values in the software
    public static class VerifiedUserInput
    {
        // public static method that takes an int and a prompt as input. The method checks if the value is greater than 0
        // in other words, it's making sure that the value is not a negative value
        public static int GetPositveInt(int unkownInt, string prompt)
        {
            // If the int have a positive value we return the int
            if (unkownInt > 0)
            {
                // The int recieved from the input was greater then 0
                // and is allowed we can go ahead and return the int
                // since no further validation is required

                // returning the int
                return unkownInt;
            }

            // If the int have a negative value we start a do while (true) loop (infite loop until we get a value we accept)
            else
            {
                do
                {
                    // Writing the prompt to the console
                    Console.Write(prompt);

                    // if statement that uses int.TryParse with the Console.ReadLine as input
                    // it tries to convert the input from the user to an int and returns a true or false
                    // value. True if it succeeds in parsing it as an int and it outputs a new int validInt
                    // False if the TryParse fails and we cannot parse it as an int
                    if (int.TryParse(Console.ReadLine(), out int validInt))
                    {
                        // The user input succeeded in parsing as an int, making sure the value is greater than 0
                        if (validInt > 0)
                        {
                            // The int we got from the user output from int.TryParse is 
                            // greater than 0 and is allowed we can go ahead and return the 
                            // int since no further validation is required

                            // returning the int
                            return validInt;
                        }
                    }

                    // The value was either not an integer or its value was not greater than 0
                    // The loop will restart
                } while (true);
            }
        }

        // public static method that takes a double and a prompt as input. The method checks if the value is greater than 0
        // in other words, it's making sure that the value is not a negative value
        public static double GetPositveDouble(double unkownDouble, string prompt)
        {
            // If the double have a positive value we return the double
            if (unkownDouble > 0.0)
            {
                return unkownDouble;
            }
            // If the double have a negative value we start a do while (true) loop (infite loop until we get a value we accept)
            else
            {
                do
                {
                    // Writing the prompt to the console
                    Console.Write(prompt);

                    // if statement that uses double.TryParse with the Console.ReadLine as input
                    // it tries to convert the input from the user to a double and returns a true or false
                    // value. True if it succeeds in parsing it as a double and it outputs a new double validDouble
                    // False if the TryParse fails and we cannot parse it as a double
                    if (double.TryParse(Console.ReadLine(), out double validDouble))
                    {
                        // The user input succeeded in parsing as an double, making sure tha value is greater than 0.0
                        if (validDouble > 0.0)
                        {
                            // The value is greater than 0.0, returning the value
                            return validDouble;
                        }
                    }

                    // The value was either not a double or its value was not greater than 0.0
                    // The loop will restart
                } while (true);
            }
        }
    }
}