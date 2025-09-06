using System;
using System.ComponentModel.DataAnnotations;

namespace layerEcommerce.Products;

public class CreateUpdateProductDto
{
    [Required]
    [StringLength(64)]
    public string SKU { get; set; } = string.Empty;

    [Required]
    [StringLength(256)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(256)]
    public string NameAr { get; set; } = string.Empty;

    [Required]
    [StringLength(2000)]
    public string? Description { get; set; }

    [Required]
    [StringLength(2000)]
    public string? DescriptionAr { get; set; }

    [Required]
    [StringLength(512)]
    public string? ShortDescription { get; set; }

    [Required]
    [StringLength(512)]
    public string? ShortDescriptionAr { get; set; }

    [Required]
    public Guid CategoryId { get; set; } 

    [Required]
    public decimal Price { get; set; }

    public bool IsActive { get; set; } = true;
}