public class Horse : Vehicle, INeedFuel
{
    public string FuelType { get; set; }
    public int FuelTotal { get; set; }
    public Horse(string n, string col) : base(n, 2, col, false)
    {
        FuelType = "Hay";
        FuelTotal = 10;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal += Amount;
    }

}