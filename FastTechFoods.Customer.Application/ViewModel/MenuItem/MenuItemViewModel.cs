﻿using FastTechFoods.Customer.Application.ViewModel.Base;
using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Customer.Application.ViewModel.MenuItem;
public class MenuItemViewModel : ViewModelBase
{
    [Required(ErrorMessage = "The name is required.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "The description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "The price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "The price must be greater than zero.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The category is required.")]
    public string Category { get; set; }

    [Required(ErrorMessage = "The availability status is required.")]
    public bool IsAvailable { get; set; }
 }
