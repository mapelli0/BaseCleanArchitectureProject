using System;
using System.Threading;
using System.Threading.Tasks;
using BaseCleanArquitectureProject.Core.Entities;
using BaseCleanArquitectureProject.Core.Entities.Customer;
using BaseCleanArquitectureProject.Core.Entities.Identity;
using Salftech.SharedKernel.Interfaces;

namespace BaseCleanArquitectureProject.Core.Interfaces {

	public interface ICustomerRepository : IRepository<Customer, Guid> {
		Task AddUserAsync (Customer customer, ApplicationUser applicationUser, CancellationToken cancellationToken);
	}

}