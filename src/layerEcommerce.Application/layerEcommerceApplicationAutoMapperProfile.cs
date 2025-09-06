using AutoMapper;
using layerEcommerce.Books;
using layerEcommerce.Categories;
using layerEcommerce.Products;

namespace layerEcommerce;

public class layerEcommerceApplicationAutoMapperProfile : Profile
{
    public layerEcommerceApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateUpdateProductDto, Product>().ReverseMap();

        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<CreateUpdateCategoryDto, Category>().ReverseMap();

    }
}
