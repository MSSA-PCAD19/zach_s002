using System.Collections.Generic;
using System.Diagnostics;
namespace LearnCommonClassMethods;

[TestClass]
public class SortedDictionaryTest
{
    [TestMethod]
    public void SortedDictionaryAsClusteredIndexTable()
    {
        SortedDictionary<int, (string, int, int)> customer = new();
        // the key is how clustered index organizes table data
        customer.Add(1, ("bob", 35, 10000));
        customer.Add(20, ("alice", 33, 13000));
        customer.Add(14, ("joe", 55, 10000));
        customer.Add(7, ("jim", 45, 12000));
        SortedDictionary<string, int> uniqueIndexOnName = new();
        SortedDictionary<string, List<int>> nonUniqueIndexOnSalary = new();

        foreach (var item in customer)
        {
            Debug.WriteLine($"{item.Key}-{item.Value.Item1}-{item.Value.Item2}-{item.Value.Item3}");
            uniqueIndexOnName.Add(item.Value.Item1, item.Key);
        }

        var bob = customer[uniqueIndexOnName["bob"]];

    }
    // cluster index determines the order of row storage
    // noncluster index looks up the location of the data row using clustered index values
}
