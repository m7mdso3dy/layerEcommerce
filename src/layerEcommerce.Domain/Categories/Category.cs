using layerEcommerce.Products;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace layerEcommerce.Categories;

public class Category : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string NameAr { get; set; }
    public string Description { get; set; }
    public string DescriptionAr { get; set; }
    public ICollection<Product> Products { get; set; }
}