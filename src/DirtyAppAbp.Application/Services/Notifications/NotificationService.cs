using Abp.Application.Services;
using DirtyAppAbp.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace DirtyAppAbp.Services.Notifications
{
    public class NotificationService : ApplicationService, IApplicationService
    {
        private readonly IConfiguration _configuration;
        public NotificationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async System.Threading.Tasks.Task sendNotificationAsync(Notification input)
        {
            var accountSid = _configuration.GetSection("App")["TwillioAcc"];
            var authToken = _configuration.GetSection("App")["AuthToken"];
            TwilioClient.Init(accountSid, authToken);
            var messageOptions = new CreateMessageOptions(
              new PhoneNumber(input.TextTo));
            messageOptions.From = new PhoneNumber(_configuration.GetSection("App")["TwillioCell"]);
            messageOptions.Body = input.Body;
            var message = MessageResource.Create(messageOptions);
        }
    }
}
