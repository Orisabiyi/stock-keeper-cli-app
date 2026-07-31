using c__crash;

namespace stock;

public class Inventory
{
  Dictionary<string, Product> products = new Dictionary<string, Product>();

  // product to inventory
  public void AddProduct(Product product)
  {
    if (products.TryGetValue(product.Sku, out Product? existingProduct))
    {
      throw new ArgumentException($"Product with SKU {product.Sku} already exists in the inventory as {existingProduct.Name}.");
    }

    products.Add(product.Sku, product);
  }

  // look up a product with sku
  public Product SearchProduct(string sku)
  {
    if (products.TryGetValue(sku, out Product? product))
    {
      return product;
    }
    else
    {
      throw new ArgumentException($"Product with SKU {sku} does not exist in the inventory.");
    }
  }

  // restock product
  public void UpdateProductQuantity(string sku, int newQuantity)
  {
    if (products.TryGetValue(sku, out Product? product))
    {
      product.QuantityInStock = newQuantity;
    }
    else
    {
      throw new ArgumentException($"Product with SKU {sku} does not exist in the inventory.");
    }
  }

  // sell a product
  public void SellProduct(string sku, int quantityToBeSold = 0)
  {
    Product product = SearchProduct(sku);

    if (product.QuantityInStock < quantityToBeSold)
    {
      throw new ArgumentException($"Product with SKU {sku} has lower quantity in store to be sold");
    }

    product.QuantityInStock -= quantityToBeSold;

    Console.WriteLine(product.QuantityInStock);
  }

}
