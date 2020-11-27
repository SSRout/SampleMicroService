using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcWebApp.Models;
using MvcWebApp.Models.Dtos;
using MvcWebApp.ServicesProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransferService _transferService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITransferService transferService,ILogger<HomeController> logger)
        {
            _transferService = transferService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel transferViewModel)
        {
            TransferDto transferDto = new TransferDto()
            {
                AcountFrom = transferViewModel.FromAccount,
                AccountTo = transferViewModel.ToAccount,
                AmountTransfer = transferViewModel.TransferAmount
            };
            await _transferService.Transfer(transferDto);

            return View("Index");
        }
    }
}
