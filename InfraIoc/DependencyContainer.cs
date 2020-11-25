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
        }
    }
}
