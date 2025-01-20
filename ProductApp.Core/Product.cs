namespace ProductApp.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ProductPrice> ProductPrices { get; set; } = new List<ProductPrice>();
    }
}
