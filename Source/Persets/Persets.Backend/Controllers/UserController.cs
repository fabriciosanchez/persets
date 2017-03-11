using Persets.Backend.Interfaces;
using System.Web.Http;

namespace Persets.Backend.Controllers
{

    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        


    }
}
