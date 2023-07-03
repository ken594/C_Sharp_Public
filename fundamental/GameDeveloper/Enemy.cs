class Enemy
{
    string Name;
    int Health;
    List<Attack> AttackList;

    public int _Health
    {
        get { return Health; }
    }

    public Enemy(string n)
    {
        Name = n;
        Health = 100;
        AttackList = new List<Attack>();
    }

    public void RandomAttack()
    {
        Random rand = new Random();
        Console.WriteLine(AttackList[rand.Next(AttackList.Count)]._Name);
    }

    public void addAttack(Attack a)
    {
        AttackList.Add(a);
    }

    public void showInfo()
    {
        Console.WriteLine($"Enemy name: {Name}");
        Console.WriteLine($"Enemy health: {Health}");
        string temp = "";
        AttackList.ForEach(i => temp = temp + i._Name + " ");
        Console.WriteLine($"Enemy AttackList: {temp}");
    }
}