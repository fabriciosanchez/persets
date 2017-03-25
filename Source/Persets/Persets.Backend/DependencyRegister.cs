using Microsoft.Practices.Unity;
using Persets.Backend.Infrastructure;
using Persets.Backend.Interfaces;
using Persets.Backend.Repository;
using Persets.Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persets.Backend
{
    public static class DependencyRegister
    {
        /// <summary>
        /// TransientLifetimeManager - Cada Resolve gera uma nova instância.
        /// ContainerControlledLifetimeManager - Utiliza Singleton
        /// </summary>
        /// <param name="container"></param>
        public static void Register(UnityContainer container)
        {


            //Injecting dependencies
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IMembershipService, MembershipService>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IDbFactory, DbFactory>();


        }
    }

}