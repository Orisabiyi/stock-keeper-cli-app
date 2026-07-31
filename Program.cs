using c__crash;
using stock;

internal static class Program
{
  private static void Main(string[] args)
  {
    int input = 0;

    Inventory inventory = new Inventory();

    while (input != 5)
    {
      Console.WriteLine("Welcome to the Inventory Management System! \n 1. Add Product \n 2. Search Product \n 3. Update Product Quantity \n 4. Sell Product \n 5. Exit \n\n Please enter your choice (1-5):");

      if (!int.TryParse(Console.ReadLine(), out input))
      {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
        continue;
      }

      switch (input)
      {
        case 1:
          Utility.RetryUntilSuccessOrExit(() =>
          {
            Console.Write("Enter product SKU: ");
            string sku = Console.ReadLine()!;

            Console.Write("Enter product name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter product quantity: ");
            int quantity = int.TryParse(Console.ReadLine()!, out quantity) ? quantity : 0;

            Console.Write("Enter product price: ");
            decimal price = decimal.TryParse(Console.ReadLine()!, out price) ? price : 0m;

            Product product = new Product(sku, name, quantity, price);

            inventory.AddProduct(product);
            Console.WriteLine($"Product {name} added successfully.");
          });
          break;

        case 2:
          Utility.RetryUntilSuccessOrExit(() =>
          {
            Console.WriteLine("Enter product SKU to search:");
            string sku = Console.ReadLine()!;

            Product product = inventory.SearchProduct(sku);
            Console.WriteLine($"Product {product.Name} found. {product.QuantityInStock} items in store");
          });
          break;

        case 3:
          Utility.RetryUntilSuccessOrExit(() =>
          {
            Console.Write("Enter product sku: ");
            string sku = Console.ReadLine()!;

            Console.Write("Enter product quantity: ");
            int quantity = int.TryParse(Console.ReadLine()!, out quantity) ? quantity : 0;

            inventory.UpdateProductQuantity(sku, quantity);
            Console.WriteLine($"Product with {sku} successfully updated to {quantity} more item");
          });
          break;

        case 4:
          Utility.RetryUntilSuccessOrExit(() =>
          {
            Console.Write("Enter product sku: ");
            string sku = Console.ReadLine()!;

            Console.Write("Enter quantity to be sold: ");
            int quantityToBeSold = int.TryParse(Console.ReadLine()!, out quantityToBeSold) ? quantityToBeSold : 0;

            inventory.SellProduct(sku, quantityToBeSold);
          });
          break;

        case 5:
          Console.WriteLine("Exiting the program. Goodbye!");
          break;

        default:
          Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
          break;
      }
    }
  }
}
