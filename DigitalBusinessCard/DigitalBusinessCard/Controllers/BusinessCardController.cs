using DigitalBusinessCard.Models.Classes;
using Newtonsoft.Json.Serialization;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VCard.Helpers;
using VCard.Models;
using static System.Net.WebRequestMethods;

namespace DigitalBusinessCard.Controllers
{

    public class BusinessCardController : Controller
    {
     
        Context c = new Context();
        // GET: BusinessCard
        public ActionResult CardProfile(int id)
        {
            var carddeger = c.BusinessCards.Where(x => x.UserID == id).ToList();
            var deger = c.Userss.Find(id);
            ViewBag.urn = Current.Cname;
            ViewBag.cid = Current.Cid;
            ViewBag.qrcard = 
            ViewBag.nagme = deger.UserName;
            if (carddeger.Count == 0)
            {
               return RedirectToAction("AddCard",new { id = id });
            }
            else
            {
                return View(carddeger);

            }

        }
      
        public ActionResult VCF(int id)
        {
            const string text_x_vcard = "text/x-vcard";

            var carddeger = c.BusinessCards.Where(x => x.UserID == id).FirstOrDefault();
            Contact contact = new Contact
            {
                FormattedName = carddeger.Name+carddeger.Surname,
                FirstName = carddeger.Name,
                LastName = carddeger.Surname,
                Email = new System.Collections.Generic.List<Email>()
    {
        { new Email(){ Mail= carddeger.Email, Type="Other"} },
    },

                Phones = new System.Collections.Generic.List<Phone>()
    {
        { new Phone(){ Number=carddeger.PhoneNumber, Type="Other"} },
    },
        
                Organization = carddeger.Company,
                Title = carddeger.Title
            };
               string vcardcontents = CardYard.CreateVCard(contact);
            
            return Content(vcardcontents, text_x_vcard, Encoding.UTF8);
        }
        public ActionResult QRCreate(string kod)
        {
            string url = HttpContext.Request.Url.AbsoluteUri;

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrcoder = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrcode = qrcoder.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using ( Bitmap resim=qrcode.GetGraphic(10 ))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.qrcodeimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return PartialView();
        }

        [Authorize(Roles = "SuperAdmin,Admin,Customer")]

        public ActionResult CardEdit(int id)
        {
            var deger = c.BusinessCards.Find(id);
            ViewBag.urn = Current.Cname;
            ViewBag.photo = deger.ProfilePhoto;
            ViewBag.nagme = deger.User.UserName;
            return View("CardEdit", deger);
            
        }
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]

        public ActionResult CardUpdate(BusinessCard card)
        {
            bool updatePhoto = false;
            string pp="";
            if (Request.Files.Count > 0)
            {   
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                if (dosyaadi!="")
                {
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Images/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    pp = "/Images/" + dosyaadi + uzanti;
                    updatePhoto = true;
                }
   
            }
            var ktgr = c.BusinessCards.Find(card.CardID);
          
            if (updatePhoto==true)
            {
                ktgr.ProfilePhoto = pp;
            }
            ktgr.Name = card.Name;
            ktgr.Surname = card.Surname;
            ktgr.Title = card.Title;
            ktgr.Company = card.Company;
            ktgr.Name = card.Name;
            ktgr.PhoneNumber = card.PhoneNumber;
            ktgr.ShowPhoneNumbere = card.ShowPhoneNumbere;
            ktgr.Adress = card.Adress;
            ktgr.ShowAdress = card.ShowAdress;
            ktgr.Paypal = card.Paypal;
            ktgr.ShowPaypal = card.ShowPaypal;
            ktgr.Instagram = card.Instagram;
            ktgr.ShowInstagram = card.ShowInstagram;
            ktgr.Email = card.Email;
            ktgr.ShowEmail = card.ShowEmail;
            ktgr.LinkedIn = card.LinkedIn;
            ktgr.ShowLinkedIn = card.ShowLinkedIn;
            ktgr.Twitch = card.Twitch;
            ktgr.ShowTwitch = card.ShowTwitch;
            ktgr.Whatsapp = card.Whatsapp;
            ktgr.ShowWhatsapp = card.ShowWhatsapp;
            ktgr.Telegram = card.Telegram;
            ktgr.ShowTelegram = card.ShowTelegram;
            ktgr.Skype = card.Skype;
            ktgr.Facebook = card.Facebook;
            ktgr.Github = card.Github;
            ktgr.ShowGithub = card.ShowGithub;
            ktgr.ShowFacebook = card.ShowFacebook;
            ktgr.Tiktok = card.Tiktok;
            ktgr.ShowTiktok = card.ShowTiktok;
            ktgr.ShowSkype = card.ShowSkype;
            ktgr.Signal = card.Signal;
            ktgr.ShowSignal = card.ShowSignal;
            ktgr.Discord = card.Discord;
            ktgr.ShowDiscord = card.ShowDiscord;
            ktgr.CashApp = card.CashApp;
            ktgr.ShowCashApp = card.ShowCashApp;
            ktgr.Venmo = card.Venmo;
            ktgr.ShowVenmo = card.ShowVenmo;
            ktgr.Yelp = card.Yelp;
            ktgr.Snapchat = card.Snapchat;
            ktgr.ShowSnapchat = card.ShowSnapchat;
            ktgr.ShowYelp = card.ShowYelp;
            ktgr.Email = card.Email;
            ktgr.ShowEmail = card.ShowEmail;
            ktgr.Youtube = card.Youtube;
            ktgr.ShowYoutube = card.ShowYoutube;
            ktgr.ShowTwitter = card.ShowTwitter;
            ktgr.Twitter = card.Twitter;
            ktgr.Calendly = card.Calendly;
            ktgr.ShowCalendly = card.ShowCalendly;
            ktgr.ShowEmail = card.ShowEmail;
            ktgr.CompanyWebsite = card.CompanyWebsite;
            ktgr.ShowCompanyWebsite = card.ShowCompanyWebsite;
            ktgr.Link = card.Link;
            ktgr.ShowLink = card.ShowLink;
            ktgr.Viber = card.Viber;
            ktgr.ShowViber = card.ShowViber;
            ktgr.Wechat = card.Wechat;
            ktgr.ShowWechat = card.ShowWechat;
            ktgr.Bitcoin = card.Bitcoin;
            ktgr.ShowBitcoin = card.ShowBitcoin;
            ktgr.Ethereum = card.Ethereum;
            ktgr.ShowEthereum = card.ShowEthereum;
            ktgr.Crypto = card.Crypto;
            ktgr.ShowCrypto = card.ShowCrypto;
            ktgr.IBAN = card.IBAN;
            ktgr.ShowIBAN = card.ShowIBAN;
            c.SaveChanges();
            return RedirectToAction("CardProfile", new { id = ktgr.UserID });
        }
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]

        [HttpGet]
        public ActionResult AddCard(int id)
        {
            var deger = c.Userss.Find(id);
            ViewBag.urn = Current.Cname;
            ViewBag.nagme = deger.UserName;
            ViewBag.userid = id;
            return View();
        }
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]

        [HttpPost]
        public ActionResult AddCard(BusinessCard card)
        {
            c.BusinessCards.Add(card);
            c.SaveChanges();
            return RedirectToAction("CardProfile", new {id=card.UserID});
        }
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]

        public ActionResult redirectMyCard()
        {

            return RedirectToAction("CardProfile", "BusinessCard", new { id = Current.Cid });

        }
        public ActionResult Error()
        {
            return PartialView();
        }
    }
}