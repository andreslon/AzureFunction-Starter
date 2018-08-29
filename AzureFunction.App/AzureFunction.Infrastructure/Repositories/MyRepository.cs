using AzureFunction.Infrastructure.Repositories.Interfaces;

namespace AzureFunction.Infrastructure.Repositories
{
    public class MyRepository : IMyRepository
    {
        public string Greet()
        {
            return "Hello World!";
        }
    }
}
