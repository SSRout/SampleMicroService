using Banking.application.Interfaces;
using Banking.application.Services;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.Interfaces;
using Domain.Core.Bus;
using InfraBus;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InfraIoc
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            //Domian Bus
            services.AddTransient<IEventBus, RabbitMqBus>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Data Layer
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}
