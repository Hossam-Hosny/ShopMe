using System.ComponentModel.DataAnnotations;

namespace ShopMe.Entities.Models.ViewModels;

public class ShoppingCart
{
    public Product Product { get; set; }
    [Range(1,100 , ErrorMessage ="enter value between 1 to 100")]
    public int Count { get; set; }
}
