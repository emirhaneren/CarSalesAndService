using CarSalesAndService.Entities;
using CarSalesAndService.Service.Abstract;
using CarSalesAndService.Service.Concrete;
using CarSalesAndService.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;

namespace CarSalesAndService.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService<Kullanici> _serviceUser;
        private readonly IService<Rol> _serviceRol;

        public AccountController(IService<Kullanici> serviceUser, IService<Rol> serviceRol)
        {
            _serviceUser = serviceUser;
            _serviceRol = serviceRol;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rol = await _serviceRol.GetAsync(r => r.Adi == "Customer");
                    if(rol == null)
                    {
                        ModelState.AddModelError("", "Kayıt Başarısız !");
                        return View();
                    }
                    
                    kullanici.RolId= rol.Id;
                    kullanici.AktifMi = true;
                    await _serviceUser.AddAsync(kullanici);
                    await _serviceUser.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Lütfen girdiğiniz değerleri kontrol ediniz !");
                }
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel login)
        {
            try
            {
                var account =await _serviceUser.GetAsync(k => k.Email == login.Email && k.Sifre == login.Sifre && k.AktifMi == true);
                if (account == null)
                {
                    ModelState.AddModelError("", "Giriş Başarısız !");
                }
                else
                {
                    var rol = _serviceRol.Get(r => r.Id == account.RolId);
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,account.Adi)
                    };
                    if (rol is not null)
                    {
                        claims.Add(new Claim("Role", rol.Adi.ToString()));//Rol bazlı login
                    }
                    var userIdentitiy = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentitiy);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/Account");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Bir Hata Oluştu !");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
