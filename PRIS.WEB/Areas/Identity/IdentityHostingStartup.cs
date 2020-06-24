using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PRIS.WEB.Areas.Identity.IdentityHostingStartup))]
namespace PRIS.WEB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}