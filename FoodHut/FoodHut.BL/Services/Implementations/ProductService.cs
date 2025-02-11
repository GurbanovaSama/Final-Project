using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using FoodHut.BL.Utilities;
using FoodHut.DAL.Models;
using FoodHut.DAL.Repository.Abstractions;

namespace FoodHut.BL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Restaurant> _restaurantRepository;
    private readonly IRepository<Category> _categoryRepository;

    public ProductService(IRepository<Category> categoryRepository, IRepository<Restaurant> restaurantRepository, IRepository<Product> productRepository)
    {
        _categoryRepository = categoryRepository;
        _restaurantRepository = restaurantRepository;
        _productRepository = productRepository;
    }

    public async Task<ICollection<ProductListItemDto>> GetAllAsync()
    {
        ICollection<Product> products = (await _productRepository.GetAllAsync()).ToList();

        ICollection<ProductListItemDto> productDtos = products.Select(p => new ProductListItemDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            RestaurantId = p.RestaurantId,
            CategoryId = p.CategoryId
        }).ToList();

        return productDtos;
    }

    public async Task<ProductViewItemDto?> GetByIdAsync(int id)
    {
        Product? product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return null;

        return new ProductViewItemDto
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl
        };
    }

    public async Task CreateAsync(ProductCreateDto productCreateDto)
    {
        bool restaurantExists = await _restaurantRepository.GetByIdAsync(productCreateDto.RestaurantId) != null;

        bool categoryExists = await _categoryRepository.GetByIdAsync(productCreateDto.CategoryId) != null;

        if (!restaurantExists || !categoryExists)
            throw new Exception("Invalid RestaurantId or CategoryId!");

        string fileName = await productCreateDto.Image.SaveAsync("products");

        Product product = new Product
        {
            Name = productCreateDto.Name,
            Description = productCreateDto.Description,
            Price = productCreateDto.Price,
            ImageUrl = fileName,
            RestaurantId = productCreateDto.RestaurantId,
            CategoryId = productCreateDto.CategoryId
        };

        await _productRepository.CreateAsync(product);
    }

    public async Task<bool> UpdateAsync(ProductUpdateDto productUpdateDto)
    {
        Product? product = await _productRepository.GetByIdAsync(productUpdateDto.Id);
        if (product == null)
            return false;

        product.Name = productUpdateDto.Name;
        product.Description = productUpdateDto.Description;
        product.Price = productUpdateDto.Price;
        product.RestaurantId = productUpdateDto.RestaurantId;
        product.CategoryId = productUpdateDto.CategoryId;

        if (productUpdateDto.Image != null)
        {
            // Əvvəlki şəkli silir və yenisini əlavə edir
            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                string oldImagePath = Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "products", product.ImageUrl);
                if (File.Exists(oldImagePath))
                    File.Delete(oldImagePath);
            }

            string fileName = await productUpdateDto.Image.SaveAsync("products");
            product.ImageUrl = fileName;
        }

        _productRepository.Update(product);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Product? product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return false;

        if (!string.IsNullOrEmpty(product.ImageUrl))
        {
            string imagePath = Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "products", product.ImageUrl);
            if (File.Exists(imagePath))
                File.Delete(imagePath);
        }

        _productRepository.Delete(product);
        return true;
    }

    public async Task<int> SaveChangesAsync() => await _productRepository.SaveChangesAsync();       
}
