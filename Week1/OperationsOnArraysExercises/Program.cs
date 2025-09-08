// Sort() and Reverse()

using System.Diagnostics.Tracing;

string[] pallets = ["B14", "A11", "B12", "A13"];
//Console.WriteLine("Sorted...");
//Array.Sort(pallets);
//foreach (var pallet in pallets)
//{
//    Console.WriteLine($"-- {pallet}");
//}

//Console.WriteLine("");
//Console.WriteLine("Reversed...");
//Array.Reverse(pallets);
//foreach (var pallet in pallets)
//{
//    Console.WriteLine($"-- {pallet}");
//}

// Clear() and Resize()

//Console.WriteLine("");
//Console.WriteLine($"Before: {pallets[0].ToLower()}");
Array.Clear(pallets, 0, 2);
//if (pallets[0] != null)
//    Console.WriteLine($"After: {pallets[0].ToLower()}");
Console.WriteLine($"Clearing 2... count: {pallets.Length}");
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}
Console.WriteLine("");
Array.Resize(ref pallets, 6);
Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

pallets[4] = "C01";
pallets[5] = "C02";

foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("");
Array.Resize(ref pallets, 3);
Console.WriteLine($"Resizing 3 ... count: {pallets:Length}");

foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

// Split() and Join()

string value = "abc123";
char[] valueArray = value.ToCharArray();
Array.Reverse(valueArray);
//string result = new string(valueArray);
string result = String.Join(",", valueArray);
Console.WriteLine(result);

string[] items = result.Split(',');
foreach (string item in items)
{
    Console.WriteLine(item);
}


// reverse words in a sentence

string pangram = "The quick brown fox jumps over the lazy dog";
string[] pangramSplit = pangram.Split(" ");
foreach (string word in pangramSplit)
{
    char[] letters = word.ToCharArray();
    Array.Reverse(letters);
    string reversedWord = String.Join("", letters);
    Console.Write(reversedWord);
    Console.Write(" ");
}

// parse a string of orders
Console.WriteLine("");
string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
string[] orders = orderStream.Split(',');
Array.Sort(orders);
foreach (var order in orders)
{
    string errorMessage = "";
    if (order.Length != 4)
    {
        errorMessage = " - Error";
    }
    Console.WriteLine($"{order}{errorMessage}");
}
// not sure why this leaves out A345