using System;
using BaseCleanArquitectureProject.Core.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseCleanArquitectureProject.Infrastructure.Data.Config {

	public class CustomerConfiguration : BaseConfiguration<Customer, Guid> {

		public override void Configure (EntityTypeBuilder<Customer> builder) {
			base.Configure(builder);
			builder.HasOne(c => c.Administrator);
			builder.Ignore(e => e.InitialPassword);
			builder.HasOne(c => c.Address);
			
			AddNavigationProperty(builder, nameof(Customer.Users));

		}
	}

}