using System.Threading;
using System.Threading.Tasks;
using BaseCleanArquitectureProject.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BaseCleanArquitectureProject.Extensions {

	public static class WebHost {
		public static async Task<IHost> SeedAsync (this IHost webHost, CancellationToken cancellationToken) {
			using (var scope = webHost.Services.GetService<IServiceScopeFactory>().CreateScope()) {
				using (var dbContext = scope.ServiceProvider.GetRequiredService<BaseCleanArquitectureProjectDbContext>()) {
					await dbContext.SeedData(cancellationToken).ConfigureAwait(false);
					return webHost;
				}
			}
		}
	}

}