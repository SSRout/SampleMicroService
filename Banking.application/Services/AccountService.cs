using Banking.application.Dtos;
using Banking.application.Interfaces;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using System;
using System.Collections.Generic;

namespace Banking.application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

       
        public  IEnumerable<Account> GetAccounts()
        {
           return  _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            throw new NotImplementedException();
        }
    }
}
