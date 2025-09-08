using Newtonsoft.Json;
// importing namespace

namespace LearnTypes.Week1.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void OnePlusOneEqualsTwo()
    {
        // how to declare variables and assign value
        //Arrange
        int a = 1;
        int b;
        b = 1;
        //Act
        int c = a + b;
        //Assert
        Assert.AreEqual(2, c);
    }

    [TestMethod]
    public void LimitOfWholeNumbers() // public members should be PascalCased
    {
        //Arrange
        // Can reuse a because it is declared inside another method
        byte a = byte.MaxValue;
        byte b = byte.MinValue;


        //SByte - signed byte, 1st bit used to store sign, 1st bit is 0 means positive int
        // max is 0111111, min is 1000000
        sbyte c = sbyte.MaxValue;
        sbyte d = sbyte.MinValue;


        //short - 2 bytes signed
        short e = short.MaxValue;
        short f = short.MinValue;


        //ushort - 2 bytes unsigned
        ushort g = ushort.MaxValue;
        ushort h = ushort.MinValue;

        //int - 4 bytes signed
        int i = int.MaxValue;
        int j = int.MinValue;

        //uint - 4 bytes unsigned
        uint k = uint.MaxValue;
        uint l = uint.MinValue;

        //long - 8 bytes signed
        long m = long.MaxValue;
        long n = long.MinValue;

        //ulong - 8 bytes unsigned

        // there is a BigInterger for even bigger intergers

        //Act
        byte expectedMax = 255;
        byte expectedMin = 0;

        sbyte expectedSBMax = 127; //0111 1111
        sbyte expectedSBMin = -128; //1000 0000, and note -1 would be 1111 1111

        short expectedSMax = 32767; //0111 1111 1111 1111
        short expectedSMin = -32768; //1000 0000 0000 0000

        ushort expectedUSMax = 65535;
        ushort expectedUSMin = 0;

        int expectedIntMax = 2_147_483_647;
        int expectedIntMin = -2_147_483_648;

        uint expectedUintMax = 4_294_967_295;
        uint expectedUintMin = 0;

        long expectedLongMax = 9_223_372_036_854_775_807;
        long expectedLongMin = -9_223_372_036_854_775_808;

        //Assert
        Assert.AreEqual(expectedMax, a);
        Assert.AreEqual(expectedMin, b);

        Assert.AreEqual(expectedSBMax, c);
        Assert.AreEqual(expectedSBMin, d);

        //Assert.AreEqual("01111111", Convert.ToString(c, 2)[8..]);
        Assert.AreEqual("10000000", Convert.ToString(d, 2)[8..]);

        Assert.AreEqual(expectedSMax, e);
        Assert.AreEqual(expectedSMin, f);

        Assert.AreEqual(expectedUSMax, g);
        Assert.AreEqual(expectedUSMin, h);

        Assert.AreEqual(expectedIntMax, i);
        Assert.AreEqual(expectedIntMin, j);

        Assert.AreEqual(expectedUintMax, k);
        Assert.AreEqual(expectedUintMin, l);

        Assert.AreEqual(expectedLongMax, m);
        Assert.AreEqual(expectedLongMin, n);


    }

    [TestMethod]
    public void IntergerArithmetics()
    {
        var a = 10;
        // var is a compiler observed type, compiler will assume int from whole number
        int b = 3;

        var c = a / b;
        int d = a % b; // remainder of interger divide, modulo

        Assert.AreEqual(3, c);
        Assert.AreEqual(1, d);
        Assert.AreEqual(11, ++a); // add one to a, ++ before means it evaluates the variable
        Assert.AreEqual(3, b++); // ++ after means it increments after, we don't increment until after b is used
        Assert.AreEqual(4, b);

        int e = 5; // e = 5
        int f = e; // f = 5
        e += 3; // shorthand for e = e+3
        Assert.AreEqual(8, e);
        Assert.AreEqual(5, f);

        int g = int.MaxValue;

        int h = g + 1;
        Assert.AreEqual(int.MinValue, h);

        //adding to the max wraps around int
        //checked // do not allow wrap around
        //{
        //try
        //{
        //    int h = g + 1; //adding to the max wraps around int
        //}
        //catch (OverflowException ex)
        //{
        //    Assert.IsTrue(ex is OverflowException);
        //    Assert.AreEqual(int.MinValue, h);
        //}
        //}
    }

    [TestMethod]
    public void NumbersWithFractions()
    {
        // approximated fractions
        float a = 1.23f; //use LETERAL SUFFIX,F/f - float  D/d - double  M/m - decimal
        //var f = 1.23f; // 4  bytes
        double d = 2.45E3; // 8 bytes
        // f for single, D for double

        // precision fraction
        decimal c = 1.234567899876M;
        // interest rates, any time you need to deal with exact numbers use decimal, but trade off is it uses more memory
        // double is 8 bytes, decimal is 16 bytes
    }

    [TestMethod]
    public void NauticalMileCalculatorTest()
    {
        //arrange
        float nauticalMile = 100.5F;
        float expectedMile = 115.653F;
        float expectedKm = 186.13F;

        //act
        //???
        float actualMile = 0;
        float actualKm = 0;
        const float milesPerNauticalMile = 1.15078F;
        const float kmPerNauticalMile = 1.852F;
        actualMile = nauticalMile * milesPerNauticalMile;
        actualKm = nauticalMile * kmPerNauticalMile;
        //
        Assert.IsTrue(Math.Abs(expectedMile - actualMile) < 0.001);
        Assert.IsTrue(Math.Abs(expectedKm - actualKm) < 0.01);
        //Assert.AreEqual(expectedMile, actualMile);
        //Assert.AreEqual(expectedKm, actualKm);

    }

    [TestMethod]
    public void FahrenheitToCelsiusCalculatorTest()
    {
        //arrange
        float degreesFahrenheit = 71F;
        float expectedCelsius = 21.66667F;
        float expectedKelvin = 294.8167F;

        //act
        float actualCelsius = 0;
        float actualKelvin = 0;
        const float fahrenheitMultiplier = 0.555556F;
        const float fahrenheitAddend = 32F;
        const float kelvinAddend = 273.15F;
        // Celsius = (Fahrenheit - 32) * (5/9)
        actualCelsius = fahrenheitMultiplier * (degreesFahrenheit - fahrenheitAddend);
        // Kelvin = (Fahrenheit - 32) * (5/9) + 273.15
        actualKelvin = (fahrenheitMultiplier * (degreesFahrenheit - fahrenheitAddend)) + kelvinAddend;

        //assert
        Assert.IsTrue(Math.Abs(expectedCelsius - actualCelsius) < 0.001);
        Assert.IsTrue(Math.Abs(expectedKelvin - actualKelvin) < 0.001);
    }

    //DateTime
    //bool
    [TestMethod]
    public void LearnBoolean()
    {
        bool x = true;
        bool y = false;
        Assert.IsTrue(x);
        Assert.IsFalse(y);

        //logical operators

        //AND truth table for AND (&&)
        bool result = x && y;
        Assert.IsFalse(result);
        Assert.IsTrue(x && true);
        Assert.IsFalse(false && true);
        Assert.IsFalse(false && false);

        //OR truth table for OR (||)
        Assert.IsTrue(true || false);
        Assert.IsTrue(false || true);
        Assert.IsTrue(true || true);
        Assert.IsFalse(false || false);

        //XOR truth table for XOR (^) - there can only be 1
        Assert.IsTrue(true ^ false);
        Assert.IsTrue(false ^ true);
        Assert.IsFalse(true ^ true);
        Assert.IsFalse(false ^ false);

        // in c#, we combine !(a && b) to create NAND
        //           combine !(a || b) to create NOR
        // ! = unary negation operator

        // == binary comparison for equality

        if (true) Assert.IsTrue(true); //simplest if

        if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
        {
            Assert.IsTrue(true);
        }

        string greeting = (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday) ? "Its taco tuesday" : "no taco for you";
        // ? : ternary operator
        // (bool expression) ? [return if true] : [return if false];

        //
        // challenge:
        // verify a number is between 50 and 100
        int number = 75;
        if (number > 50 && number < 100)
        { Assert.IsTrue(true); }
        else
        { Assert.Fail("number is not between 50 and 100");  }
        // short circuit evaluation
        int number2 = 175;
        if (number > 50 || number < 100)
        { Assert.IsTrue(true); }
        else
        { Assert.Fail(); }

        //avoid changing any value in the if condition
        // don't do this
        int i = 1;
        if (false && i++ > 1) // i++ is not > 1 because increment happens after the evaluation. it never runs the second condition if the first condition is false, because if 1st is false second is invisible
        { Assert.AreEqual(2, i); }
        else
        { Assert.AreEqual(1, i); }
            i++;
        //seriously, don't do this

        int j = 1;
        if (false)
            ;
        else
        {
            j += 1;
            j += 1;
        } // need curly brackets around everything, otherwise else only catches first line
        Assert.AreEqual(3 , j);


    }
    //String

    [TestMethod]
    public void MethodScopeTestA()
    {
        int a = 10; // the scope of a is method

        if (true)
        {
            int b = 100; // the scope of b is "block"
            Assert.AreEqual(100, b);
            if (true)
            {
                int c = 1000; // the scope of c is inner if "block"
                Assert.AreEqual(10, a);
                Assert.AreEqual(100, b); // inner block can see outer block
            }
            Assert.AreEqual(10, a);
            Assert.AreEqual(100, b);
            //Assert.AreEqual(1000, c); //can not see nested if block scoped variable c
        }

        Assert.AreEqual(10, a);
        //Assert.AreEqual(100, b); // this will not compile, b is "block"
    }

    // int classVar = 100; // class member classVar is a "field" of Test1 Class
    // this is not where to put statement and instructions, only variables
    [TestMethod]
    public void ClassVarTest()
    {
        Assert.AreEqual(100, classVar); // note, variable can also be declared afterwards, order does not matter
        // even though convention is field, property, event, property
        // classVar isn't defined in this method, its a class level field
        // in .net -- NO variable/data can exist outside of class.
        // data can be allocated at
        // 1 - code block level
        // 2 - method level
        // 3 - class level
        // scope of variables can help manage memory
    }

    [TestMethod]
    public void StackTest()
    {
        // managed memory places data into 1 - stack. 2 - heap
        int a = 10;
        StackChild();
        Assert.AreEqual(10, a);
    }
    public void StackChild()
    {
        // managed memory places data into 1 - stack. 2 - heap
        int a = 100;
        StackGrandChild();
        Assert.AreEqual(100, a);
    }
    public void StackGrandChild()
    {
        // managed memory places data into 1 - stack. 2 - heap
        int a = 1000;
        Assert.AreEqual(1000, a);
    }
    // second two are utility methods, not test methods
    // stack is called last in first out
    // a method calling itself is called recursion, so if you changed StackChild() to StackTest() within StackTest(). Magic number is 255, point at which you hit stack overflow
    // for data that lives on the stack, it is allocated and thrown away along with the stack


    int classVar = 100;


    [TestMethod]
    public void LearnDateTime()
    {
        DateTime dt;
        DateTimeOffset dto;

        dt = new(); // create a date time without any specification. default constructor
        // may also see dt = new DateTime();
        Assert.AreEqual(1, dt.Year);
        Assert.AreEqual(1, dt.Month);
        Assert.AreEqual(1, dt.Day);

        dt = new(2009, 08, 08);  // create a date time using Year/Month/Day
        Assert.AreEqual(220, dt.DayOfYear);
        Assert.AreEqual(DayOfWeek.Saturday, dt.DayOfWeek);
        Assert.AreEqual(true, dt.IsDaylightSavingTime());
        Assert.AreEqual(DateTimeKind.Unspecified, dt.Kind);

        dt = DateTime.Now;
        Assert.AreEqual(250, dt.DayOfYear);
        Assert.AreEqual(DayOfWeek.Wednesday, dt.DayOfWeek);
        Assert.AreEqual(true, dt.IsDaylightSavingTime());
        Assert.AreEqual(DateTimeKind.Local, dt.Kind);

        DateTime yesterday = new(2025, 9, 2);
        Assert.IsTrue(dt > yesterday);

        // dt = new(-100, 1, 1); can't use negative
        // DateTime DobOfConfucious
        TimeSpan ageToDrink = new(21 * 365, 0, 0, 0);
        DateTime bornOnThisDate = dt - ageToDrink; // +/- binary operator LHS is date RHS is Timespan

        bornOnThisDate = dt.AddYears(-21); // method = action = routine, while property = data
        Assert.AreEqual(2004, bornOnThisDate.Year);
        Assert.AreEqual(9, bornOnThisDate.Month);
        Assert.AreEqual(3, bornOnThisDate.Day);

        // can you construct a date time of an important moment
        DateTime birthday = new DateTime(1998, 11, 06);

        // print out 24 month lease due dates

        // lease payment begins on the first of next month
        // lets construct a datetime of first of next month

        // DateTime startDate = new(2025, 10, 01); we can hard code it
        dt = DateTime.Now;
        DateTime startDate = DateTime.Now;
        while (dt.Month == startDate.Month)
        {
            startDate = startDate.AddDays(1); // this is an immutable object. note if you didn't assign this to startDate, it wouldn't work
            // immutable is when all method/property do not cause the data of the object to change. this does not change the object, it returns a new thing
        }
        //Console.WriteLine(startDate.ToString());

        for (int i = 0; i < 24; i++)
        {
            Console.WriteLine($"Month {i} {startDate.AddMonths(i)}");
        }



    }

    [TestMethod]
    public void LearnString()

    {
        string a = "hello";
        char b = 'e';
        char c = (char)101;
        Assert.AreEqual(5, a.Length);
        Assert.AreEqual(b, a[1]); // a[1] is the second letter in the string hello ( char b = 'e' )
        Assert.AreEqual(101, b);
        Assert.AreEqual(c, b);

        // my version:
        for (int i = 97; i < 123; i++)
        {
            Console.Write((char)i);
        }

        // Victor's version:
        for (int i = 0; i < 26; i++)
        {
            char toPrint = (char)((int)'a' + i); // note the (int) is uneccessary since it will be performed by the compiler
            // (char) is required because all char is a number, but not all numbers can become char
            // there are far more numbers that has no char mapping, so there is no
            // guarantee the conversion succeeds. So compiler requires explicit conversion.
            Console.Write(toPrint);
        }

        // or...
        for (int i = 'a'; i <= 'z'; i++)
        {
            Console.Write((char)i);
        }

        // windows + . is emoji menu
        char unicodeChar = '\u3128'; // unicode char accomodates 2bytes unicode, emoji is beyond 2 bytes
        Console.Write(unicodeChar);

        char unicodeChar2 = '\u1F60';
        for (int i = 0; i < 10; i++)
        {
            Console.Write((char)(unicodeChar2+i)); // text runners are not unicode friendly
        }

        string anEmoji = "🤗";
        Assert.AreEqual(2, anEmoji.Length);

        string myName = "Mighty Chinjila";
        Assert.IsTrue(myName.EndsWith('a'));
        Assert.IsTrue(myName.EndsWith("jila"));
        Assert.IsTrue(myName.EndsWith("chinjila",StringComparison.OrdinalIgnoreCase)); //make case insensitive comparison

        Assert.AreEqual("Chinjila", myName.Substring(7));
        Assert.AreEqual("Chin", myName.Substring(7, 4));

        // pick 3 methods from string and write a test

        Assert.IsTrue(myName.Contains('j'));
        Assert.IsTrue((myName.LastIndexOf('g') == 2));
        Assert.AreEqual("Chinjila", myName.Remove(0, 7));

    }

    [TestMethod]
    public void LearnArray()
    {
        int[] anIntArray;
        string[] aStringArray;
        float[] aFloatArray;
        DateTime[] aDateArray;
        bool[] aBoolArray;
        // all array items must be of the same type
        // an array must have a fixed size, there is no dynamic array in C#

        anIntArray = new int[5]; // the 5 is capacity, the index is 0-4
        Assert.AreEqual(5, anIntArray.Length);
        Assert.AreEqual(0, anIntArray[0]); // when you have an int array, every one is initializd to zero
        for (int i = 0; i < anIntArray.Length; i++)
        {
            Assert.AreEqual(0, anIntArray[i]); // use loop index i as array index
        }
        // aStringArray[1] = "Hello"; array MUST be initialized first

        aStringArray = ["apple", "banana", "cherry"]; // [...,...,...] called collection initializer
        // aStringArray = new string[] { "apple", "banana", "cherry" }; // older syntax
        
        aFloatArray = [1.2F, 3.7F, 4.5F];
        aDateArray = [DateTime.Today, DateTime.Now + TimeSpan.FromDays(30)];

        // for flexible options, use a linked list
        // List<int> names = new();

        // create an Array of int that contains 100 multiples of 3

        int[] threeMultArray = new int[100];
        for (int i = 0; i < threeMultArray.Length; i++)
        {
            threeMultArray[i] = (i + 1) * 3;
            Console.WriteLine($"Array Element {i}: {threeMultArray[i]}");
        }

        // Common Array Operations:

        // find things
        Assert.AreEqual(17, Array.BinarySearch(threeMultArray, 54)); // this does O(logN)
        // Binary search is useful only when array is already sorted
        // to go from 1000 to 10000, need to search 10 times more. But with binary search the increase in time to
        // search all elements is not linear like linear search
        Assert.AreEqual(17, Array.IndexOf(threeMultArray, 54)); // this does linear search O(n)
        Assert.AreEqual(2, Array.IndexOf(threeMultArray, 9));

        // 

        int[] destinationArray = new int[10];
        Array.Copy(threeMultArray, destinationArray, 10);

        int[] secondPointerToDestinationArray = destinationArray;

        Assert.AreSame(destinationArray, secondPointerToDestinationArray);
        // are same is used when two objects point to the same thing
        // Assert.AreEqual(destinationArray, secondPointerToDestinationArray);
        // are equal is used when two objects are equivalent


        Array.Resize(ref destinationArray, 20); // ref reminds caller that after the call destinationArray will
        // point to a new location in heap
        // why do we use the ref keyword? the ref tells you that this resize
        // will create an 80 byte array, so that destinationArray is now referencing that

        Assert.AreNotSame(destinationArray, secondPointerToDestinationArray);
        Assert.AreEqual(20, destinationArray.Length);
        Assert.AreEqual(10, secondPointerToDestinationArray.Length);

        // array is a class, int is a struct
        // all primitive types covered up to this point are value which is type/struct, value type stores it right where it is on the stack
        // and reference is type/class
        // = is an assignment operator, if RHS is value type, value is COPIED
        // if RHS is reference type, reference is assigned

        Array.Reverse(threeMultArray); // note there is no ref keyword, so we are just flipping the items, not having
        // the variable point to a different spot
        Assert.AreEqual(300, threeMultArray[0]); // now 1st element is 300 after reverse

        //
        int a = 1;
        int b = a;
        // value type creates copy
        a += 1;
        Assert.AreEqual(2, a);
        Assert.AreEqual(1, b);

        // now int is stored as an element of the array, (called box/unbox) can use reference to access value
        int[] x = [7]; // initialize 1 item array, x is a reference to a single interger in the heap that contains the value 7
        int[] y = x; // y now points to the same place
        x[0] += 1;
        Assert.AreEqual(8, x[0]);
        Assert.AreEqual(8, y[0]);

        // we loaded a lot into this discussion because array is the first reference type, string is also
        // a reference type but it has been rigged to not act like a reference type

        int z = 5; // z is value type
        object o = z; // boxing - copy value to heap, box is the opcode in compile c# code
        int z2 = ((int)o); // unboxing



    }
    //
    //   expense - date, amount, merchant, category, isReimnurse
    //   expense report - employee, date, expense[], isApproved

    public
}


