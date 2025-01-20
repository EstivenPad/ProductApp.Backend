namespace ProductApp.Core
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public bool IsSelected { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
    }
}
