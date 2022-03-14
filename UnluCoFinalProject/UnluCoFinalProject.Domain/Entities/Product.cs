namespace UnluCoFinalProject.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int Price { get; set; }
        public string IsSold { get; set; }
        public string IsSoldUserId { get; set; }
        public string ImagePath { get; set; }
        public bool IsOfferable { get; set; }
        public string UserId { get; set; }

    }
}
