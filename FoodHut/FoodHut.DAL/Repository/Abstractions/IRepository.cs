using FoodHut.DAL.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace FoodHut.DAL.Repository.Abstractions;

public interface IRepository<T> where T : BaseEntity, new()     
{
    DbSet<T> Table { get; }
    Task<ICollection<T>> GetAllAsync(params string[] includes); 
    Task<T?> GetByIdAsync (int id, params string[] includes);     
    Task CreateAsync (T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<int> SaveChangesAsync();
}
