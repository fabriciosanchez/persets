using System.Linq;
using Persets.Backend.Models;

namespace Persets.Backend.Interfaces
{
    public interface IUserRepository
    {
        void Add(Users pUsers);
        IQueryable<Users> GetAll();
        Users GetSingleByUsername(string username);
    }
}