using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseCleanArquitectureProject.Core.Entities;
using BaseCleanArquitectureProject.Core.Entities.Customer;
using BaseCleanArquitectureProject.Core.Entities.Identity;
using BaseCleanArquitectureProject.Core.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Salftech.SharedKernel.Helpers;

namespace BaseCleanArquitectureProject.Infrastructure.Data {

	public class CustomerRepository : Repository<Customer, Guid>, ICustomerRepository {
		public CustomerRepository(BaseCleanArquitectureProjectDbContext dbContext, IMapper autoMapper, IValidator<Customer> validator): base(dbContext, autoMapper, validator) { }

		public override async Task<Customer> AddAsync (Customer entity, CancellationToken cancellationToken = default) {
			await ValidateAsync(entity, cancellationToken);
			var userStore = new UserStore<ApplicationUser, ApplicationRole, BaseCleanArquitectureProjectDbContext, Guid>(this._dbContext);
			using (var um = new UserManager<ApplicationUser>(userStore, null, new PasswordHasher<ApplicationUser>(), null, null, null, null, null, null)) {
				var user = new ApplicationUser(entity.Email);
				user.Email = entity.Email;
				await um.CreateAsync(user, entity.InitialPassword).ConfigureAwait(false);
				await um.AddToRoleAsync(user, Role.User).ConfigureAwait(false);
				entity.Administrator = user;
				var customer = Customer.AddCustomer(entity,user);
				await _dbContext.Set<Customer>().AddAsync(customer, cancellationToken);
				await _dbContext.SaveChangesAsync(cancellationToken);
				return entity;
			}
		}

		public async Task AddUserAsync (Customer customer, ApplicationUser applicationUser, CancellationToken cancellationToken) {
			var userStore = new UserStore<ApplicationUser, ApplicationRole, BaseCleanArquitectureProjectDbContext, Guid>(this._dbContext);
			using (var um = new UserManager<ApplicationUser>(userStore, null, new PasswordHasher<ApplicationUser>(), null, null, null, null, null, null)) {
				var user = new ApplicationUser(applicationUser.Email);
				user.Email = applicationUser.Email;
				await um.CreateAsync(user, applicationUser.InitialPassword).ConfigureAwait(false);
				await um.AddToRoleAsync(user, Role.User).ConfigureAwait(false);
				customer.AddUser(user, applicationUser.InitialPassword);
				_dbContext.Set<Customer>().Update(customer);
				await _dbContext.SaveChangesAsync(cancellationToken);
			}
		}
	}

}