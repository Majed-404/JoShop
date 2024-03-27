using Domain.Aggregates.Products.ValueObjects;

namespace Domain.Aggregates.Products.ParameterObjects
{
    public class ProductInfoParam
    {
        public int CategoryId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public decimal Weight { get; set; }
        public decimal Coast { get; set; }
        public Money Price { get; set; }
        public int StockQuantity { get; set; }
        public int MaximumQuantityPerOrder { get; set; }
        public bool DisplayOnStore { get; set; }
        public bool IsDeleted { get; set; }
        public string ShortDescriptionAr { get; set; }
        public string ShortDescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string Keywords { get; set; }
        public string MainImagePath { get; set; }
    }
}
