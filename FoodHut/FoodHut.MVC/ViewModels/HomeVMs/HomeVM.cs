﻿using FoodHut.BL.DTOs;


namespace FoodHut.MVC.ViewModels;

public class HomeVM
{
    public ICollection<CategoryViewItemDto> Categories { get; set; }
    public ICollection<ProductViewItemDto> Products { get; set; }
    public ICollection<ReviewViewItemDto> Reviews { get; set; }
    public SettingsDTO Settings { get; set; }

}
