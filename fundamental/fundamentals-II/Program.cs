// ## C# Fundamentals II
Console.WriteLine("Hello, World!");

// # Objectives:
// Create instances of basic collection types such as Lists and dictionaries.
// Iterate through collections of data by using programming logic in C# syntax.

// Create an integer array with the values 0 through 9 inside.
// int[] arr1 = new int[10];
// for (int i = 0; i < arr1.Length; i++)
// {
//     arr1[i] = i;
//     Console.WriteLine(arr1[i]);
// }

// Create a string array with the names "Tim", "Martin", "Nikki", and "Sara".
string[] arr2 = new string[4] { "Tim", "Martin", "Nikki", "Sara" };
// Console.WriteLine(arr2); // -> It will print System.String[]

// Create a boolean array of length 10. 
// Then fill it with alternating true/false values, starting with true. 
// (Tip: do this using logic! Do not hard-code the values in!)
// bool[] arr3 = new bool[10];
// bool flag = true;
// for (int i = 0; i < arr3.Length; i++)
// {
//     arr3[i] = flag;
//     flag = !flag;
//     Console.WriteLine(arr3[i]);
// }

// Create a string List of ice cream flavors that holds at least 5 different flavors. (Feel free to add more than 5!)
// Output the length of the List after you added the flavors.
// Output the third flavor in the List.
// Now remove the third flavor using its index location.
// Output the length of the List again. It should now be one fewer.
string[] flavors = new string[] { "Chocolate", "Starberry", "Vanilla", "Matcha", "Coffee" };
List<string> iceCreamFlavors = new List<string>();
foreach (string flavor in flavors)
{
    iceCreamFlavors.Add(flavor);
}
// Console.WriteLine(iceCreamFlavors.Count);
// Console.WriteLine(iceCreamFlavors[2]);
// iceCreamFlavors.RemoveAt(2);
// Console.WriteLine(iceCreamFlavors.Count);

// Create a dictionary that will store string keys and string values.
// Add key/value pairs to the dictionary where:
//      Each key is a name from your names array (this can be done by hand or using logic)
//      Each value is a randomly selected flavor from your flavors List (remember Random from earlier?)
// Loop through the dictionary and print out each user's name and their associated ice cream flavor.
Dictionary<string, string> dict = new Dictionary<string, string>();
Random rand = new Random();
for (int i = 0; i < arr2.Length; ++i)
{
    dict.Add(arr2[i], flavors[rand.Next(5)]);
}
foreach (KeyValuePair<string, string> entry in dict)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}
