using c__crash;
using stock;

internal static class Program
{
  private static void Main(string[] args)
  {
    int input = 0;

    Inventory inventory = new Inventory();

    while (input != 4)
    {
      Console.WriteLine("Welcome to the Inventory Management System! \n 1. Add Product \n 2. Search Product \n 3. Update Product Quantity \n 4. Exit \n\n Please enter your choice (1-4):");

      if (!int.TryParse(Console.ReadLine(), out input))
      {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
        continue;
      }

      switch (input)
      {
        case 1:
          while (true)
          {
            Console.WriteLine("Enter product SKU: ");
            string sku = Console.ReadLine()!;

            Console.WriteLine("Enter product name: ");
            string name = Console.ReadLine()!;

            Console.WriteLine("Enter product quantity:");
            int quantity = int.TryParse(Console.ReadLine()!, out quantity) ? quantity : 0;

            Console.WriteLine("Enter product price:");
            decimal price = decimal.TryParse(Console.ReadLine()!, out price) ? price : 0m;

            Product product = new Product(sku, name, quantity, price);

            try
            {
              inventory.AddProduct(product);
              Console.WriteLine($"Product {name} added successfully.");
              break;
            }
            catch (ArgumentException error)
            {
              Console.Error.WriteLine(error.Message);

              if (Utility.PromptContinue())
              {
                break;
              }
              else
              {
                continue;
              }
            }
          }
          break;

        case 2:
          while (true)
          {
            Console.WriteLine("Enter product SKU to search:");
            string sku = Console.ReadLine()!;

            try
            {
              Product product = inventory.SearchProduct(sku);
              Console.WriteLine(product);
              break;
            }
            catch (ArgumentException error)
            {
              Console.Error.WriteLine(error.Message);

              if (Utility.PromptContinue())
              {
                break;
              }
              else
              {
                continue;
              }
            }
          }
          break;

        case 3:
          while (true)
          {
            Console.WriteLine("Update product quantity by providing sku and quantity");

            Console.Write("Enter product sku: ");
            string sku = Console.ReadLine()!;

            Console.Write("Enter product quantity: ");
            int quantity = int.TryParse(Console.ReadLine()!, out quantity) ? quantity : 0;

            try
            {
              inventory.UpdateProductQuantity(sku, quantity);
              Console.WriteLine($"Product with {sku} successfully updated to {quantity} more item");
              break;
            }
            catch (ArgumentException error)
            {
              Console.Error.WriteLine(error.Message);

              if (Utility.PromptContinue())
              {
                break;
              }
              else
              {
                continue;
              }
            }
          }

          break;

        case 4:
          Console.WriteLine("Exiting the program. Goodbye!");
          break;

        default:
          Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
          break;
      }
    }
  }
}
