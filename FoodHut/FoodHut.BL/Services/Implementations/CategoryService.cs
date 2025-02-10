using AutoMapper;
using FoodHut.BL.DTOs;
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

    public async Task<ICollection<CategoryListItemDto>> GetAllAsync()
    {
        ICollection<Category> categories = await _repository.GetAllAsync();     
        return _mapper.Map<ICollection<CategoryListItemDto>>(categories);       
    }

    public async Task<CategoryViewItemDto?> GetByIdAsync(int id)
    {
        Category? category = await _repository.GetByIdAsync(id);        
        if(category == null)
        {
            return null;    
        }

        CategoryViewItemDto categoryDto = _mapper.Map<CategoryViewItemDto>(category);   
        return categoryDto; 
    }

    public async Task CreateAsync(CategoryCreateDto categoryCreateDto)
    {
        Category category = _mapper.Map<Category>(categoryCreateDto);   
        await _repository.CreateAsync(category);        
    }

    public async Task<bool> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
    {
        Category category = await _repository.GetByIdAsync(categoryUpdateDto.Id);   
        if(category == null)
        {
            return false;   
        }

        _mapper.Map(categoryUpdateDto, category);
        _repository.Update(category);       

        return true;        
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Category? category = await _repository.GetByIdAsync(id);
        if(category == null)
        {
            return false;   
        }
        _repository.Delete(category);   
        return true;    
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();       

}
