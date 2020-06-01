using System;
using BaseCleanArquitectureProject.Core.Entities.Identity;
using BaseCleanArquitectureProject.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseCleanArquitectureProject.Infrastructure {

	public static class StartupSetup {
		public static void AddDbContext (this IServiceCollection services, IConfiguration configuration) {

			string connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<BaseCleanArquitectureProjectDbContext>(opt => opt.UseSqlServer(connectionString));

			services.AddIdentity<ApplicationUser, ApplicationRole>()
					.AddEntityFrameworkStores<BaseCleanArquitectureProjectDbContext>()
					.AddDefaultTokenProviders()
					.AddRoleManager<RoleManager<ApplicationRole>>()
					.AddUserManager<UserManager<ApplicationUser>>();


			services.Configure<IdentityOptions>(opt => {
													// Password settings
													opt.Password.RequireDigit = true;
													opt.Password.RequiredLength = 8;
													opt.Password.RequireNonAlphanumeric = false;
													opt.Password.RequireUppercase = false;
													opt.Password.RequireLowercase = false;
													opt.Password.RequiredUniqueChars = 2;
													// Lockout settings
													opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
													opt.Lockout.MaxFailedAccessAttempts = 5;
													opt.Lockout.AllowedForNewUsers = true;
												});

		}
	}

}