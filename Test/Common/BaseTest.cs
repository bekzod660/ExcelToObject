using MarketManager.Infrastructure.Persistence;

namespace Employees.Tests.Common
{
    public abstract class BaseTest : IDisposable
    {
        protected readonly ApplicationDbContext context;
        public BaseTest()
        {
            context = InMemoryContext.Create();
        }
        public void Dispose()
        {
            InMemoryContext.Destroy(context);
        }
    }
}
