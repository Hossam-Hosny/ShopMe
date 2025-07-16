using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using ShopMe.DataAccess.Context;
using ShopMe.Utilites.Email;

namespace ShopMe.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddWeb(this WebApplicationBuilder builder )
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
        })
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();

        builder.Services.AddSingleton<IEmailSender, EmailSender>();

    }
}
