using layerEcommerce.Categories;
using System;
using Volo.Abp.Application.Dtos;

namespace layerEcommerce.Products;

public class ProductDto : FullAuditedEntityDto<Guid>
{
    public string SKU { get; set; }
    public string Name { get; set; }
    public string NameAr { get; set; }
    public string Description { get; set; }
    public string DescriptionAr { get; set; }
    public string ShortDescription { get; set; }
    public string ShortDescriptionAr { get; set; }
    public Guid CategoryId { get; set; }
    public virtual CategoryDto Category { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}