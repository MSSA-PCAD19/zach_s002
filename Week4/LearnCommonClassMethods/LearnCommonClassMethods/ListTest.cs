using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LearnCommonClassMethods;

[TestClass]
public class ListTest
{
    [TestMethod]
    public void DefaultConstructorTest()
    {
        List<string> animals = new List<string>();
        Assert.AreEqual(animals.Capacity, 0);
        Assert.AreEqual(animals.Count, 0);
        animals.Add("Polar Bear");
        animals.Add("Moose");

        Assert.AreEqual(animals.Capacity, 4);
        Assert.AreEqual(animals.Count, 2);


    }

    [TestMethod]
    public void IEnumerableConstructorTest()
    {
        string[] input = { "Polar Bear", "Moose" };
        List<string> animals = new List<string>(input);

        Assert.AreEqual(animals.Capacity, 2);
        Assert.AreEqual(animals.Count, 2);
    }


    [TestMethod]
    public void CapacityConstructorTest()
    {
        List<string> animals = new List<string>(4);
        Assert.AreEqual(animals.Capacity, 4);
        Assert.AreEqual(animals.Count, 0);
        animals.Add("Polar Bear");
        animals.Add("Moose");
        animals.Add("Raven");

        Assert.AreEqual(animals.Capacity, 4);
        Assert.AreEqual(animals.Count, 3);
    }

    [TestMethod]
    public void CapacityPropertyGetSetTest()
    {
        List<string> animals = new List<string>(6);
        animals.Add("Polar Bear");
        animals.Add("Moose");
        animals.Add("Raven");

        Assert.AreEqual(animals.Capacity, 6);
    }

    [TestMethod]
    public void CountPropertyGetTest()
    {
        List<string> animals = new List<string>();
        animals.Add("Polar Bear");
        animals.Add("Moose");
        animals.Add("Raven");
        animals.Add("Wolf");

        Assert.AreEqual(animals.Count, 4);

        animals.Remove("Wolf");

        Assert.AreEqual(animals.Count, 3);

    }

    [TestMethod]
    public void IndexerPropertyGetSetTest()
    {
        List<string> animals = new List<string>(6);
        animals.Add("Polar Bear");
        animals.Add("Moose");
        animals.Add("Raven");
        animals.Add("Wolf");
        animals.Add("Loon");
        animals.Add("Walleye");

        Assert.AreEqual("Loon", animals[4]);
        Assert.AreEqual("Moose", animals[1]);

        animals.Remove("Moose");

        Assert.AreEqual("Raven", animals[1]);

        // animals[7] = "Mountain Lion"; // this does not work
        // Assert.AreEqual("Mountain Lion", animals[7]);


    }

    [TestMethod]
    public void AddTest()
    {
        List<string> tester = new(["Apple", "Banana"]);
        tester.Add("Cherry");
        Assert.AreEqual(3, tester.Count);
    }

    [TestMethod]
    public void AddRangeTest()
    {
        IEnumerable<string> rangeSource = new Stack<string>(["Item3", "Item4", "Item5"]);
        List<string> tester = new(["Apple", "Banana"]);
        tester.AddRange(rangeSource);
        Assert.AreEqual(5, tester.Count);
        Assert.AreEqual("Apple", tester[0]);
        Assert.AreEqual("Item5", tester[2]); // because it pops off Item5 first
        Assert.AreEqual("Item4", tester[3]);
        Assert.AreEqual("Item3", tester[4]);

        IEnumerable<string> rangeSource2 = new Queue<string>(["Item6", "Item7", "Item8"]); // this is a queue, so it takes the first item vs last
        tester.AddRange(rangeSource2);
        Assert.AreEqual("Apple", tester[0]);
        Assert.AreEqual("Item6", tester[5]); 
        Assert.AreEqual("Item7", tester[6]);
        Assert.AreEqual("Item8", tester[7]);

        IEnumerable<string> rangeSource3 = new List<string>(["Item9", "Item10", "Item11"]); // and this is a list
        Assert.AreEqual("Apple", tester[0]);
        Assert.AreEqual("Item9", tester[8]);
        Assert.AreEqual("Item10", tester[9]);
        Assert.AreEqual("Item11", tester[10]);

        // AddRange is programmed against interface(Stack/Queue/List) instead of concrete class

    }

    [TestMethod]
    public void AllNumbersShouldBeEven()
    {
        List<int> testList = new List<int>([2, 4, 6, 8, 10]);
        Assert.IsTrue(testList.TrueForAll(n => n % 2 == 0));

        List<int> testList2 = new List<int>([1, 4, 6, 8, 10]);
        Assert.IsFalse(testList2.TrueForAll(n => n % 2 == 0));

        List<int> testList3 = new List<int>([]);
        Assert.IsTrue(testList3.TrueForAll(n => n % 2 == 0));

    }

    [TestMethod]
    public void TrueForAllWithString()
    {
        List<string> tester = ["alpha", "bravo", "charlie", "delta", "echo", "foxtrot", "golf", "hotel", "india", "juliet"];
        Assert.IsTrue(tester.TrueForAll(w => w.Length > 3));
        //Assert.IsTrue(tester.TrueForAll(w => w.Contains("a") || w.Contains("e") || w.Contains("i") || w.Contains("o") || w.Contains("u") ));
        Assert.IsTrue(tester.TrueForAll(w => w.ContainsVowel()));
    }

    [TestMethod]
    public void EnsureCapacityTest()
    {
        List<int> testList = new List<int>([2, 4, 6, 8, 10]);
        Assert.IsTrue(testList.Capacity >= 5);
        testList.EnsureCapacity(500);
        Assert.IsTrue(testList.Capacity >= 500);
    }

    [TestMethod]
    public void InsertRangeTest()
    {
        List<int> testList = new List<int>([2, 4, 6, 8, 10]);
        List<int> testList2 = new List<int>([1, 4, 6, 8, 10]);
        Assert.AreEqual(5, testList.Count);

        testList.InsertRange(2, testList2);
        Assert.AreEqual(10, testList.Count);
        Assert.AreEqual(1, testList[2]);
        Assert.AreEqual(6, testList[7]);

    }

    [TestMethod]
    public void InsertTest()

    {

        List<string> names = new List<string>(["Jack", "Mitchell", "Bryce"]);

        names.Insert(1, "John");

        Assert.AreEqual(4, names.Count);

        Assert.AreEqual("John", names[1]);

    }

    [TestMethod]
    public void ReverseTest()
    {
        List<string> normalList = new List<string> { "Miata", "Charger", "Mustang" };
        normalList.Reverse();
        Assert.AreEqual("Mustang", normalList[0]);

        List<char> aString = new List<char>("HelloWorld".ToCharArray());
        aString.Reverse();
        Assert.AreEqual('d', aString[0]);
    }

    [TestMethod]
    public void SliceTest()
    {
        List<int> numbers = [1, 2, 3, 4, 5, 6];
        var slicedList = numbers.Slice(2, 2);

        Assert.AreEqual(3, slicedList[0]);
        Assert.AreEqual(2, slicedList.Count);

        slicedList[0] = 30;
        Assert.IsTrue(slicedList[0] == 30);
        // Assert.IsTrue(numbers[2] == 30); // not true, because it is value type
    }

    [TestMethod]
    public void AsReadOnlyTest()
    {
        List<string> tester = new(["Papaya", "Avocado"]);

        // ReadOnlyCollection<string> roTester = tester.AsReadOnly(); // this would not compile
        IList<string> roTester = tester.AsReadOnly(); // we are rigging this to allow us to assign a value

        tester.Add("Apple");

        Assert.AreEqual("Apple", roTester[2]);

        Assert.ThrowsException<NotSupportedException>(() => roTester[1] = "Cherry");
        
    }

    [TestMethod]
    public void FindLastTest()
    {
        List<char> testList = ['a', 'b', 'g', 'h', 'a'];
        char? result = testList.FindLast(c => c <= 'b');
        Assert.IsTrue(result.HasValue);
        Assert.IsTrue(result == 'a');
        char? result2 = testList.FindLast(c => c >= 'z');
        Assert.IsTrue(result2 == '\0'); // \0 represents null character/char

    }

    [TestMethod]
    public void BinarySearchTest()
    {
        List<int> testList = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        int index = testList.BinarySearch(7); // O(log n)

        List<int> testList1 = [5, 8, 1, 4, 100, 60, 56];
        int index3 = testList1.BinarySearch(5);

        Assert.AreEqual(index, 6);
        Assert.IsFalse(index == 15);
        Assert.IsTrue(index != 20);
        int index1 = testList.BinarySearch(11);

        Assert.AreEqual(-5, index3); // returns negative version of the number if not found

        // Assert.AreEqual(-1, index); // -1 means not found
        // may need to use boolean to return not found if number is negative

    }

    [TestMethod]
    public void SortTest()
    {
        List<int> testList = [1, 10, 6, 7, 9, 3, 45, 3, 2];
        testList.Sort(new DescendingComparer());
        testList.ForEach(i => Debug.WriteLine(i));
    }

    class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return -(x.CompareTo(y));
        }
    }


    [TestMethod]
    public void MyDeduplicateList()
    {
        var names = new List<string> { "Ada", "Alan", "Grace", "Alan", "ada", "ADA", "Grace" };
        // compare ignore case
        var namesLower = new List<string> { };
        
        for (int i = 0; i < names.Count; i++)
        {
            namesLower.Add(names[i].ToLower());
        }
        Assert.AreEqual(7, namesLower.Count);

        var hashSetNames = new HashSet<string>(namesLower);
        Assert.AreEqual(3, hashSetNames.Count);

    }

    [TestMethod]
    public void DeduplicateList()
    {
        var names = new List<string> { "Ada", "Alan", "Grace", "Alan", "ada", "ADA", "Grace" };
        // compare ignore case
        HashSet<string> uniqueNames = new(names,StringComparer.OrdinalIgnoreCase);
        names = uniqueNames.ToList<string>();
        names.ForEach(s => Debug.WriteLine(s));
        Assert.AreEqual(3, names.Count);
        Assert.AreEqual("Ada", names[0]);
        Assert.AreEqual("Alan", names[1]);
        Assert.AreEqual("Grace", names[2]);

        // every object has a GetHash code
    }

    [TestMethod]
    public void MyRemoveElementsFromList()
    {
        var sequence = Enumerable.Range(100, 50).ToList();
        // remove multiple of 5
        for (int i = 0; i < sequence.Count; i++)
        {
            if (sequence[i] % 5 == 0)
            {
                sequence.Remove(sequence[i]);
            }
        }
        Assert.AreEqual(sequence.Count, 40);
        Assert.AreEqual(sequence[4], 106);
        sequence.ForEach(i => Debug.WriteLine(i));

    }

    [TestMethod]
    public void RemoveElementsFromList()
    {
        var sequence = Enumerable.Range(100, 50).ToList();
        // remove multiple of 5

        sequence.RemoveAll(c => c % 5 == 0);

        Assert.AreEqual(40, sequence.Count);
        Assert.IsTrue(sequence.TrueForAll(i => i % 5 != 0)); // make sure nothing left is divisible by 5
    }

    [TestMethod]
    public void MyRemoveRangeTest()
    {
        List<string> animals = [ "Polar Bear", "Moose", "Raven", "Wolf", "Loon", "Walleye", "Mountain Lion" ];
        Assert.AreEqual(animals[2], "Raven");
        Assert.AreEqual(animals[6], "Mountain Lion");
        Assert.AreEqual(animals.Count, 7);

        animals.RemoveRange(2, 3);
        Assert.AreEqual(animals[2], "Walleye");
        Assert.AreEqual(animals[3], "Mountain Lion");
        Assert.AreEqual(animals.Count, 4);

    }

    [TestMethod]
    public void MySliceTest()
    {
        string[] input = { "Polar Bear", "Moose", "Raven", "Wolf", "Loon", "Walleye", "Mountain Lion" };
        List<string> animals = new List<string>(input);


        List<string> someAnimals = animals.Slice(3, 3);
        Assert.AreEqual(someAnimals[0], "Wolf");
        Assert.AreEqual(someAnimals[1], "Loon");
        Assert.AreEqual(someAnimals[2], "Walleye");
        Assert.AreEqual(someAnimals.Count, 3);

    }
}

public static class Demo
{
    public static bool ContainsVowel(this string s) =>
        "aeiou".Any(v => s.Contains(v));
    // extends string class with ContainsVowel method
}
