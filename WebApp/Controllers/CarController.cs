using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CarController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await Repository<Car>.GetItemsAsync();
            return View(items);
        }

        //[ActionName("Index")]
        //public async Task<ActionResult> IndexAsync(string id)
        //{
        //    var items = await Repository<Car>.GetItemsData(id);
        //    return View(items);
        //}

        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Id,Model,Year")] Car item)
        {
            if (ModelState.IsValid)
            {
                await Repository<Car>.CreateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }
    }
}