using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShopMe.Entities.Models;

public class AppUser : IdentityUser
{
    [Required]
    public string Name { get; set; }
    public string Address {  get; set; }
    public string City {  get; set; }
}
