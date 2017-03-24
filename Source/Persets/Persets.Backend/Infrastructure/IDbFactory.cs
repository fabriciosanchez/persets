using System;
using Persets.Backend.Models;

namespace Persets.Backend.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        PersetsDBEntities Init();
    }
}