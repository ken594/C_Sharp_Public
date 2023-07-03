// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


Enemy e = new Enemy("Garen");
Attack strike = new Attack("Decisive-Strike", 10);
Attack judgment = new Attack("Judgment", 7);
Attack demacian = new Attack("Demacian-Justice", 17);

e.addAttack(strike);
e.addAttack(judgment);
e.addAttack(demacian);
e.showInfo();

Console.WriteLine("-------------------");
// for (int i = 0; i < 10; i++)
// {
//     e.RandomAttack();
// }

Console.WriteLine(e._Health);