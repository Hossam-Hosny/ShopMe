﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopMe.Entities.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [DisplayName("Image")]
    public string ImagePath { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    [DisplayName("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
