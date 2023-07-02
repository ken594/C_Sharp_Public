// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// Fundamentals I

// create a loop that prints all values from 1-255
// for (int i = 1; i <= 255; i++)
// {
//     Console.WriteLine(i);
// }


// Generates 5 random numbers between 10 and 20
// Random rand = new Random();
// for (int i = 0; i < 5; i++)
// {
//     Console.WriteLine(rand.Next(10, 21));
// }

// add them together and print the sum after the loop finishes
// Random rand = new Random();
// int sum = 0;
// for (int i = 0; i < 5; i++)
// {
//     sum += rand.Next(10, 21);
// }
// Console.WriteLine(sum);

// Print all values from 1 to 100 that are divisble by 3 OR 5, but NOT both
// for (int i = 1; i < 101; i++)
// {
//     if (i % 3 == 0 && i % 5 == 0)
//     {
//         continue;
//     }

//     if (i % 3 == 0 || i % 5 == 0)
//     {
//         Console.WriteLine(i);
//     }
// }

// Print "Fizz" for multiples of 3 and "Buzz" for multiples of 5.
// for (int i = 1; i < 101; i++)
// {
//     if (i % 3 == 0 && i % 5 == 0)
//     {
//         continue;
//     }

//     if (i % 3 == 0)
//     {
//         Console.WriteLine("Fizz");
//         continue;
//     }
    
//     if (i % 5 == 0)
//     {
//         Console.WriteLine("Buzz");
//     }
// }

// Print "FizzBuzz" for numbers that are multiples of both 3 and 5.
for (int i = 1; i < 101; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
        continue;
    }

    if (i % 3 == 0)
    {
        Console.WriteLine("Fizz");
        continue;
    }
    
    if (i % 5 == 0)
    {
        Console.WriteLine("Buzz");
        continue;
    }
    
    Console.WriteLine(i);
}