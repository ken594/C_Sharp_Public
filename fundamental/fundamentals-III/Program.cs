// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// ## 1. Given a List of strings, iterate through the List and print out all the values. 
//       Bonus: How many different ways can you find to print out the contents of a List? (There are at least 3! Check Google!)
static void PrintList(List<string> MyList)
{
    // foreach (string a in MyList)
    // {
    //     Console.WriteLine(a);
    // }

    // for (int i = 0; i < MyList.Count; i++)
    // {
    //     Console.WriteLine(MyList[i]);
    // }

    // using List<T>.ForEach
    MyList.ForEach(str => Console.WriteLine(str));
}
List<string> TestStringList = new List<string>() { "Harry", "Steve", "Carla", "Jeanne" };
PrintList(TestStringList);
Console.WriteLine("--------------------------");

// ## 2. Given a List of integers, calculate and print the sum of the values.
static void SumOfNumbers(List<int> IntList)
{
    // Do I need to add this code: using System.Linq
    Console.WriteLine(IntList.Sum());
}
List<int> TestIntList = new List<int>() { 2, 7, 12, 9, 3 };
// You should get back 33 in this example
SumOfNumbers(TestIntList);
Console.WriteLine("--------------------------");

// ## 3. Given a List of integers, find and return the largest value in the List.
static int FindMax(List<int> IntList)
{
    return IntList.Max();
    // without build-in Max(), we can
    // create a variable maxValue to keep track of the largest value
    // iterate through the list, if it is larger than the maxValue, update the maxValue
    // return the maxValue after the iteration
}
List<int> TestIntList2 = new List<int>() { -9, 12, 10, 3, 17, 5 };
// You should get back 17 in this example
Console.WriteLine(FindMax(TestIntList2));
Console.WriteLine("--------------------------");

// ## 4. Given a List of integers, return the List with all the values squared.
static List<int> SquareValues(List<int> IntList)
{
    // IntList.Select(i => i * i) will have type 'System.Collections.Generic.IEnumerable<int>'
    // however, we want to return the type 'System.Collections.Generic.List<int>'
    // so we need to convert it to List
    return IntList.Select(i => i * i).ToList();
}
List<int> TestIntList3 = new List<int>() { 1, 2, 3, 4, 5 };
// You should get back [1,4,9,16,25], think about how you will show that this worked
SquareValues(TestIntList3).ForEach(i => Console.WriteLine(i));
Console.WriteLine("--------------------------");

// ## 5. Given an array of integers, return the array with all values below 0 replaced with 0.
static int[] NonNegatives(int[] IntArray)
{
    return IntArray.Select(num => num < 0 ? 0 : num).ToArray();
}
int[] TestIntArray = new int[] { -1, 2, 3, -4, 5 };
// You should get back [0,2,3,0,5], think about how you will show that this worked
NonNegatives(TestIntArray).ToList().ForEach(i => Console.WriteLine(i));
Console.WriteLine("--------------------------");

// ## 6. Given a dictionary, print the contents of the said dictionary.
static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    // foreach (KeyValuePair<string, string> entry in MyDictionary)
    // {
    //     Console.WriteLine($"{entry.Key} - {entry.Value}");
    // }

    // using a for loop and accessing elements by index
    for (int i = 0; i < MyDictionary.Count; i++)
    {
        KeyValuePair<string, string> entry = MyDictionary.ElementAt(i);
        Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
}
Dictionary<string, string> TestDict = new Dictionary<string, string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);
Console.WriteLine("--------------------------");

// ## 7. Given a search term, return true or false whether the given term is a key in a dictionary. 
//       (Hint: figuring this one out may require some research!)
static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    // for (int i = 0; i < MyDictionary.Count; i++)
    // {
    //     KeyValuePair<string, string> entry = MyDictionary.ElementAt(i);
    //     if (SearchTerm == entry.Key) return true;
    // }
    // return false;

    // Use ContainsKey()
    return MyDictionary.ContainsKey(SearchTerm);
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));
Console.WriteLine("--------------------------");


// ## 8. Given a List of names and a List of integers, 
//       create a dictionary where the key is a name from the List of names and the value is a number from the List of numbers. 
//       Assume that the two Lists will be of the same length.

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> dict = new Dictionary<string, int>();
    for (int i = 0; i < Names.Count; i++)
    {
        dict.Add(Names[i], Numbers[i]);
    }
    return dict;
}

static void PrintStringIntDictionary(Dictionary<string, int> MyDictionary)
{
    foreach (KeyValuePair<string, int> entry in MyDictionary)
    {
        Console.WriteLine($"{entry.Key}: {entry.Value}");
    }
}
List<string> testStringList = new List<string>() { "Julie", "Harold", "James", "Monica" };
List<int> testIntList = new List<int>() { 6, 12, 7, 10 };
PrintStringIntDictionary(GenerateDictionary(testStringList, testIntList));
