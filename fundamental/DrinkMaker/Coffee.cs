public class Coffee : Drink
{
    string RoastValue;
    string BeansType;

    public Coffee
    (
        string name,
        string color,
        double temp,
        int calories,
        bool isCarb,
        string roast,
        string beans
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
        RoastValue = roast;
        BeansType = beans;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Roast Value: {RoastValue}");
        Console.WriteLine($"Bean type: {BeansType}");
    }
}