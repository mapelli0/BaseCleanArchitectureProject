using BaseCleanArquitectureProject.Core.Entities;
using BaseCleanArquitectureProject.Core.Entities.Customer;
using BaseCleanArquitectureProject.Core.Entities.Identity;
using MediatR;
using Salftech.SharedKernel;
using Salftech.SharedKernel.Interfaces;

namespace BaseCleanArquitectureProject.Core.Events {

	public class AddCustomerEvent : BaseDomainEvent {
		public Customer AddedCustomer { get; private set; }

		public ApplicationUser User { get; private set; }

		public AddCustomerEvent (Customer addedCustomer, ApplicationUser user) {
			AddedCustomer = addedCustomer;
			User = user;
		}
	}

}