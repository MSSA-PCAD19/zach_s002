namespace LearnCommonClassMethods
{
    [TestClass]
    public sealed class LearnClassAndMethod
    {
        [TestMethod]
        public void InstanceOfClassHasOwnState()
        {
            int[] arrA = [1, 2, 3];
            int[] arrB = [1, 2, 3, 4];
            // we have two instances of int[]
            // each one has seperate set of data (state)

            Assert.AreEqual(3, arrA.GetLength(0));
            Assert.AreEqual(4, arrB.GetLength(0));
            arrA[0] = 10;

            Assert.AreEqual(10, arrA[0]);
            Assert.AreEqual(1, arrB[0]);


        }

        //Learn System.IO.File
        [TestMethod]
        public void WhatIsAFile()
        {
            // FileInfo is a blueprint, design
            FileInfo textFile, binFile; // the two variables wil point to instances of this design
            textFile = new FileInfo("text.txt"); // instantiate an object from class by calling constructor - a method with same name as the class
            binFile = new FileInfo("test.bin");

            Assert.IsFalse(textFile.Exists);
            Assert.IsFalse(binFile.Exists);

            var streamWriter = textFile.CreateText();
            streamWriter.Close();

            Assert.IsTrue(textFile.Exists);
            Assert.AreEqual(".txt", textFile.Extension); // extension is .txt, not txt
            Assert.AreEqual(0, textFile.Length);
            


            textFile.Delete();
            // if this fails, likely need to manually delete .txt file because it was created but never deleted, in bin/debug/net9.0
        }

        // List class
        [TestMethod]
        public void WhatIsAList()
        {
            List<int> testList = [5, 10, 25, 30]; // modern way to construct a list
            //List<int> testList2 = new List<int>(new int[] { 1, 2, 3, 4 }); // older way to construct a list

            Assert.AreEqual(4, testList.Count);
            testList.Add(40);
            Assert.AreEqual(5, testList.Count);
            Assert.AreEqual(10, testList[1]);

            List<int> anotherList = [100, 200, 300, 400, 500];
            Assert.AreEqual(3,anotherList.IndexOf(400));
            Assert.AreEqual(1, anotherList.IndexOf(200));
            Assert.AreEqual(-1, anotherList.IndexOf(700)); // means cannot be found


        }

        [TestMethod]
        public void WhatIsAHashSet()
        {
            // instantiate a HashSet<int> using default constructor with no initialization
            HashSet<int> testSet = new HashSet<int>();
            // try to add 1,2,3,1,2
            testSet.Add(1);
            testSet.Add(2);
            testSet.Add(3);
            testSet.Add(1);
            testSet.Add(2);

            Assert.AreEqual(3, testSet.Count);

            HashSet<int> otherSet = [3, 4, 5];
            testSet.ExceptWith(otherSet);

            Assert.AreEqual(2, testSet.Count); // after exceptwith, will have 2 items left because only 1 and 2 remain, 3 was overlapped

            testSet.Add(3); // put 3 back
            testSet.IntersectWith(otherSet); // only intersection is 3

            Assert.AreEqual(1, testSet.Count);
            Assert.IsTrue(testSet.Contains(3));

            testSet.Add(1);
            testSet.Add(2);
            testSet.UnionWith(otherSet);
            Assert.AreEqual(5, testSet.Count);
            Assert.IsTrue(testSet.SetEquals([1, 2, 3, 4, 5]));

            // a set is not order based, it does not exist positionally, it just exists or it doesn't

        }

        //Stack<T>
        [TestMethod]
        public void WhatIsAStack()
        {
            // mine:

            Stack<int> firstStack = new Stack<int>();
            firstStack.Push(5);
            firstStack.Push(10);
            firstStack.Push(15);
            firstStack.Push(20);

            Assert.AreEqual(4, firstStack.Count);

            Assert.IsTrue(firstStack.Contains(5));
            Assert.IsTrue(firstStack.Contains(10));
            Assert.IsTrue(firstStack.Contains(15));
            Assert.IsTrue(firstStack.Contains(20));

            Assert.AreEqual(20, firstStack.Pop());
            Assert.AreEqual(15, firstStack.Pop());
            Assert.AreEqual(10, firstStack.Pop());
            Assert.AreEqual(5, firstStack.Pop());

            Assert.AreEqual(0, firstStack.Count);
            Assert.AreEqual(4, firstStack.Capacity);

            firstStack.Push(10);
            firstStack.Push(20);
            firstStack.Push(30);
            firstStack.Push(40);
            Assert.AreEqual(4, firstStack.Capacity);

            firstStack.Push(50);
            Assert.AreEqual(5, firstStack.Count);
            Assert.AreEqual(8, firstStack.Capacity);

            firstStack.Push(60);
            firstStack.Push(70);
            firstStack.Push(80);
            firstStack.Push(90);
            Assert.AreEqual(16, firstStack.Capacity);

            Assert.AreEqual(90, firstStack.Peek());
            Assert.AreEqual(9, firstStack.Count);

            int[] intArray2 = firstStack.ToArray();
            Assert.AreEqual(90, intArray2[0]);

            firstStack = new([100, 200, 300]);
            Assert.AreEqual(300, firstStack.Pop());

            // Victor's
            Stack<int> testStack = new Stack<int>();
            testStack.Push(1);
            testStack.Push(2);
            testStack.Push(3);
            Assert.AreEqual(3, testStack.Count); // after pushing 3 items to stack, the count is 3

            Assert.IsTrue(testStack.Contains(1));//contains should find item from anywhere on the stack
            Assert.IsTrue(testStack.Contains(2));
            Assert.IsTrue(testStack.Contains(3));

            Assert.AreEqual(3, testStack.Pop());//pop() provide Last In, First Out access to stack
            Assert.AreEqual(2, testStack.Pop());
            Assert.AreEqual(1, testStack.Pop());

            Assert.AreEqual(0, testStack.Count); // pop() removes item from stack
            Assert.AreEqual(4, testStack.Capacity); // capacity is unchanged to save resize 

            testStack.Push(1);
            testStack.Push(2);
            testStack.Push(3);
            testStack.Push(4);
            Assert.AreEqual(4, testStack.Capacity); // add 4 element keeps the capacity at 4

            testStack.Push(5);
            Assert.AreEqual(5, testStack.Count);
            Assert.AreEqual(8, testStack.Capacity); // expansion of stack is needed, 4=>8

            testStack.Push(6);
            testStack.Push(7);
            testStack.Push(8);
            testStack.Push(9);
            Assert.AreEqual(16, testStack.Capacity);// expansion of stack is needed, 8=>16

            Assert.AreEqual(9, testStack.Peek());// Peek retreives from top of the stack, without removing item
            Assert.AreEqual(9, testStack.Count); //count stays at 9

            int[] intArray = testStack.ToArray(); // we can turn Stack into Array, but in which order?
            Assert.AreEqual(9, intArray[0]); //answer: last in first out/

            testStack = new([100, 200, 300]); //what about constructing stack from array, in which order? again LIFO
            Assert.AreEqual(300, testStack.Pop());
        }

        [TestMethod]
        public void WhatIsAQueue()
        {
            Queue<int> testQueue = new([1, 2, 3, 4, 5]);

            Assert.AreEqual(1, testQueue.Dequeue());
            Assert.AreEqual(2, testQueue.Peek());
            Assert.AreEqual(4, testQueue.Count);

            var enumeratorForQueue = testQueue.GetEnumerator();
            int[] result = new int[4];
            int counter = 0;

            while (enumeratorForQueue.MoveNext()) // move next will be false when there is no other item to advance to
            {
                result[counter++] = enumeratorForQueue.Current;
            }

            CollectionAssert.AreEqual(new int[] { 2, 3, 4, 5 }, result);
            Assert.AreEqual(4, testQueue.Count);
            Assert.AreEqual(2, testQueue.Dequeue());

            Stack<int> testStack = new([ 2, 3, 4, 5]);
            var enumeratorForStack = testStack.GetEnumerator();

            counter = 0;
            while (enumeratorForStack.MoveNext())
            {
                result[counter++] = enumeratorForStack.Current;
            }

            // this getenumerator with while is the same as a foreach loop

            CollectionAssert.AreEqual(new int[] { 5, 4, 3, 2 }, result);
            Assert.AreEqual(4, testStack.Count);

            counter = 0;
            foreach (var item in testStack)
            {
                result[counter++] = item;
            }

            CollectionAssert.AreEqual(new int[] { 5, 4, 3, 2 }, result);
            Assert.AreEqual(4, testStack.Count);

            // when you have a queue, it's naturally FIFO
            // stack is naturally LIFO
        }
    }
}
