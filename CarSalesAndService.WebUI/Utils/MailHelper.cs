using CarSalesAndService.Entities;
using System.Net;
using System.Net.Mail;

namespace CarSalesAndService.WebUI.Utils
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Musteri musteri)
        {
            //Bilgi al sonrası admine mail gönderme TODO

            SmtpClient smtpClient = new SmtpClient("mail.siteadresi.com", 587); //Sunucu ismi, port
            smtpClient.Credentials = new NetworkCredential("emailKullanıcıAdı", "emailSifre");//KullaniciAdi,Şifre
            smtpClient.EnableSsl = true;//SSL sertifikası olan sunucu varsa true, yoksa false
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("info@siteadresi.com");
            mailMessage.To.Add("info@siteadresi.com");
            mailMessage.Subject = "Mail Konusu";
            mailMessage.Body = $"Mail Bilgileri<hr/> Ad Soyad : {musteri.Adi} {musteri.Soyadi}";//İçerik
            mailMessage.IsBodyHtml = true;
            await smtpClient.SendMailAsync(mailMessage);
            smtpClient.Dispose();
        }
    }
}
