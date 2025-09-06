using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using layerEcommerce.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;

namespace layerEcommerce.Categories;

[Authorize(layerEcommercePermissions.Categories.Default)]
public class CategoryAppService : ApplicationService, ICategoryAppService
{
    private readonly IRepository<Category, Guid> _repository;

    public CategoryAppService(IRepository<Category, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<CategoryDto> GetAsync(Guid id)
    {
        var book = await _repository.GetAsync(id);
        return ObjectMapper.Map<Category, CategoryDto>(book);
    }

    public async Task<PagedResultDto<CategoryDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await _repository.GetQueryableAsync();
        var query = queryable
            .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? "Name" : input.Sorting)
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        var books = await AsyncExecuter.ToListAsync(query);
        var totalCount = await AsyncExecuter.CountAsync(queryable);

        return new PagedResultDto<CategoryDto>(
            totalCount,
            ObjectMapper.Map<List<Category>, List<CategoryDto>>(books)
        );
    }

    [Authorize(layerEcommercePermissions.Categories.Create)]
    public async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
    {
        var book = ObjectMapper.Map<CreateUpdateCategoryDto, Category>(input);
        await _repository.InsertAsync(book);
        return ObjectMapper.Map<Category, CategoryDto>(book);
    }

    [Authorize(layerEcommercePermissions.Categories.Edit)]
    public async Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
    {
        var book = await _repository.GetAsync(id);
        ObjectMapper.Map(input, book);
        await _repository.UpdateAsync(book);
        return ObjectMapper.Map<Category, CategoryDto>(book);
    }

    [Authorize(layerEcommercePermissions.Categories.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
