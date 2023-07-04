public class RangedFighter : Enemy
{
    int distance;

    public RangedFighter(string n) : base(n)
    {
        distance = 5;
    }

    public void Dash()
    {
        distance = 20;
    }

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if (distance > 10)
        {
            base.PerformAttack(Target, ChosenAttack);
        }
        else
        {
            Console.WriteLine($"{Name} cannot attack due to distance constraint");
        }
    }
}