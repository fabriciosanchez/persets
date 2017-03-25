using System;
using Persets.Backend.Models;

namespace Persets.Backend.Services
{
    public interface IMembershipService
    {
        Users CreateUser(string completeName, string username, string email, string password, DateTime birthdayDate);
        string ForgotPassword(string email);
    }
}