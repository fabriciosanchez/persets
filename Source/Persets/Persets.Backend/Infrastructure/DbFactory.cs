using Persets.Backend.Models;

namespace Persets.Backend.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        PersetsDBEntities dbContext;

        public PersetsDBEntities Init()
        {
            return dbContext ?? (dbContext = new PersetsDBEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}