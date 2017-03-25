using Microsoft.Owin.Security.OAuth;
using Persets.Backend.Interfaces;
using Persets.Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Persets.Backend.Security
{
 
        public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
           private readonly  IMembershipService _userService;
            private readonly IEncryptionService _encryptionService;
        private readonly IUserRepository _userRepository;


        public SimpleAuthorizationServerProvider(IMembershipService userService, IEncryptionService encryptionService, IUserRepository userRepository)
        {
                _userService = userService;
            _encryptionService = encryptionService;
            _userRepository = userRepository;
        }

            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }


     


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                var user = _userRepository.GetSingleByUsername(context.UserName);


            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos");
                return;
            }


            if (user.Password == _encryptionService.EncryptPassword(context.Password, user.PasswordSalt))
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos");
                return;
            }


                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));

                GenericPrincipal principal = new GenericPrincipal(identity, new string[] { "" });
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }





        }
}