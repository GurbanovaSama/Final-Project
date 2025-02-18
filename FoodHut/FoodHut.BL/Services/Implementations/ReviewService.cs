using AutoMapper;
using FoodHut.BL.DTOs;
using FoodHut.BL.Services.Abstractions;
using FoodHut.DAL.Models;
using FoodHut.DAL.Repository.Abstractions;

namespace FoodHut.BL.Services.Implementations;

public class ReviewService : IReviewService
{
    private readonly IRepository<Review> _reviewRepository;
    private readonly IMapper _mapper;

    public ReviewService(IMapper mapper, IRepository<Review> reviewRepository)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
    }

    public async Task<ICollection<ReviewViewItemDto>> GetViewItemsAsync() => _mapper.Map<ICollection<ReviewViewItemDto>>(await _reviewRepository.GetAllAsync());

    public async Task<ICollection<ReviewListItemDto>> GetAllAsync()
    {
        ICollection<Review> reviews = (await _reviewRepository.GetAllAsync()).ToList();
        ICollection<ReviewListItemDto> reviewDtos = _mapper.Map<ICollection<ReviewListItemDto>>(reviews);
        return reviewDtos;
    }

    public async Task<ReviewViewItemDto?> GetByIdAsync(int id)
    {
        Review? review = await _reviewRepository.GetByIdAsync(id);
        if (review == null)
        {
            return null;
        }

        ReviewViewItemDto reviewDto = _mapper.Map<ReviewViewItemDto>(review);
        return reviewDto;
    }

    public async Task CreateAsync(ReviewCreateDto reviewCreateDto)
    {
        Review review = _mapper.Map<Review>(reviewCreateDto);
        await _reviewRepository.CreateAsync(review);
    }

    public async Task UserCreateAsync(UserCreateDto userCreateDto, string UserId, string UserRole, string UserName)
    {
        Review review = _mapper.Map<Review>(userCreateDto);
        review.UserName = UserName;
        review.UserId = UserId;
        review.UserRole = UserRole;
        //review.RestaurantId = 1;
        await _reviewRepository.CreateAsync(review);
    }

    public async Task<bool> UpdateAsync(ReviewUpdateDto reviewUpdateDto)
    {

        Review? existingReview = await _reviewRepository.GetByIdAsync(reviewUpdateDto.Id);
        if (existingReview == null)
        {
            return false;
        }

        existingReview.Comment = reviewUpdateDto.Comment;
        existingReview.Rating = reviewUpdateDto.Rating;

        _reviewRepository.Update(existingReview);
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        Review? review = await _reviewRepository.GetByIdAsync(id);
        if (review == null)
        {
            return false;
        }

        _reviewRepository.Delete(review);
        return true;
    }

    public async Task<int> SaveChangesAsync() => await _reviewRepository.SaveChangesAsync();

}
