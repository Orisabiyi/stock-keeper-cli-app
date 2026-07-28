using c__crash;

namespace stock;

public class Inventory
{
  Dictionary<string, Product> products = new Dictionary<string, Product>();

  public void AddProduct(Product product)
  {
    if (products.TryGetValue(product.Sku, out Product? existingProduct))
    {
      throw new ArgumentException($"Product with SKU {product.Sku} already exists in the inventory as {existingProduct.Name}.");
    }

    products.Add(product.Sku, product);
  }

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

}
