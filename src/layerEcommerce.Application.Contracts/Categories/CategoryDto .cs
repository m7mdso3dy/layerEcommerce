using layerEcommerce.Products;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace layerEcommerce.Categories;

public class CategoryDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public string NameAr { get; set; }
    public string Description { get; set; }
    public string DescriptionAr { get; set; }
    public List<ProductDto> Products { get; set; } = new();
}