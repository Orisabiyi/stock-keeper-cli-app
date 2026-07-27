namespace c__crash;

public class Product
{
  public int Sku
  {
    get; set;
  }

  public string Name
  {
    get; set;
  } = String.Empty;

  public int QuantityInStock
  {
    get; set;
  }

  public decimal Price
  {
    get; set;
  }

  public Product(int sku, string productName, int productQuantity, decimal productPrice)
  {
    Sku = sku;
    Name = productName;
    QuantityInStock = productQuantity;
    Price = productPrice;
  }
}
