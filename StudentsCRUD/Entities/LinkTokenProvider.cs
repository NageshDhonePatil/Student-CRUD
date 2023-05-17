using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.DependencyInjection;

namespace StudentsCRUD.Entities
{
    public class LinkTokenProvider<TUser> : IUserTokenProvider<TUser>, ITransientDependency
        where TUser : class
    {
        private const string TokenPurpose = "LinkAuthentication";

        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(false);
        }

        public Task<string> GenerateAsync(string purpose, UserManager<TUser> manager, TUser user)
        {
            if (purpose != TokenPurpose)
            {
                throw new NotSupportedException($"Unsupported token purpose '{purpose}'");
            }

           // var userId = manager.GetUserId(user);
            var token = Guid.NewGuid().ToString("N");

            // TODO: Store the token in a database or cache for later validation

            return Task.FromResult(token);
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser> manager, TUser user)
        {
            if (purpose != TokenPurpose)
            {
                throw new NotSupportedException($"Unsupported token purpose '{purpose}'");
            }

           // var userId = manager.GetUserId(user);

            // TODO: Retrieve the token from the database or cache and compare it with the token passed in

            return Task.FromResult(true);
        }

        public Task<string> GetUserModifierAsync(string token, UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult("");
        }

        public Task<bool> ValidateTwoFactorTokenAsync(string token, UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(false);
        }
    }
}

