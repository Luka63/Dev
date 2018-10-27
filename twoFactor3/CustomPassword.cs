using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace twoFactor3 {

    public class CustomPasswordValidator : IIdentityValidator<string> {

        public int RequiredLength { get; set; }


        //public CustomPasswordValidator(int length) {
        //    RequiredLength = length;
        //}
      
        public Task<IdentityResult> ValidateAsync(string pass) {

            const int RequiredLength = 8;
            if (String.IsNullOrEmpty(pass) || pass.Length < RequiredLength) {
                return Task.FromResult(IdentityResult.Failed(String.Format("bruh... Password should be of length {0}", RequiredLength)));
            }
            //^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*(_|[^\w])).+$
            string patternUppercase = @"[A-Z]";
            if (!Regex.IsMatch(pass, patternUppercase)) {
                return Task.FromResult(IdentityResult.Failed("bruh... At least one uppercase letter is required"));
            }
            string patternLowercase = @"[a-z]";
            if (!Regex.IsMatch(pass, patternLowercase)) {
                return Task.FromResult(IdentityResult.Failed("bruh...At least one lowercase letter is required"));
            }
            string patternDigit = @"[0-9]";
            string patternSpecial = @"[_\W]";
            if (!Regex.IsMatch(pass, patternDigit) && !Regex.IsMatch(pass, patternSpecial)) {
                return Task.FromResult(IdentityResult.Failed(" bruh... At least one number or special character is required"));
            }
            string NowhiteSpace = @"[_\s]";
            if (Regex.IsMatch(pass, NowhiteSpace)){
                return Task.FromResult(IdentityResult.Failed(" bruh... No dash"));
            }

            return Task.FromResult(IdentityResult.Success);

        }

    }
   
}