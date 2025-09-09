namespace LearnMethods.CodeUnderTest
{
    [TestClass]
    public sealed class ReturnTest
    {
        [TestMethod]
        public void LocalFunctionTest()
        {

            int a = 1, b = 2;

            int actual = Add(a, b);
            Assert.AreEqual(3, actual);


            int Add(int x,int y)
            {
                return x + y;
            }

            int Subtract(int x, int y) => x - y;

            actual = Subtract(b, a);
            Assert.AreEqual(1, actual);

            // Add and Subtract can ONLY be seen in LocalFunctionTest
        }

        [TestMethod]
        public void ParameterTests()
        {
            int a = 100;
            int expected = 100;
            ValueParam(a);
            Assert.AreEqual(100, a);

            ValueParamByRef(ref a); // ref is pointing to a location in memory
            Assert.AreEqual(101, a);

            void ValueParam(int x)
            {
                x = x + 1;
            }

            void ValueParamByRef(ref int x)
            {
                x = x + 1;
            }


            float eurRate = default;
            GetExchangeRate(ref eurRate, "EUR");

            float gbpRate = default;
            GetExchangeRate(ref gbpRate, "GBP");

            void GetExchangeRate(ref float x, string currency)
            {
                switch (currency)
                {
                    case "USD":
                        x = 1F;
                        break;
                    case "EUR":
                        x = 1.2F;
                        break;
                    case "GBP":
                        x = 1.5F;
                        break;


                }
            }


        }

        [TestMethod]
        public void OutParameterTests()
        {
            string size = "test123";
            int waist = 10;
            Assert.IsFalse(TryParse(waist, out size));
            Assert.AreEqual(string.Empty, size);

            waist = 25;
            Assert.IsTrue(TryParse(waist, out size));
            Assert.AreEqual("Small", size);

            waist = 35;
            Assert.IsTrue(TryParse(waist, out size));
            Assert.AreEqual("Medium", size);

            bool TryParse(int waist, out string size)
            {
                // size param is defined with out keyword, it must be assigned to
                size = waist switch
                {
                    >= 20 and <= 30 => "Small",
                    >= 31 and <= 40 => "Medium",
                    >= 41 and <= 50 => "Large",
                    _ => string.Empty // default

                    //20-30 Small
                    //30-40 Medium
                    //40-50 Large
                };
                // pattern matching switch
                return size != string.Empty;
            }


        }

        [TestMethod]
        public void ParamsParameterTest()
        {

            Assert.AreEqual(15, AddAll(1, 2, 3, 4, 5));
            Assert.AreEqual(235, AddAll(45, 46, 47, 48, 49));
            Assert.AreEqual(3, AddAll(1, 2));
            Assert.AreEqual(6, AddAll([1, 2, 3])); // can pass in an array if you want, but don't strictly have to
            PrintAll("Bob", "Tom", "Joe", "Jim");


            int AddAll(params int[] numbers) 
            {
                // params keyword turns comma delimited input params into array
                int result = 0;
                foreach (var item in numbers)
                {
                    result += item;
                }
                return result;
            
            }

            void PrintAll(params List<string> names) //list<string> pronounced as List Of String, stores a list of strings
            { // params keywork turns comma delimited input params into collection
                
                foreach (var item in names)
                {
                    Console.WriteLine(item);
                }
                

            }
        }
        // all methods must be defined under a class, local function can be defined inside of method

        [TestMethod]  // polymorphism
        public void ParamsOverloadingTest()
        {
            // lets you create different versions of the method based on different input parameters
            // method overloading is not available at the local scope

            PrintGreeting("bob", 3);
            PrintGreeting("bob", "10"); // _ + discord return value;
        }
        void PrintGreeting(string name, int age) // two methods can have the same name as long as the parameters differ
        {
            Console.WriteLine($"hello {name}, age:{age}");
        }
        int PrintGreeting(string name, string age)
        {
            Console.WriteLine($"hello {name}, age:{age}"); return 1;

        }
    }
}
