using layerEcommerce.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace layerEcommerce.Categories;

public class CreateUpdateCategoryDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(128)]
    public string NameAr { get; set; } = string.Empty;

    [Required]
    [StringLength(512)]
    public string? Description { get; set; }

    [Required]
    [StringLength(512)]
    public string? DescriptionAr { get; set; }
    public ProductType ProductType { get; set; }
}