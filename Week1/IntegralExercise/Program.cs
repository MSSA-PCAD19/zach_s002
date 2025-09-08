//Console.WriteLine("Signed integral types:");

//Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
//Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
//Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
//Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");


Console.WriteLine("Signed Integral Types");

Console.WriteLine($"sbyte   Min: {sbyte.MinValue,30:N0} , Max: {sbyte.MaxValue,30:N0}");
Console.WriteLine($"short   Min: {short.MinValue,30:N0} , Max: {short.MaxValue,30:N0}");
Console.WriteLine($"int     Min: {int.MinValue,30:N0} , Max: {int.MaxValue,30:N0}");
Console.WriteLine($"long    Min: {long.MinValue,30:N0} , Max: {long.MaxValue,30:N0}");
Console.WriteLine("");
Console.WriteLine(new String('=', 80));
Console.WriteLine("Unsigned Integral Types");
Console.WriteLine($"byte    Min: {byte.MinValue,30:N0} , Max: {byte.MaxValue,30:N0}");
Console.WriteLine($"ushort  Min: {ushort.MinValue,30:N0} , Max: {ushort.MaxValue,30:N0}");
Console.WriteLine($"uint    Min: {uint.MinValue,30:N0} , Max: {uint.MaxValue,30:N0}");
Console.WriteLine($"ulong   Min: {ulong.MinValue,30:N0} , Max: {ulong.MaxValue,30:N0}");