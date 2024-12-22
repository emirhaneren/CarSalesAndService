using CarSalesAndService.Entities;
using CarSalesAndService.Service.Abstract;
using CarSalesAndService.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesAndService.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Policy = "AdminPolicy")]
    public class SlidersController : Controller
    {
        private readonly IService<Slider> _service;

        public SlidersController(IService<Slider> service)
        {
            _service = service;
        }

        // GET: SlidersController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: SlidersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SlidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlidersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Slider slider, IFormFile? Foto)
        {
            try
            {
                slider.Foto= await FileHelper.FileLoaderAsync(Foto, "/Img/Slider/");
                await _service.AddAsync(slider);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SlidersController/Edit/5
        public  async Task<ActionResult> EditAsync(int id)
        {
            var model =await _service.FindAsync(id);
            return View(model);
        }

        // POST: SlidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Slider slider,IFormFile? Foto)
        {
            try
            {
                if(Foto!= null)
                    slider.Foto = await FileHelper.FileLoaderAsync(Foto, "/Img/Slider/");
                _service.Update(slider);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SlidersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: SlidersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Slider slider)
        {
            try
            {
                _service.Delete(slider);
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
