﻿using Microsoft.AspNetCore.Http;

namespace FoodHut.BL.DTOs;

public record ProductViewItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int RestaurantId { get; set; }
    public int CategoryId { get; set; }
}
