public class Enemy
{
    string name;
    int Health;
    protected List<Attack> AttackList;
    int maxHealth;

    public string Name
    {
        get { return name; }
    }

    public int _Health
    {
        get { return Health; }
        set { Health = value; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public Enemy(string n)
    {
        name = n;
        Health = 100;
        AttackList = new List<Attack>();
        maxHealth = Health;
    }

    public virtual Attack RandomAttack()
    {
        Random rand = new Random();
        // Console.WriteLine(AttackList[rand.Next(AttackList.Count)]._Name);
        return AttackList[rand.Next(AttackList.Count)];
    }

    public void addAttack(Attack a)
    {
        AttackList.Add(a);
    }

    public void showInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Health: {Health}");
        // Console.WriteLine($"MaxHealth: {maxHealth}");
        string temp = "";
        AttackList.ForEach(i => temp = temp + i._Name + " " + "damage: " + i.DamageAmount + " ");
        // AttackList.ForEach(i => temp = temp + i._Name + " ");
        Console.WriteLine($"AttackList: {temp}");
    }

    public virtual void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        // Write some logic here to reduce the Targets health by your Attack's DamageAmount
        if (_Health > 0)
        {
            Target._Health -= ChosenAttack.DamageAmount;
            Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target._Health}!!");
        }
        else
        {
            Console.WriteLine($"{Name} cannot perform attack due to 0 hp");
        }
    }
}