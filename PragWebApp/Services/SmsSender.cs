using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PragWebApp.Services
{
    public class SmsSender : ISmsSender
    {
        public Task<string> GetToken(string authorizationKey, string authorizationSecret)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendSms(string authorizationToken, string phoneNumber, string body)
        {
            throw new NotImplementedException();
        }
    }
}
