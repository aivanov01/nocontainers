using System.Text.Json.Serialization;

namespace BuisnessCentral.Models
{
    public class CatalogItemModel
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CatalogBrandId { get; set; }
        public int CatalogTypeId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PictureFileName { get; set; } = string.Empty;
        public double Price { get; set; }
        public int AvailableStock { get; set; }
        public int MaxStockThreshold { get; set; }
        public bool OnReorder { get; set; }
        public int RestockThreshold { get; set; }

    }
}
