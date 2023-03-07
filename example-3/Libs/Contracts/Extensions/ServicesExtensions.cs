using Microsoft.Extensions.DependencyInjection;

namespace Contracts.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddOrderGenerator(this IServiceCollection self)
        {
            self.AddSingleton<IOrderGenerator, OrderGenerator>();
        }
    }
}