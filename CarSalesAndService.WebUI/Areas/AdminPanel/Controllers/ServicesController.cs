using CarSalesAndService.Entities;
using CarSalesAndService.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesAndService.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Policy = "AdminPolicy")]
    public class ServicesController : Controller
    {
        private readonly IService<Servis> _service;
        //Dependency Injection
        public ServicesController(IService<Servis> service)
        {
            _service = service;
        }

        // GET: ServicesController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: ServicesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Servis servis)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(servis);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu !");
                }
            }
            return View(servis);
        }

        // GET: ServicesController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Servis servis)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(servis);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu !");
                }
            }
            return View(servis);
        }

        // GET: ServicesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Servis servis)
        {
            try
            {
                _service.Delete(servis);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
