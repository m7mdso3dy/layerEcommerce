using AutoMapper;
using layerEcommerce.Books;

namespace layerEcommerce;

public class layerEcommerceApplicationAutoMapperProfile : Profile
{
    public layerEcommerceApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
