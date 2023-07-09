﻿// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

Product[] myProducts = new Product[]
{
    new Product { Name = "Jeans", Category = "Clothing", Price = 24.7 },
    new Product { Name = "Socks", Category = "Clothing", Price = 8.12 },
    new Product { Name = "Scooter", Category = "Vehicle", Price = 99.99 },
    new Product { Name = "Skateboard", Category = "Vehicle", Price = 24.99 },
    new Product { Name = "Skirt", Category = "Clothing", Price = 17.5 }
};

// sort by price
IEnumerable<Product> sortProductsByPrice = myProducts.OrderByDescending(prod => prod.Price);