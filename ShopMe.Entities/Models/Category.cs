using System.ComponentModel.DataAnnotations;

namespace ShopMe.Entities.Models;

public class Category
{

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; } = DateTime.Now;

}
