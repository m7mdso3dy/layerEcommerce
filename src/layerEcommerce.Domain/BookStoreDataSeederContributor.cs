using System;
using System.Threading.Tasks;
using layerEcommerce.Books;
using layerEcommerce.Categories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace layerEcommerce;

public class layerEcommerceDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;
    private readonly IRepository<Category, Guid> _categoryRepository;

    public layerEcommerceDataSeederContributor(IRepository<Book, Guid> bookRepository, IRepository<Category, Guid> categoryRepository)
    {
        _bookRepository = bookRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.GetCountAsync() <= 0)
        {
            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "1984",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.84f
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1995, 9, 27),
                    Price = 42.0f
                },
                autoSave: true
            );
        }

        //Category
        if (await _categoryRepository.GetCountAsync() <= 0)
        {
            await _categoryRepository.InsertAsync(
               new Category
               {
                   Name = "Electronics",
                   NameAr = "إلكترونيات",
                   Description = "Devices, gadgets, and accessories",
                   DescriptionAr = "أجهزة وإكسسوارات",
               },
                autoSave: true
            );

            await _categoryRepository.InsertAsync(
               new Category
               {
                   Name = "Books",
                   NameAr = "كتب",
                   Description = "Novels, educational and reference books",
                   DescriptionAr = "روايات وكتب تعليمية ومرجعية",
               },
               autoSave: true
           );
            await _categoryRepository.InsertAsync(
              new Category
                 {
                Name = "Clothing",
                NameAr = "ملابس",
                Description = "Men’s and Women’s apparel",
                DescriptionAr = "ملابس للرجال والنساء",
            },
            autoSave: true
            );
        }
    }
}