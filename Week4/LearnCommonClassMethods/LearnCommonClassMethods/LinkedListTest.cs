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
}


