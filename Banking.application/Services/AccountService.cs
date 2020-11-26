using Banking.application.Dtos;
using Banking.application.Interfaces;
using Banking.Domain.Commands;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using Domain.Core.Bus;
using System;
using System.Collections.Generic;

namespace Banking.application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository,IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

       
        public  IEnumerable<Account> GetAccounts()
        {
           return  _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.AcountFrom,
                accountTransfer.AccountTo,
                accountTransfer.AmountTransfer
                );

            _bus.SendCommand(createTransferCommand);
        }
    }
}
