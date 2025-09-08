// this does not work:
//int first = 2;
//string second = "4";
//int result = first + second;
//Console.WriteLine(result);

//int first = 2;
//string second = "4";
//string result = first + second;
//Console.WriteLine(result);

//int myInt = 3;
//Console.WriteLine($"int: {myInt}");

//decimal myDecimal = myInt;
//Console.WriteLine($"decimal: {myDecimal}");

// widening conversion means to convert from data type that holds less to
// a data type that holds more

decimal myDecimal = 3.14m;
Console.WriteLine($"decimal: {myDecimal}");

int myInt = (int)myDecimal;
Console.WriteLine($"int: {myInt}");

// narrowing conversion menas to convert from data type that holds more to
// a data type that holds less

decimal myDecimal2 = 1.23456789m;
float myFloat = (float)myDecimal2;

Console.WriteLine($"Decimal: {myDecimal2}");
Console.WriteLine($"Float: {myFloat}");

int first = 5;
int second = 7;
string message = first.ToString() + second.ToString();
Console.WriteLine(message);


//string third = "5";
//string fourth = "7";
//int sum = int.Parse(third) + int.Parse(fourth);
//Console.WriteLine(sum);

//string value1 = "5";
//string value2 = "7";
//int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
//Console.WriteLine(result);

int value = (int)1.5m; // casting truncates
Console.WriteLine(value);

int value2 = Convert.ToInt32(1.5m); // converting rounds up
Console.WriteLine(value2);