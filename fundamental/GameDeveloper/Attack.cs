public class Attack
{
    // fields
    string Name;
    public int DamageAmount;
    public string _Name
    {
        get { return Name; }
    }

    // Constructor
    public Attack(string n, int dmg)
    {
        Name = n;
        DamageAmount = dmg;
    }

}
