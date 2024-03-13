using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todomorrow.Domain.Notifications;
using Todomorrow.Domain.UserFollowers;
using Todomorrow.Domain.Users;

namespace Todomorrow.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationContext _notification;
        private readonly IMemoryCache _memoryCache;

        public UserService(IUserRepository userRepository, INotificationContext notification, IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _notification = notification;
            _memoryCache = memoryCache;
        }

        //TODO Improve this logic
        public async Task<User> Follow(string userEmail, Guid userId)
        {
            User user = await _userRepository.GetProfile(userEmail);

            UserFollower userFollower = new()
            {
                FolloweeId = userId,
                FollowerId = user.Id
            };

            user.AddFollower(userFollower);

            return await _userRepository.Update(user);
        }

        //TODO Improve this logic
        public async Task<User> Unfollow(string userEmail, Guid userIdToUnfollow)
        {
            User user = await _userRepository.GetProfile(userEmail);
            UserFollower userFollower = user.Followees.SingleOrDefault(x => x.FolloweeId == userIdToUnfollow);
            user.RemoveFollower(userFollower);

            return await _userRepository.Update(user);
        }

        //TODO Improve this logic
        public async Task<UserRole> SignIn(User user, string token)
        {
            User userRegistered = await _userRepository.GetProfile(user.Email);
            if (userRegistered is null)
            {
                _notification.AddForbiddenError(UserError.INVALID_CREDENTIALS);
                return null;
            }

            bool isValid = await SendOrValidateMFAToken(token, userRegistered);

            if (!isValid)
            {
                return null;
            }

            List<string> roles = new()
            {
                "Write",
                "Read"
            };

            return new UserRole(userRegistered, roles);
        }

        private async Task<bool> SendOrValidateMFAToken(string mfaToken, User user)
        {
            if (string.IsNullOrEmpty(mfaToken))
            {
                mfaToken = Guid.NewGuid().ToString("N")[..6].ToUpperInvariant();

                _ = _memoryCache.Set(user.Email, mfaToken, TimeSpan.FromMinutes(5));

                return false;
            }

            _ = _memoryCache.TryGetValue(user.Email, out string twoFaTokenRegistered);
            if (twoFaTokenRegistered is null)
            {
                _notification.AddForbiddenError(UserError.INVALID_CREDENTIALS);
                return false;
            }

            if (!twoFaTokenRegistered.Equals(mfaToken))
            {
                _notification.AddForbiddenError(UserError.INVALID_CREDENTIALS);
                return false;
            }

            return true;
        }

        //TODO Improve this logic
        public async Task<User> SignUp(User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task<User> Update(User user)
        {
            User userRegistered = await ValidateUserById(user.Id);
            if (user is null)
            {
                return null;
            }

            userRegistered.Name = user.Name;

            return await _userRepository.Update(userRegistered);
        }

        private async Task<User> ValidateUserById(Guid userId)
        {
            User user = await _userRepository.GetById(userId);
            if (user is null)
            {
                _notification.AddForbiddenError(UserError.USER_NOT_FOUND);
                return null;
            }

            return user;
        }

        public async Task<User> GetById(Guid userId)
        {
            User user = await ValidateUserById(userId);
            if (user is null)
            {
                return null;
            }

            return user;
        }
    }
}
