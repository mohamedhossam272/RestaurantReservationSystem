using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantReservationSystem.BLL.Services;
using RestaurantReservationSystem.BLL.Services.Imlementations;
using RestaurantReservationSystem.DAL.Data;
using RestaurantReservationSystem.DAL.Entities;
using RestaurantReservationSystem.DAL.Repositories.Implementations;
using RestaurantReservationSystem.DAL.Repositories.Interfaces;
using RestaurantReservationSystem.PL.Filters;

namespace RestaurantReservationSystem.PL
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllersWithViews(options =>
			{
				options.Filters.Add<CustomExceptionFilter>();
			});



			builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));





            builder.Services.AddControllersWithViews();



            // Register Repositories
            builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();

			// Register Services
			builder.Services.AddScoped<IRestaurantService, RestaurantService>();






            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Home/Error");

                });

            // Add Identity services
            builder.Services.AddIdentity<IdentityUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");



            //app.MapRazorPages();
            app.Run();
        }
	}
}