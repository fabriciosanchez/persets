using System;
using Persets.Backend.Infrastructure;
using Persets.Backend.Interfaces;
using Persets.Backend.Models;

namespace Persets.Backend.Services
{
    public class MembershipService : IMembershipService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public MembershipService(IUserRepository userRepository, IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        } 
        #endregion

        #region IMembershipService Implementation

        public Users CreateUser(string completeName, string username, string email, string password, DateTime birthdayDate)
        {
            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
                throw new Exception("Username is already in use.");

            var passwordSalt = _encryptionService.CreateSalt();

            var user = new Users
            {
                CompleteName = completeName, 
                UserName = username,
                Email = email,
                PasswordSalt = passwordSalt,
                Password = _encryptionService.EncryptPassword(password, passwordSalt),
                BirthdayDate = birthdayDate
            };

            _userRepository.Add(user);

            _unitOfWork.Commit();

            return user;
        }








        #endregion
    }
}