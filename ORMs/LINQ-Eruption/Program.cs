// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// ### Use LINQ to find the first eruption that is in Chile and print the result.
Eruption? firstChileEruption = eruptions.FirstOrDefault(e => e.Location == "Chile");
// if else statement is to avoid this warning
// warning CS8 602: Dereference of a possibly null reference.
if (firstChileEruption == null)
{
    Console.WriteLine("There is no eruption in the database that is in Chile");
}
else
{
    Console.WriteLine(firstChileEruption.ToString());
}

// ### Find the first eruption from the "Hawaiian Is" location and print it. 
// If none is found, print "No Hawaiian Is Eruption found."
Eruption? firstHawaiianIs = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
if (firstHawaiianIs == null)
{
    Console.WriteLine("No Hawaiian Is Eruption found");
}
else
{
    Console.WriteLine(firstHawaiianIs.ToString());
}

// ### Find the first eruption from the "Greenland" location and print it. 
// If none is found, print "No Greenland Eruption found."
Eruption? firstGreenland = eruptions.FirstOrDefault(e => e.Location == "Greenland");
if (firstGreenland == null)
{
    Console.WriteLine("No Greenland Eruption found");
}
else
{
    Console.WriteLine(firstGreenland.ToString());
}

// ### Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Eruption? firstNewZealandAfterYear1900 = eruptions.Where(e => e.Year > 1900)
    .FirstOrDefault(e => e.Location == "New Zealand");
if (firstNewZealandAfterYear1900 == null)
{
    Console.WriteLine("No New Zealand Eruption after year 1900 found");
}
else
{
    Console.WriteLine(firstNewZealandAfterYear1900.ToString());
}

// ### Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> elevationOverTwoThousand = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(elevationOverTwoThousand, "volcano's elevation is over 2000m: ");

// ### Find all eruptions where the volcano's name starts with "L" and print them.
// Also print the number of eruptions found.
IEnumerable<Eruption> volcanoNameStartsWithL = eruptions.Where(e => e.Volcano[0] == 'L');
PrintEach(volcanoNameStartsWithL, "volcano's name starts with 'L': ");
Console.WriteLine("The number of eruptions found is " + volcanoNameStartsWithL.Count());

// ### Find the highest elevation, and print only that integer
int hightestElevationValue = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine("The elevation value is " + hightestElevationValue);

// ### Use the highest elevation variable to find and print the name of the Volcano with that elevation.
Eruption hightestElevation = eruptions.First(e => e.ElevationInMeters == hightestElevationValue);
// Or I can sort the list by elevation and return the first
Console.WriteLine("The erution with the highest elevation is " + hightestElevation.Volcano);

// ### Print all Volcano names alphabetically.
IEnumerable<Eruption> alphabeticalEruptions = eruptions.OrderBy(e => e.Volcano);
PrintEach(alphabeticalEruptions, "Alphabetical Eruptions: ");

// ### Print the sum of all the elevations of the volcanoes combined.
int SumOfElevations = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine("The sum of elevations is " + SumOfElevations);

// ### Print whether any volcanoes erupted in the year 2000
bool isEruptedinTwoThousand = eruptions.Any(e => e.Year == 2000);
Console.WriteLine("Whether any volcanoes erupted in the year 2000: " + isEruptedinTwoThousand);

// ### Find all stratovolcanoes and print just the first three
IEnumerable<Eruption> FirstThreeStratovolcanoes = eruptions.Where(e => e.Type == "Stratovolcano").Take(3);
PrintEach(FirstThreeStratovolcanoes, "First three stratovolcanoes: ");

// ### Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
IEnumerable<Eruption> BeforeOneThousandCEAlphabetically = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
PrintEach(BeforeOneThousandCEAlphabetically, "All eruptions that happens before 1000 CE");

IEnumerable<string> NamesOfBeforeOneThousandCE = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano);
Console.WriteLine("Names of all the eruptions that happened before the year 1000 CE: ");
foreach (string str in NamesOfBeforeOneThousandCE)
{
    Console.WriteLine(str);
}



// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
