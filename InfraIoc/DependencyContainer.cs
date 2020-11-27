using Banking.application.Interfaces;
using Banking.application.Services;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.CommandHandlers;
using Banking.Domain.Commands;
using Banking.Domain.Interfaces;
using Domain.Core.Bus;
using InfraBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using Transfer.Application.Interfaces;
using Transfer.Application.Services;
using Transfer.Data.Context;
using Transfer.Data.Repository;
using Transfer.Domain.EventHandlers;
using Transfer.Domain.Events;
using Transfer.Domain.Interfaces;

namespace InfraIoc
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            //Domian Bus
            services.AddSingleton<IEventBus, RabbitMqBus>(sp=> {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return  new RabbitMqBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscription
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Domain Baniking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand,bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Data Layer
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();         
            services.AddTransient<TransferDbContext>();
        }
    }
}
