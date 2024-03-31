using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.CircuitBreaker;

namespace PushNotiffication.Email.Common
{
    public class SmsRequest
    {
        private HttpClient _httpClient;
        private CircuitBreakerPolicy _circuitBreakerPolicy;
        public SmsRequest(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _circuitBreakerPolicy = Policy.Handle<Exception>()
                .CircuitBreaker(1, TimeSpan.FromSeconds(5))
                ;
        }


        public async Task<string> Send()
        {
           
                var url = "http://localhost:5003/api/sms/sendsms";

                var response =await  _circuitBreakerPolicy.Execute(async() => await _httpClient.GetAsync(url));
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else
                    return "Error";
            
           
        }
    }
}
