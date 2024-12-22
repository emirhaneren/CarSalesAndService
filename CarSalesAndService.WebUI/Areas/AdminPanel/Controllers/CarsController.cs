using CarSalesAndService.Entities;
using CarSalesAndService.Service.Abstract;
using CarSalesAndService.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarSalesAndService.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class CarsController : Controller
    {
        private readonly IService<Arac> _service;
        private readonly IService<Marka> _serviceMarka;
        //Dependency Injection
        public CarsController(IService<Arac> service, IService<Marka> serviceMarka)
        {
            this._service = service;
            this._serviceMarka = serviceMarka;
        }

        // GET: CarsController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(model);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Arac arac, IFormFile? Foto1, IFormFile? Foto2, IFormFile? Foto3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    arac.Foto1 = await FileHelper.FileLoaderAsync(Foto1, "/Img/Cars/");
                    arac.Foto2 = await FileHelper.FileLoaderAsync(Foto2, "/Img/Cars/");
                    arac.Foto3 = await FileHelper.FileLoaderAsync(Foto3, "/Img/Cars/");

                    await _service.AddAsync(arac);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu !");
                }
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(arac);
        }

        // GET: CarsController/Edit/5
        public async Task<IActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(model);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Arac arac, IFormFile? Foto1, IFormFile? Foto2, IFormFile? Foto3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Foto1 != null)
                        arac.Foto1 = await FileHelper.FileLoaderAsync(Foto1, "/Img/Cars/");
                    if (Foto2 != null)
                        arac.Foto2 = await FileHelper.FileLoaderAsync(Foto2, "/Img/Cars/");
                    if (Foto3 != null)
                        arac.Foto3 = await FileHelper.FileLoaderAsync(Foto3, "/Img/Cars/");

                    _service.Update(arac);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir hata oluştu !");
                }
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(arac);
        }

        // GET: CarsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(model);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id, Arac arac)
        {
            try
            {
                _service.Delete(arac);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
