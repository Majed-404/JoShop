using Domain.Aggregates.Products.ParameterObjects;
using Domain.Aggregates.Products.ValueObjects;
using Domain.Common;
using Domain.Exceptions;

namespace Domain.Aggregates.Products
{
    public class Product : BaseAuditableEntity
    {
        public int CategoryId { get; }
        //public Category Category { get; } //TODO: add ref to category table
        public Guid ReferenceNumber { get; }
        public string NameAr { get; }
        public string NameEn { get; }
        public decimal Weight { get; }
        public decimal Coast { get; }
        public Money Price { get; }
        public int StockQuantity { get; }
        public int MaximumQuantityPerOrder { get; }
        public bool DisplayOnStore { get; }
        public bool IsDeleted { get; }
        public string ShortDescriptionAr { get; }
        public string ShortDescriptionEn { get; }
        public string DescriptionAr { get; }
        public string DescriptionEn { get; }
        public string Keywords { get; }
        public string MainImagePath { get; }
        public List<ProductAttachments> Attachments { get; } = new List<ProductAttachments>();

        private Product()
        {

        }

        private Product(int categoryId, string nameAr, string nameEn, decimal weight, decimal coast, Money price,
            int stockQuantity, int maximumQuantityPerOrder, bool displayOnStore, bool isDeleted, string shortDescriptionAr,
            string shortDescriptionEn, string descriptionAr, string descriptionEn, string keywords, string mainImagePath)
        {

            if (string.IsNullOrEmpty(nameAr))
                throw new ArgumentNullException("Name Arabic is cannot be null or empty.");

            if (string.IsNullOrEmpty(nameEn))
                throw new ArgumentNullException("Name English is cannot be null or empty.");

            ReferenceNumber = Guid.NewGuid();
            CategoryId = categoryId;
            NameAr = nameAr;
            NameEn = nameEn;
            Weight = weight;
            Coast = coast;
            Price = price;
            StockQuantity = stockQuantity;
            MaximumQuantityPerOrder = maximumQuantityPerOrder;
            DisplayOnStore = displayOnStore;
            IsDeleted = isDeleted;
            ShortDescriptionAr = shortDescriptionAr;
            ShortDescriptionEn = shortDescriptionEn;
            DescriptionAr = descriptionAr;
            DescriptionEn = descriptionEn;
            Keywords = keywords;
            MainImagePath = mainImagePath;
        }

        public static Product Create(ProductInfoParam product)
        {
            return new Product(product.CategoryId, product.NameAr, product.NameEn, product.Weight, product.Coast, product.Price,
                product.StockQuantity, product.MaximumQuantityPerOrder, product.DisplayOnStore, product.IsDeleted, product.ShortDescriptionAr,
                product.ShortDescriptionEn, product.DescriptionAr, product.DescriptionEn, product.Keywords, product.MainImagePath);
        }

        public void SetAttachments(List<ProductAttachments> attachments)
        {
            if (attachments is null)
                throw new ArgumentNullException("Product attachments cannot be null");

            if (attachments.Count == 0)
                throw new DomainException("attachments count cannot equal to 0");

            Attachments.AddRange(attachments);
        }
    }
}
