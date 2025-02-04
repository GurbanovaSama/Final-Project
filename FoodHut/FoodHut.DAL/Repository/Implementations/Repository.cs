using FoodHut.DAL.Contexts;
using FoodHut.DAL.Models.Base;
using FoodHut.DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FoodHut.DAL.Repository.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    
    public async Task<ICollection<T>> GetAllAsync(params string[] includes)
    {
        IQueryable<T> query = Table;

        if(includes.Length > 0)
        {
            foreach(string include in includes)
            {
                query = query.Include(include); 
            }
        }
        return await query.ToListAsync();       
    }

    public async Task<T?> GetByIdAsync(int id, params string[] includes)
    {
        IQueryable<T> query = Table;

        if (includes.Length > 0)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }
        return await query.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow.AddHours(4);
        await Table.AddAsync(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow.AddHours(4);
        Table.Update(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);       
    }

    public async Task<int> SaveChangesAsync()=> await _context.SaveChangesAsync();

}
