using System.Data.Entity.Infrastructure;
using System.Linq;
using Persets.Backend.Infrastructure;
using Persets.Backend.Interfaces;
using Persets.Backend.Models;

namespace Persets.Backend.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public void Add(Users pUsers)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<Users>(pUsers);
            DbContext.Set<Users>().Add(pUsers);
        }

        public virtual IQueryable<Users> GetAll()
        {
            return DbContext.Set<Users>();
        }

        public Users GetSingleByUsername(string username)
        {
            return GetAll().FirstOrDefault(x => x.UserName == username);
        }
    }
}