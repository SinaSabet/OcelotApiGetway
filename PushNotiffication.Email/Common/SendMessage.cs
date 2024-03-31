﻿using PushNotiffication.Email.Dtos;

namespace PushNotiffication.Email.Common
{
    public class SendMessage
    {
        public NotifficationResult Send(string Email)
        {
            Console.WriteLine($"Message send from service Email to {Email}");
            return new NotifficationResult()
            {
                Code=200,
                IsSuccess=true,
                Message="Message send !"
            };
        }
    }
}
