namespace ProductApp.Core
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ProductPrice>? ProductPrices { get; set; }
    }
}
