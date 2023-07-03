// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

Vehicle a = new Vehicle("Tigger", "Black and White");
Vehicle b = new Vehicle("Ocean", 2, "blue", true);
Vehicle c = new Vehicle("Batman", "Black");
Vehicle d = new Vehicle("Rocket", 1, "Red", true);

// MyVehicle.ShowInfo();
// Console.WriteLine("-------------------");
// MyVehicle.Travel(5000);

// NewVehicle.ShowInfo();

List<Vehicle> vehicleList = new List<Vehicle> { a, b, c, d };
foreach (Vehicle i in vehicleList)
{
    i.ShowInfo();
    Console.WriteLine("-------------------");
}

d.Travel(100);
Console.WriteLine("-------------------");
d.ShowInfo();
Console.WriteLine(d._distanceTraveled);