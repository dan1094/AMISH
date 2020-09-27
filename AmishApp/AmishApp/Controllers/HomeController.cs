using AmishApp.Models;
using AmishApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AmishApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        private string UrlApiAmish = "";
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            this.LeerRutaApi();
        }

        public string LeerRutaApi()
        {
            UrlApiAmish = _configuration.GetValue<string>("AmishAPI");
            return "";
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult BuscarGuia()
        {
            return View("BuscarGuia", null);
        }

        [HttpGet]
        public IActionResult FacturasSinGuia()
        {
            return View("FacturasSinGuia", null);
        }

        [HttpPost]
        public IActionResult BuscarGuia(WayBillModel wayBillModel)
        {
            WayBillModel wayBillModelResponse = new OrdenesService().GetOrder(UrlApiAmish, Convert.ToInt32(wayBillModel.WayBillId));

            return View(wayBillModelResponse);
        }

        [HttpPost]
        public IActionResult FacturasSinGuia(string idBill)
        {
            List<BillModel> listBill = new List<BillModel>()
            {
                new BillModel()
                {
                    BuyDate = DateTime.Now,
                    IdBill = "789456"
                },
                new BillModel()
                {
                    BuyDate = DateTime.Now,
                    IdBill = "654321"
                },
                new BillModel()
                {
                    BuyDate = DateTime.Now,
                    IdBill = "369852"
                },
                new BillModel()
                {
                    BuyDate = DateTime.Now,
                    IdBill = "852741"
                },
                new BillModel()
                {
                    BuyDate = DateTime.Now,
                    IdBill = "456123"
                },
                new BillModel()
                {
                    BuyDate = DateTime.Now,
                    IdBill = "752174"
                },
                new BillModel()
                {
                    BuyDate = DateTime.Now,
                    IdBill = "444444"
                },
                new BillModel()
                {
                    BuyDate = DateTime.Now,
                    IdBill = "784512"
                },
                new BillModel()
                {
                    BuyDate = DateTime.Now,
                    IdBill = "326598"
                }
            };

            return View(listBill);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
