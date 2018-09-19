using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreRepository.Startup))]
namespace BookStoreRepository
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
