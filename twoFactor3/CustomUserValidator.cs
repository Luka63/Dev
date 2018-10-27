using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace twoFactor3 {
    internal class CustomUserValidator : IIdentityValidator<string> {

        public Task<IdentityResult> ValidateAsync(string userName) {

            if (string.IsNullOrWhiteSpace(userName)) {
                return Task.FromResult(IdentityResult.Failed("bitch"));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}