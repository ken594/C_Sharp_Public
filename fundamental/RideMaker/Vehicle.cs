public abstract class Vehicle
{
    public string Name;
    public string color;
    int numPassengers;
    bool hasEngine;
    double distanceTraveled;

    public double _distanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }

    public Vehicle(string n, int num, string col, bool e)
    {
        Name = n;
        numPassengers = num;
        color = col;
        hasEngine = e;
    }

    public Vehicle(string n, string col)
    {
        Name = n;
        color = col;
        numPassengers = 4;
        hasEngine = true;
        distanceTraveled = 0;
    }


    public void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Number of Passengers: {numPassengers}");
        Console.WriteLine($"Color: {color}");
        Console.WriteLine($"HasEngine: {hasEngine}");
        Console.WriteLine($"distance Traveled: {distanceTraveled}");
    }

    public void Travel(int distance)
    {
        distanceTraveled += distance;
        Console.WriteLine($"{Name} has gone: {distanceTraveled} miles");
    }
}