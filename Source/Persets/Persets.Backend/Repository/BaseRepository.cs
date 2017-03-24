using Persets.Backend.Infrastructure;
using Persets.Backend.Models;

namespace Persets.Backend.Repository
{
    public class BaseRepository
    {
        #region Campos

        private PersetsDBEntities dataContext;

        #endregion

        #region Propriedades

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected PersetsDBEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        public BaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        #endregion
    }
}