using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using Persets.Backend.Interfaces;
using System.Web.Http;
using Persets.Backend.Models;
using Persets.Backend.Services;
using Persets.Backend.Data;

namespace Persets.Backend.Controllers
{

    [AllowAnonymous]
    public class UserController : ApiController
    {
        private readonly IMembershipService _membershipService;

        public UserController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [Route("api/users")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel user)
        {
            HttpResponseMessage response;
            string EntityGuid = "~";

            try
            {
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                else
                {
                    Users _user = _membershipService.CreateUser(user.CompleteName, user.UserName, user.Email, user.Password, user.BirthdayDate);

                    if (_user != null)
                    {
                        EntityGuid = _user.GUID;
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            if (response != null)
                LogsDB.AddLog(LogsDB.eOperation.Post, LogsDB.eEntity.User, EntityGuid, response.IsSuccessStatusCode);

            return response;
        }
    }
}