public class MeleeFighter : Enemy
{
    public MeleeFighter(string n) : base(n)
    {
        // Health is 120 by default
        _Health = 120;
        MaxHealth = 120;

        // MeleeFighter has its own set of Attacks by default
        // Attack punch = new Attack("Punch", 20);
        // Attack kick = new Attack("Kick", 15);
        // Attack tackle = new Attack("Tackle", 25);
        // AttackList.Add(punch);
        // AttackList.Add(kick);
        // AttackList.Add(tackle);
    }
    public Attack RageRandomAttack()
    {
        // get the attack form the parent's method
        Attack RandAttack = base.RandomAttack();
        // create a new attack with the exact same name and damageAmount
        Attack RageAttack = new Attack(RandAttack._Name, RandAttack.DamageAmount);
        // Add 10 to the damageAmount
        RageAttack.DamageAmount += 10;
        // Console.WriteLine(RageAttack._Name + RageAttack.DamageAmount);
        return RageAttack;
    }
}