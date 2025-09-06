using layerEcommerce.Categories;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace layerEcommerce.Products;

public class Product : FullAuditedAggregateRoot<Guid>
{
    public string SKU { get; set; }
    public string Name { get; set; }
    public string NameAr { get; set; }
    public string Description { get; set; }
    public string DescriptionAr { get; set; }
    public string ShortDescription { get; set; }
    public string ShortDescriptionAr { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }  
}