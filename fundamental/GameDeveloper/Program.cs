// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// ### Below are from GameDeveloper I

// Enemy e = new Enemy("Garen");
// Attack strike = new Attack("Decisive-Strike", 10);
// Attack judgment = new Attack("Judgment", 7);
// Attack demacian = new Attack("Demacian-Justice", 17);

// e.addAttack(strike);
// e.addAttack(judgment);
// e.addAttack(demacian);
// e.showInfo();

// Console.WriteLine("-------------------");
// To test the random attack method
// for (int i = 0; i < 10; i++)
// {
//     e.RandomAttack();
// }

// Console.WriteLine(e._Health);

// ### Below are from GameDeveloper II

// MeleeFighter
MeleeFighter Lee = new MeleeFighter("Lee");
Attack punch = new Attack("Punch", 20);
Attack kick = new Attack("Kick", 15);
Attack tackle = new Attack("Tackle", 25);
Lee.addAttack(punch);
Lee.addAttack(kick);
Lee.addAttack(tackle);
// Lee.RageRandomAttack();
Lee.showInfo();
Console.WriteLine("-------------------");

// Ranged Fighter
RangedFighter Vayne = new RangedFighter("Vayne");
Attack Shoot = new Attack("Shoot an Arrow", 20);
Attack Throw = new Attack("Throw a Knife", 15);
Vayne.addAttack(Shoot);
Vayne.addAttack(Throw);
Vayne.showInfo();
Console.WriteLine("-------------------");

// Magic Caster
MagicCaster Soraka = new MagicCaster("Soraka");
Attack Fireball = new Attack("Fireball", 25);
Attack LightningBolt = new Attack("Lightning Bolt", 20);
Attack StaffStrike = new Attack("Staff Strike", 10);
Soraka.addAttack(Fireball);
Soraka.addAttack(LightningBolt);
Soraka.addAttack(StaffStrike);
Soraka.showInfo();
Console.WriteLine("-------------------");

// Board()
Lee.PerformAttack(Vayne, kick);
Lee.PerformAttack(Soraka, Lee.RageRandomAttack());
Vayne.PerformAttack(Lee, Shoot);
Vayne.Dash();
Vayne.PerformAttack(Lee, Shoot);
Soraka.PerformAttack(Lee, Fireball);
Soraka.PerformAttack(Vayne, Soraka.Heal);
Soraka.PerformAttack(Lee, Soraka.Heal);
Soraka.PerformAttack(Soraka, Soraka.Heal);