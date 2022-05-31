using Application.Common.Behaviours;
using Application.Common.Models;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped<IBookingService, BookingServiceImp>();
            services.AddScoped<IApiConsume,ApiConsumeImp>();
            services.AddSingleton(new RetryPolicy());
            services.AddHttpClient("PolicyCircuitBreaker")
                .AddPolicyHandler(request => new RetryPolicy().CircuitBreaker);
            
            return services;
        }
    }
}