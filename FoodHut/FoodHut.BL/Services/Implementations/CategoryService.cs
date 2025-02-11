using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.BL.Exceptions;
using FoodHut.BL.Services.Abstractions;
using FoodHut.DAL.Models;
using FoodHut.DAL.Repository.Abstractions;

namespace FoodHut.BL.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IRepository<Category> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<Category> GetByIdAsync(int id) => await _repository.GetByIdAsync(id) ?? throw new BaseException();

    public async Task<Category> GetByIdWithChildrenAsync(int id) => await _repository.GetByIdAsync(id, "Producs") ?? throw new BaseException();

    public async Task<CategoryUpdateDto> GetByIdForUpdateAsync(int id) => _mapper.Map<CategoryUpdateDto>(await GetByIdAsync(id));

    public async Task<ICollection<CategoryListItemDto>> GetCategoryListItemsAsync() => _mapper.Map<ICollection<CategoryListItemDto>>(await _repository.GetAllAsync());

    public async Task<ICollection<CategoryViewItemDto>> GetCategoryViewItemsAsync() => _mapper.Map<ICollection<CategoryViewItemDto>>(await _repository.GetAllAsync("Products"));

    public async Task CreateAsync(CategoryCreateDto dto)
    {
        Category category = _mapper.Map<Category>(dto);

        await _repository.CreateAsync(category);
    }

    public async Task UpdateAsync(CategoryUpdateDto dto)
    {
        Category oldCategory = await GetByIdAsync(dto.Id);
        Category category = _mapper.Map<Category>(dto);
        category.CreatedAt = oldCategory.CreatedAt;

        _repository.Update(category);
    }

    public  async Task DeleteAsync(int id)
    {
        Category category = await GetByIdWithChildrenAsync(id);
        if (category.Products.Count != 0) throw new BaseException("This category has places!");
        _repository.Delete(category);
    }


    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();      
}
