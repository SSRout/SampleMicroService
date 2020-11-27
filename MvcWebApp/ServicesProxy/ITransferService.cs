using MvcWebApp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebApp.ServicesProxy
{
    public interface ITransferService
    {
        Task Transfer(TransferDto transferDto);
    }
}
