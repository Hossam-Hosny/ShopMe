namespace ShopMe.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddWeb(this WebApplicationBuilder builder )
    {
        builder.Services.AddHttpContextAccessor();

    }
}
