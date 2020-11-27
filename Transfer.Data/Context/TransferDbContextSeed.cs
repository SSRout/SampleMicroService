using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Domain.Models;

namespace Transfer.Data.Context
{
    public class TransferDbContextSeed
    {
        public static async Task SeedAsync(TransferDbContext transferDbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // INFO: Run this if using a real database. Used to automaticly migrate docker image of sql server db.
                transferDbContext.Database.Migrate();

                if (!transferDbContext.TransferLogs.Any())
                {
                    transferDbContext.TransferLogs.AddRange(GetPreconfiguredTransferLogs());
                    await transferDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 5)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<TransferDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(transferDbContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<TransferLog> GetPreconfiguredTransferLogs()
        {
            return new List<TransferLog>()
            {
                new TransferLog() {  FromAccount= 1, ToAccount = 2,TransferAmount=1000 }
            };
        }
    }
}
