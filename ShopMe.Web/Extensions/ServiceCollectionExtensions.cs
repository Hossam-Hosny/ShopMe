using Microsoft.AspNetCore.Identity;
using ShopMe.DataAccess.Context;

namespace ShopMe.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddWeb(this WebApplicationBuilder builder )
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<AppDbContext>();

    }
}
