namespace LearnMethods;

[TestClass]
public class ParamsTest
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    [TestMethod]
    public void ArrayResizeTest()
    {
        int[] source = [1, 2, 3, 4];
        int[] sourceRetainer = source;

        Array.Resize(ref source, 10);
        Assert.AreEqual(10, source.Length);
        Assert.AreEqual(1, source[0]);
        Assert.AreEqual(4, source[3]);
        Assert.AreEqual(0, source[9]);

        Assert.AreEqual(4, sourceRetainer.Length);
    }
}
