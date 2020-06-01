using System.Threading;
using System.Threading.Tasks;
using BaseCleanArquitectureProject.Core.Events;
using EnsureThat;
using MediatR;
using Salftech.SharedKernel.Interfaces;

namespace BaseCleanArquitectureProject.Core.Handlers {

	public class AddUserToCustomerEmailNotificationHandler : AsyncRequestHandler<AddUserToCustomerEvent> {
		private readonly IEmailSender _emailSender;
		public AddUserToCustomerEmailNotificationHandler(IEmailSender emailSender) {
			_emailSender = emailSender;
		}



		protected override async Task Handle (AddUserToCustomerEvent request, CancellationToken cancellationToken) {
			EnsureArg.IsNotNull(request.User);
			await _emailSender.SendEmailAsync(request.User.Email,
											$"Welcome to BaseCleanArquitectureProject website",
											$"You successfully added to the Customer {request.Customer.CompanyName}, use {request.User.UserName} and password {request.InitialPassword} to login into your account");
		}
	}

}