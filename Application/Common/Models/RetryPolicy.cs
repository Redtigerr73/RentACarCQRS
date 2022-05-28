using Polly;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class RetryPolicy
    {
        public AsyncCircuitBreakerPolicy<HttpResponseMessage> CircuitBreaker { get; }
        public RetryPolicy()
        {
            CircuitBreaker = Policy
                .HandleResult<HttpResponseMessage>(output => !output.IsSuccessStatusCode)
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(20));
        }
    }
}
