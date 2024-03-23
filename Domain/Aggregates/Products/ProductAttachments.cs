using Domain.Common;

namespace Domain.Aggregates.Products
{
    public class ProductAttachments : BaseAuditableEntity
    {
        public string Path { get; }
        public string ContentType { get; }
        public int Order { get; }

        private ProductAttachments()
        {
        }

        private ProductAttachments(string path, string contentType, int order)
        {
            Path = path;
            ContentType = contentType;
            Order = order;
        }

        public static ProductAttachments Create(string path, string contentType, int order)
        {
            return new ProductAttachments(path, contentType, order);
        }
    }
}
