using TestTsskAboutClientServices_TraineeMaUi_.Models;

namespace TestTsskAboutClientServices_TraineeMaUi_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ClientControlServiceContext>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=ClientOperation}/{action=AddClient}/{id?}");

            app.Run();
        }
    }
}