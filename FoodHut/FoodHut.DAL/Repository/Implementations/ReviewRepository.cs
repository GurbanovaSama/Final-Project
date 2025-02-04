using FoodHut.DAL.Contexts;
using FoodHut.DAL.Models;
using FoodHut.DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FoodHut.DAL.Repository.Implementations
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context) : base(context)
        {
            _context = context;     
        }

        public async Task<ICollection<Review>> GetReviewsByProductidAsync(int productid)
        {
            return await Table.Where(x => x.ProductId == productid).ToListAsync();  
        }
    }
}
