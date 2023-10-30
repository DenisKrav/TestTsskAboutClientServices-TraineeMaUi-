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
            if (client.Name == null || client.Surname == null || client == null)
            {
                ViewData["Error"] = "Треба заповнити усі поля.";
                return View();
            }
            else if (db.Clients.Any(c => c.Phone == client.Phone && c.Surname == client.Surname && c.Name == client.Name))
            {
                ViewData["Error"] = "Клієнт вже існує.";
                return View();
            }
            else
            {
                ViewData["Error"] = null;
                db.Clients.Add(client);
                await db.SaveChangesAsync();

                return View();
            }           
        }

        [HttpGet]
        public IActionResult EditClientInf()
        {
            return View();
        }

    }
}