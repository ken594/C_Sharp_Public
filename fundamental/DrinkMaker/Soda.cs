public class Soda : Drink
{
    public bool isDiet;
    public Soda(string name, string color, double temp, int calories, bool isD) : base(name, color, temp, true, calories)
    {
        isDiet = isD;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"IsDiet: {isDiet}");
    }
}