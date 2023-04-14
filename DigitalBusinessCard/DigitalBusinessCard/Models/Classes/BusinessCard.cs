using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DigitalBusinessCard.Models.Classes
{
    public class BusinessCard
    {

        [Key]
        public int CardID { get; set; }

        public int UserID { get; set; }
        public virtual Users User { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Surname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Title { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Company { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string ProfilePhoto { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string PhoneNumber { get; set; }
        public bool ShowPhoneNumbere { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Email { get; set; }
        public bool ShowEmail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Link { get; set; }
        public bool ShowLink { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Adress { get; set; }
        public bool ShowAdress { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CompanyWebsite { get; set; }
        public bool ShowCompanyWebsite { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string LinkedIn { get; set; }
        public bool ShowLinkedIn { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Instagram { get; set; }
        public bool ShowInstagram { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Calendly { get; set; }
        public bool ShowCalendly { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Twitter { get; set; }
        public bool ShowTwitter { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Facebook { get; set; }
        public bool ShowFacebook { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Snapchat { get; set; }
        public bool ShowSnapchat { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Tiktok { get; set; }
        public bool ShowTiktok { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Youtube { get; set; }
        public bool ShowYoutube { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Github { get; set; }
        public bool ShowGithub { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Yelp { get; set; }
        public bool ShowYelp { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Venmo { get; set; }
        public bool ShowVenmo { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Paypal { get; set; }
        public bool ShowPaypal { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string CashApp { get; set; }
        public bool ShowCashApp { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Discord { get; set; }
        public bool ShowDiscord { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Signal { get; set; }
        public bool ShowSignal { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Skype { get; set; }
        public bool ShowSkype { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Telegram { get; set; }
        public bool ShowTelegram { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Twitch { get; set; }
        public bool ShowTwitch { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Whatsapp { get; set; }
        public bool ShowWhatsapp { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Viber { get; set; }
        public bool ShowViber { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Wechat { get; set; }
        public bool ShowWechat { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Bitcoin { get; set; }
        public bool ShowBitcoin { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Ethereum { get; set; }
        public bool ShowEthereum { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Crypto { get; set; }
        public bool ShowCrypto { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string IBAN { get; set; }
        public bool ShowIBAN { get; set; }
    }
}