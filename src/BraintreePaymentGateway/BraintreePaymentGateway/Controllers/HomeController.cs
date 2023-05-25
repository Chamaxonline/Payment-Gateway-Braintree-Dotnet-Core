using BraintreePaymentGateway.Models;
using BraintreePaymentGateway.Services;
using BraintreePaymentGateway.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BraintreePaymentGateway.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBraintreeService _braintreeService;

        public HomeController(ILogger<HomeController> logger, IBraintreeService braintreeService)
        {
            _logger = logger;
            _braintreeService = braintreeService;
        }

        public IActionResult Index()
        {
            var gateway = _braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();  //Genarate a token
            ViewBag.ClientToken = clientToken;

            var data = new BookPurchaseVM
            {
                Id = 2,
                Description = "Hellow man",
                Author = "Me",
                Thumbnail = "This is thumbnail",
                Title = "This is title",
                Price = "230",
                Nonce = ""
            };

            return View(data);
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

        public IActionResult Create()
        {
            return View();
        }
    }
}