// Puzzles Assignment
// https://login.codingdojo.com/m/613/14003/102227
// Console.WriteLine("Hello, World!");

static string FlipCoin()
{
    Random rand = new Random();
    if (rand.Next(2) == 1) return "head";
    else return "tail";
}
Console.WriteLine("Loading Coin Flip...");
Console.WriteLine(FlipCoin());
Console.WriteLine("--------------------");

static int RollDice(int sides = 6)
{
    Random rand = new Random();
    return rand.Next(1, sides + 1);
}
Console.WriteLine("Loading Dice Roll...");
Console.WriteLine(RollDice());
Console.WriteLine(RollDice(20));
Console.WriteLine("--------------------");

// Roll the dice 4 times and return a list of those 4 results
// Bonus: Write your function to roll any number of times you would like.
// Bonus: After finishing your rolls, print the largest value you rolled.
static List<int> StatRoll(int times = 4)
{
    int max = 0;
    List<int> diceList = new List<int>();
    for (int i = 0; i < times; i++)
    {
        int dice = RollDice();
        if (dice > max) max = dice;
        diceList.Add(dice);
    }
    Console.WriteLine("The largest value is " + max);
    return diceList;
}
Console.WriteLine("Loading Stat Roll...");
StatRoll().ForEach(item => Console.WriteLine(item));
// StatRoll(10).ForEach(item => Console.WriteLine(item));
Console.WriteLine("--------------------");


// Roll until it lands on a certain result and tracks how many rolls occurred
static int GetNumInput()
{
    int num = -1;
    // make sure the input is inbound
    while (num < 0 || num > 6)
    {
        Console.WriteLine("Please enter a valid integer between 1 and 6");
        if (Int32.TryParse(Console.ReadLine(), out int j))
        {
            Console.WriteLine($"You enter: {j}");
            num = j;
        }
    }
    return num;
}

static int GetCount(int target)
{
    int dice = -1;
    int count = 0;
    while (dice != target)
    {
        dice = RollDice();
        count++;
    }
    return count;
}

static void PrintResult(int number, int count)
{
    Console.WriteLine($"Rolled a {number} after {count} tries.");
}

static void GameBoard()
{
    int target = GetNumInput();
    int count = GetCount(target);
    PrintResult(target, count);
}
GameBoard();