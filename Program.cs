using c__crash;
using stock;

internal static class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("Welcome to the Inventory Management System! \n 1. Add Product \n 2. Search Product \n 3. Update Product Quantity \n 4. Exit \n\n Please enter your choice (1-4):");

    int? input = int.Parse(Console.ReadLine()!);

    Inventory inventory = new Inventory();

    while (input != 4)
    {
      switch (input)
      {
        case 1:
          Console.WriteLine("Enter product SKU:");
          int sku = int.Parse(Console.ReadLine()!);

          Console.WriteLine("Enter product name:");
          string name = Console.ReadLine()!;

          Console.WriteLine("Enter product quantity:");
          int quantity = int.Parse(Console.ReadLine()!);

          Console.WriteLine("Enter product price:");
          decimal price = decimal.Parse(Console.ReadLine()!);

          Product product = new Product(sku, name, quantity, price);

          try
          {
            inventory.AddProduct(product);
            Console.WriteLine($"Product {name} added successfully.");
          }
          catch (ArgumentException ex)
          {
            Console.WriteLine(ex.Message);
          }
          break;


        default:
          Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
          break;
      }

      break;
    }
  }
}
