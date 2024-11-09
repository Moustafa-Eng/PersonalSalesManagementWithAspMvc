using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MotoFix.BLL.Interfaces;
using MotoFix.BLL.Repositories;
using MotoFix.DAL.Context;
using MotoFix.PL.MappingProfiles;

namespace MotoFix.PL
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddAutoMapper(M => M.AddProfiles(new List<Profile>() { new ProductProfile() }));

			builder.Services.AddIdentity<IdentityUser, IdentityRole>(Options =>
			{
				Options.Password.RequireNonAlphanumeric = true;
				Options.Password.RequireDigit = true;
				Options.Password.RequireLowercase = true;
				Options.Password.RequireUppercase = true;
			}).AddEntityFrameworkStores<ApplicationDbContext>()
			.AddDefaultTokenProviders();




			var app = builder.Build();


			// Seed User
			using var scope = app.Services.CreateScope();
			var Services = scope.ServiceProvider;

			try
			{
				var userManager = Services.GetRequiredService<UserManager<IdentityUser>>();
				await ApplicationDbContextSeed.SeedUserAsync(userManager);
			}
			catch (Exception ex)
			{

                Console.WriteLine($"An Error Occured During seeding User {ex}");
            }



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

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Account}/{action=Login}/{id?}");

			app.Run();
		}

	}
}
