using ASP.NET_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item() { Id = 1, Name = "Item 1" };
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            return Content(id.ToString());
        }
    }
}
