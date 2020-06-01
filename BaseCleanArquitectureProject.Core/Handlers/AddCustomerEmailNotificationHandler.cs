using System;
using System.Threading;
using System.Threading.Tasks;
using BaseCleanArquitectureProject.Core.Events;
using EnsureThat;
using MediatR;
using Salftech.SharedKernel.Interfaces;

namespace BaseCleanArquitectureProject.Core.Handlers {

	public class AddCustomerEmailNotificationHandler : AsyncRequestHandler<AddCustomerEvent> {
		private readonly IEmailSender _emailSender;

		public AddCustomerEmailNotificationHandler (IEmailSender emailSender) {
			_emailSender = emailSender;
		}

		protected override async Task Handle (AddCustomerEvent request, CancellationToken cancellationToken) {
			EnsureArg.IsNotNull(request.User);
			await _emailSender.SendEmailAsync(request.User.Email,
											$"Welcome {request.AddedCustomer.CompanyName} to BaseCleanArquitectureProject website",
											$"You successfully registered to our Website, use {request.User.UserName} and password {request.AddedCustomer.InitialPassword} to login into your account");
		}
	}

}