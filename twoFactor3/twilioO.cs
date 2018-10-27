using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;

namespace twoFactor3 {
    public class TwilioO : IIdentityMessageService {

      
        public Task SendAsync(IdentityMessage message) {
            var Twilio = new TwilioRestClient(null,null);

            var lll = MessageResource.Create(body: "bitch", from: new Twilio.Types.PhoneNumber("123444"), to:new Twilio.Types.PhoneNumber("4444"));

            var asf = new { code = "456345", message = lll };

            return Task.FromResult(asf);
        }
    }
}