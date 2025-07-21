namespace ShopMe.Entities.Models.ViewModels;

public class ShoppingCartVM
{
    public IEnumerable<ShoppingCart> CartsList { get; set; }
    public decimal TotalCarts { get; set; }
}
