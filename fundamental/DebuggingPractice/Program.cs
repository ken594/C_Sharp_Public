// Challenge 1
bool amProgrammer = true;
Console.WriteLine(amProgrammer);
double Age = 27.9;
Console.WriteLine(Age);
List<string> Names = new List<string>();
Names.Add("Monica");
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
MyDictionary.Add("Hello", "0");
MyDictionary.Add("Hi there", "0");
// This is a tricky one! Hint: look up what a char is in C#
string MyName = "MyName";
Console.WriteLine(MyName);

// Challenge 2
List<int> Numbers = new List<int>() { 2, 3, 6, 7, 1, 5 };
for (int i = Numbers.Count - 1; i >= 0; i--)
{
    Console.WriteLine(Numbers[i]);
}

// Challenge 3
List<int> MoreNumbers = new List<int>() { 12, 7, 10, -3, 9 };
foreach (int i in MoreNumbers)
{
    Console.WriteLine(i);
}

// Challenge 4
List<int> EvenMoreNumbers = new List<int>() { 3, 6, 9, 12, 14 };
for (int i = 0; i < EvenMoreNumbers.Count; ++i)
{
    int num = EvenMoreNumbers[i];
    if (num % 3 == 0)
    {
        num = 0;
    }
}

// Challenge 5
// What can we learn from this error message?
string MyString = "superduberawesome";
// MyString[7] = "p";
// error: Property or indexer 'string.this[int]' cannot be assigned to -- it is read only
// String in c# are immutable objects
// To replace or remove a char directly, create a new string
char[] chars = MyString.ToCharArray();
chars[7] = 'p';
string updatedMyString = new string(chars);
Console.WriteLine(updatedMyString);

// Challenge 6
// Hint: some bugs don't come with error messages
Random rand = new Random();
int randomNum = rand.Next(13);
if (randomNum == 12)
{
    Console.WriteLine("Hello");
}
