using System.Diagnostics;

namespace LearnCommonClassMethods;

[TestClass]
public class LinkedListTest
{
    LinkedList<string> testList;

    [TestInitialize]
    public void Init()
    {
        testList = new();
        LinkedListNode<string> aNode = new("The");
        testList.AddFirst(aNode);
        testList.AddLast(new LinkedListNode<string>("Lazy"));
        testList.AddAfter(aNode, new LinkedListNode<string>("Not"));
        if (testList.Last is not null)
            testList.AddBefore(testList.Last, "Very");
        // testList.AddBefore(testList.Last!, "Very");
    }

    [TestMethod]
    public void AddRemoveInsertIntoLinkedList()
    {
        //Start: The Not Very Lazy

        var newNode = new LinkedListNode<string>("LastOne");
        testList.AddAfter(testList.Last!,newNode); // becomes the new last
        Assert.AreSame(newNode,testList.Last);
        // testList.AddFirst(newNode); / cannot do this and make an infinite linked list
        Assert.AreSame(newNode.List, testList);

        // there is no insert
        testList.RemoveLast(); // removing the last node
        testList.AddFirst(newNode);
        PrintList(testList);

        LinkedListNode<string>? lazyNode = testList.Find("Lazy");
        if (lazyNode is not null) Debug.WriteLine("Found Lazy node.");
        Debug.Print(lazyNode.Previous!.Value);
        Debug.Print(lazyNode.Previous!.Previous!.Value);

        // finding a node involves linear search
    }

    [TestMethod]
    public void ReverseLinkedListChallenge()
    {
        // can not use stack
        // can not duplicate LinkedListNode
        // can not create a wrapper

        LinkedList<string> starterList = new LinkedList<string>(["apple", "banana", "cherry", "pear"]);


        // my attempt
        // do something

        LinkedList<string> starterListReversed = new LinkedList<string>([]);

        for (int i = (starterList.Count - 1); i >= 0;  i++)
        {
            if (starterList.Last is not null)
            {
                starterListReversed.AddLast(starterList.Last.Value);
                starterList.RemoveLast();
            }
        }

        // First == pear
        // Last == apple
        Debug.Print(starterListReversed.First.Value);
        Assert.AreEqual("pear", starterListReversed.First!.Value);
        Assert.AreEqual("apple", starterListReversed.Last!.Value);

    }


    private void PrintList<T>(LinkedList<T> theList)
    {
        if (theList.First is null) return; // if empty, return from function

        LinkedListNode<T> aNode = theList.First;
        while (aNode is not null)
        {
            
            Debug.WriteLine(aNode.Value!.ToString());
            aNode = aNode.Next!;
        }
    }

    [TestMethod]
    private void PersonTest()
    {
        Person bob = new Person { Age = 35, Name = "bob" };
        Person alice = new Person { Age = 45, Name = "alice" };

    }
}



class Person
{
    public int Age;
    public string Name;
    public string Greeting() => $"My name is {this.Name}, I am {Age} old. How you doing?";
}


