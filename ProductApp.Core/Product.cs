namespace ProductApp.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
