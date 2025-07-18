using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMe.Entities.Models;

public class ShoppingCart
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    [ValidateNever]
    public Product Product { get; set; }
    [Range(1, 100, ErrorMessage = "enter value between 1 to 100")]
    public int Count { get; set; }

    public string AppUserId { get; set; }
    [ForeignKey("AppUserId")]
    [ValidateNever]
    public AppUser AppUser { get; set; }

}
