using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTsskAboutClientServices_TraineeMaUi_.Models;

namespace TestTsskAboutClientServices_TraineeMaUi_.Controllers
{
    public class ClientOperationController : Controller
    {
        private readonly ILogger<ClientOperationController> _logger;
        ClientControlServiceContext db;

        public ClientOperationController(ILogger<ClientOperationController> logger, ClientControlServiceContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(Client client)
        {
            if (db.Clients.Contains(client))
            {
                return View();
            }
            else
            { 
                db.Clients.Add(client);
                await db.SaveChangesAsync();
                return View();
            }
        }

    }
}