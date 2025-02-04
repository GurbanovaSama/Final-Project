using FoodHut.DAL.Models;

namespace FoodHut.DAL.Repository.Abstractions
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<ICollection<Review>> GetReviewsByProductidAsync(int productid);        
    }
}
