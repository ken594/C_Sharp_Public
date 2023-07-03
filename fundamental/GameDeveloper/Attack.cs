class Attack
{
    // fields
    string Name;
    int DamageAmout;
    public string _Name
    {
        get { return Name; }
    }

    // Constructor
    public Attack(string n, int dmg)
    {
        Name = n;
        DamageAmout = dmg;
    }

}
