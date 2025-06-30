using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopMe.Entities.Models.ViewModels;

public class ProductViewModel
{
    public Product Product { get; set; }
    public IEnumerable<SelectListItem> CategoryList { get; set; }
}
