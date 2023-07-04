// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

Soda coke = new Soda("Coke", "Black", 25.5, 200, false);
// coke.ShowInfo();
// Console.WriteLine("----------------------");

Coffee blueBottle = new Coffee("Blue Bottle", "Black", 4, 220, false, "dark", "Hayes Valley");
// blueBottle.ShowInfo();
// Console.WriteLine("----------------------");

Wine redWine = new Wine("Caymus Cabernet Sauvignon", "Red", 20, 300, false, "Napa Valley", 2020);
// redWine.ShowInfo();

// Polymorphism
List<Drink> AllBeverages = new List<Drink>();
AllBeverages.Add(coke);
AllBeverages.Add(blueBottle);
AllBeverages.Add(redWine);

foreach (Drink drink in AllBeverages)
{
    drink.ShowInfo();
    Console.WriteLine("----------------------");
}

// Bonus
// Coffee MyDrink = new Soda("Coke", "Black", 25.5, 200, false);
// Error: Cannot implicitly convert type 'Soda' to 'Coffee'