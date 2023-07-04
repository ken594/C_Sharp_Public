public class Wine : Drink
{
    string Region;
    int YearBottled;

    public Wine
    (
        string name,
        string color,
        double temp,
        int calories,
        bool isCarb,
        string region,
        int year
    )
    : base
    (
        name,
        color,
        temp,
        isCarb,
        calories
    )
    {
        Region = region;
        YearBottled = year;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Year: {YearBottled}");
    }
}