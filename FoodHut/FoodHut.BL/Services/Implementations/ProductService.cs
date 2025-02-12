using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.BL.Exceptions;
using FoodHut.BL.Services.Abstractions;
using FoodHut.BL.Utilities;
using FoodHut.DAL.Models;
using FoodHut.DAL.Repository.Abstractions;
using FoodHut.DAL.Repository.Implementations;

namespace FoodHut.BL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public ProductService(IRepository<Category> categoryRepository, IRepository<Restaurant> restaurantRepository, IRepository<Product> productRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Product> GetByIdAsync(int id) => await _productRepository.GetByIdAsync(id, "Category") ?? throw new BaseException();


    public async Task<ProductUpdateDto> GetByIdForUpdateAsync(int id) => _mapper.Map<ProductUpdateDto>(await GetByIdAsync(id));


    public async Task<ICollection<ProductListItemDto>> GetListItemsAsync() => _mapper.Map<ICollection<ProductListItemDto>>(await _productRepository.GetAllAsync("Category"));


    public async Task<ICollection<ProductViewItemDto>> GetViewItemsAsync() => _mapper.Map<ICollection<ProductViewItemDto>>(await _productRepository.GetAllAsync("Category"));


    public async Task CreateAsync(ProductCreateDto dto)
    {
        if (await _categoryRepository.GetByIdAsync(dto.CategoryId) is null) throw new BaseException("Category not found!");

        Product product = _mapper.Map<Product>(dto);

        product.ImageUrl = await dto.Image.SaveAsync("products");

        await _productRepository.CreateAsync(product);
    }

    public async Task UpdateAsync(ProductUpdateDto dto)
    {
        if (await _categoryRepository.GetByIdAsync(dto.CategoryId) is null) throw new BaseException("Category not found!");

        Product oldProduct = await GetByIdAsync(dto.Id);
        Product product = _mapper.Map<Product>(dto);
        product.CreatedAt = oldProduct.CreatedAt;

        product.ImageUrl = dto.Image is not null ? await dto.Image.SaveAsync("products") : oldProduct.ImageUrl;

        _productRepository.Update(product);

        if (dto.Image is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "products", oldProduct.ImageUrl));
    }


    public async Task DeleteAsync(int id)
    {
        Product product = await GetByIdAsync(id);

        _productRepository.Delete(product);

        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "products", product.ImageUrl));
    }


    public async Task<int> SaveChangesAsync()=> await _productRepository.SaveChangesAsync();    

}
