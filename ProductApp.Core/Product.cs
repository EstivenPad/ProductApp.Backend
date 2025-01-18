namespace ProductApp.Core
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int ColorId { get; set; }
        public Color? Color { get; set; }
    }
}
