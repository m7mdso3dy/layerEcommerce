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

namespace layerEcommerce.Products;

[Authorize(layerEcommercePermissions.Products.Default)]
public class ProductAppService : ApplicationService, IProductAppService
{
    private readonly IRepository<Product, Guid> _repository;

    public ProductAppService(IRepository<Product, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        var book = await _repository.GetAsync(id);
        return ObjectMapper.Map<Product, ProductDto>(book);
    }

    public async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await _repository.GetQueryableAsync();
        var query = queryable
            .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? "Name" : input.Sorting)
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        var books = await AsyncExecuter.ToListAsync(query);
        var totalCount = await AsyncExecuter.CountAsync(queryable);

        return new PagedResultDto<ProductDto>(
            totalCount,
            ObjectMapper.Map<List<Product>, List<ProductDto>>(books)
        );
    }

    [Authorize(layerEcommercePermissions.Products.Create)]
    public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
    {
        var book = ObjectMapper.Map<CreateUpdateProductDto, Product>(input);
        await _repository.InsertAsync(book);
        return ObjectMapper.Map<Product, ProductDto>(book);
    }

    [Authorize(layerEcommercePermissions.Products.Edit)]
    public async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
    {
        var book = await _repository.GetAsync(id);
        ObjectMapper.Map(input, book);
        await _repository.UpdateAsync(book);
        return ObjectMapper.Map<Product, ProductDto>(book);
    }

    [Authorize(layerEcommercePermissions.Products.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
