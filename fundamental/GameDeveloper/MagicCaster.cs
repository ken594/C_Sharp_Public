public class MagicCaster : Enemy
{
    public Attack Heal = new Attack("Heal", -40);
    public MagicCaster(string n) : base(n)
    {
        _Health = 80;
        MaxHealth = 80;
    }

    // public void Heal(Enemy e)
    // {
    //     e._Health += 40;
    //     if (e._Health > e.MaxHealth) e._Health = e.MaxHealth;
    //     Console.WriteLine($"Now {e.Name}'s health is: {e._Health}");
    // }

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if (ChosenAttack._Name == "Heal" && _Health > 0)
        {
            Target._Health -= ChosenAttack.DamageAmount;
            if (Target._Health > Target.MaxHealth) Target._Health = Target.MaxHealth;
            Console.WriteLine($"{Name} heals {Target.Name}, healing {Math.Abs(ChosenAttack.DamageAmount)} hp and increasing {Target.Name}'s health to {Target._Health}!!");
        }
        else
        {
            base.PerformAttack(Target, ChosenAttack);
        }
    }

}