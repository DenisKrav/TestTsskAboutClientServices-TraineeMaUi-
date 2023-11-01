using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestTsskAboutClientServices_TraineeMaUi_.Models;
using TestTsskAboutClientServices_TraineeMaUi_.ViewModels;

namespace TestTsskAboutClientServices_TraineeMaUi_.Controllers
{
    public class ClientOperationController : Controller
    {
        static ClientViewModel clientViewModel = new ClientViewModel();

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
                ViewData["Success"] = null;
                return View();
            }
            else if (db.Clients.Any(c => c.Phone == client.Phone && c.Surname == client.Surname && c.Name == client.Name))
            {
                ViewData["Error"] = "Клієнт вже існує.";
                ViewData["Success"] = null;
                return View();
            }
            else
            {
                ViewData["Error"] = null;
                ViewData["Success"] = "Користувача додано";
                db.Clients.Add(client);
                await db.SaveChangesAsync();

                return View();
            }           
        }

        [HttpGet]
        public async Task<IActionResult> EditClientInf(int? id)
        {
            
            clientViewModel.ClientsId = db.Clients.Select(c => new ClientIdModel { Id = c.Id }).ToList();

            if (id == null)
            {
                clientViewModel.SelectedClient = await db.Clients.FirstOrDefaultAsync();

                return View(clientViewModel);
            }
            else
            {
                clientViewModel.SelectedClient = await db.Clients.FirstOrDefaultAsync(c => c.Id == id);

                if (clientViewModel.SelectedClient != null)
                {
                    //return View(clientViewModel);
                    return PartialView("PartialdEditView", clientViewModel);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditClientInf(Client? client)
        {
            if (client == null)
            {
                ViewData["Error"] = "Користувача не вибрано.";
                return View();
            }
            else
            {
                // Повідомлення про відпрацювання не спрацьовую, бо у джава скрипт замінюється лише частина верстки
                // треба додумати логіку.
                //ViewData["Success"] = "Дані користувача оновлені";

                db.Clients.Update(client);
                await db.SaveChangesAsync();
                return RedirectToAction("EditClientInf", new { id = (string?)null });
            }
        }

    }
}