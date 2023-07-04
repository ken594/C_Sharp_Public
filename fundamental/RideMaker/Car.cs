public class Car : Vehicle, INeedFuel
{
    public string FuelType { get; set; }
    public int FuelTotal { get; set; }

    public Car(string n, int num, string col, bool e) : base(n, num, col, e)
    {
        FuelType = "Gas";
        FuelTotal = 10;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal += Amount;
    }
}