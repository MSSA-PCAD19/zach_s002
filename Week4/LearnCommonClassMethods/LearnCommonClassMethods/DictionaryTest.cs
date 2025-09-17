using System.Diagnostics;

namespace LearnCommonClassMethods;

[TestClass]
public class DictionaryTest
{
    [TestMethod]
    public void DictionaryTests()
    {
        Dictionary<string, string> urbanDictionary = new Dictionary<string, string>();
        urbanDictionary.Add("Youthquake", "A peaceful, digital driven revolution by the youth of a country");
        urbanDictionary.Add("Nopology", "A non-regretful acknowledgement of an offense or failure");

        KeyValuePair<string, string> entry = new("pebbles", "small rock");
        urbanDictionary.Add(entry.Key,entry.Value);

        foreach (var item in urbanDictionary)
        {
            Debug.WriteLine($"{item.Key}-{item.Value}");
        }

    }

    [TestMethod]
    public void DictionaryDuplicationTests()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("Key1", "Test");
        Assert.ThrowsException<ArgumentException>(() => dictionary.Add("Key1", "Test"));

        Assert.IsFalse(dictionary.TryAdd("Key1", "Test"));

        Assert.IsTrue(dictionary.ContainsKey("Key1"));

        // how to do an upsert with dictionary

        dictionary.Add("bob", "123 main st.");

        if (dictionary.ContainsKey("bob"))
        {
            dictionary["bob"] = "234 main st.";
        }
        else
        {
            dictionary["bob"] = "234 main st.";
        }


        }

    [TestMethod]
    public void DictionaryPropertyTest()
    {
        //lets try to new one up using collection expression
        Dictionary<string, string> dictionary = new(
            [
            new KeyValuePair<string,string> ("Apple", "Fruit"),
            new ("Bob", "Name"),
            new ("Chair", "Furniture"),
            new ("Keyboard", "PC Parts"),
            ]
            );

    foreach (var item in dictionary.Keys)
        {
            Debug.WriteLine(item);
        }

    foreach (var item in dictionary.Values)
        {
            Debug.WriteLine(item);
        }

        Assert.AreEqual("Name", dictionary["Bob"]);
    }

}


