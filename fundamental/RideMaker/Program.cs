// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// ### Below are from RideMaker

// Vehicle a = new Vehicle("Tigger", "Black and White");
// Vehicle b = new Vehicle("Ocean", 2, "blue", true);
// Vehicle c = new Vehicle("Batman", "Black");
// Vehicle d = new Vehicle("Rocket", 1, "Red", true);

// // MyVehicle.ShowInfo();
// // Console.WriteLine("-------------------");
// // MyVehicle.Travel(5000);

// // NewVehicle.ShowInfo();

// List<Vehicle> vehicleList = new List<Vehicle> { a, b, c, d };
// foreach (Vehicle i in vehicleList)
// {
//     i.ShowInfo();
//     Console.WriteLine("-------------------");
// }

// d.Travel(100);
// Console.WriteLine("-------------------");
// d.ShowInfo();
// Console.WriteLine(d._distanceTraveled);

// ### Below are from Fuel UP!
Car Mini = new Car("Tigger", 4, "Black and White", true);
Horse Flash = new Horse("Flash", "Black");
Bicycle Mountain = new Bicycle("Mountain", "Blue");

// Vehicle b = new Vehicle("Ocean", 2, "blue", true);
// Error: Cannot create an instance of the abstract type
List<Vehicle> vehicleList = new List<Vehicle> { Mini, Flash, Mountain };
List<INeedFuel> fuelVehicle = new List<INeedFuel>();
foreach (Vehicle i in vehicleList)
{
    if (i is INeedFuel)
    {
        fuelVehicle.Add((INeedFuel)i);
    }
}

foreach (INeedFuel i in fuelVehicle)
{
    i.GiveFuel(10);
}

foreach (INeedFuel i in fuelVehicle)
{
    Vehicle temp = (Vehicle)i;
    Console.WriteLine($"Name: {temp.Name}");
    Console.WriteLine($"Total Fuel: {i.FuelTotal}");
}