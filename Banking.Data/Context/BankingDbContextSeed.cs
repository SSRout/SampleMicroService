using Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Data.Context
{
    public class BankingDbContextSeed
    {
        public static async Task SeedAsync(BankingDbContext bankingDbContext,ILoggerFactory loggerFactory,int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // INFO: Run this if using a real database. Used to automaticly migrate docker image of sql server db.
                bankingDbContext.Database.Migrate();

                if (!bankingDbContext.Accounts.Any())
                {
                    bankingDbContext.Accounts.AddRange(GetPreconfiguredAccounts());
                    await bankingDbContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                if (retryForAvailability < 5)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<BankingDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(bankingDbContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Account> GetPreconfiguredAccounts()
        {
            return new List<Account>()
            {
                new Account() {  AccountType= "Saving", AccountBalance = 10000 },
                new Account() {  AccountType= "Salary", AccountBalance = 20000 },
                new Account() {  AccountType= "Current", AccountBalance = 50000 }
            };
        }
    }
}
