using CarSalesAndService.Entities;
using CarSalesAndService.Service.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarSalesAndService.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class LoginController : Controller
    {
        private readonly IService<Kullanici> _serviceKullanici;
        private readonly IService<Rol> _serviceRol;

        public LoginController(IService<Kullanici> serviceKullanici, IService<Rol> serviceRol)
        {
            _serviceKullanici = serviceKullanici;
            _serviceRol = serviceRol;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email, string password)
        {
            try
            {
                var account = _serviceKullanici.Get(k => k.Email == email && k.Sifre == password && k.AktifMi == true);
                if (account == null)
                {
                    TempData["Mesaj"] = "Giriş bilgilerinizi kontrol ediniz.";
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
                    return Redirect("/AdminPanel");
                }
            }
            catch (Exception)
            {
                TempData["Mesaj"] = "Bir hata oluştu !";
            }
            return View();
        }
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/AdminPanel/Login");
        }
    }
}
