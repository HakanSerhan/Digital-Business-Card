using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using VCard.Helpers;
using VCard.Models;

namespace DigitalBusinessCard.Controllers
{
    public static class CardYard
    {

       
            private const string NewLine = "\r\n";

            private const string Separator = ";";

            private const string Header = "BEGIN:VCARD\r\nVERSION:3.0";

            private const string BDAYPrefix = "BDAY;VALUE=DATE:";

            private const string Name = "N:";

            private const string FormattedName = "FN:";

            private const string OrganizationName = "ORG:";

            private const string TitlePrefix = "TITLE:";

            private const string PhotoPrefix = "PHOTO;ENCODING=BASE64;JPEG:";

            private const string PhonePrefix = "TEL;TYPE=";

            private const string PhoneSubPrefix = ",VOICE:";

            private const string AddressPrefix = "ADR;TYPE=";

            private const string AddressSubPrefix = ":;;";

            private const string EmailPrefix = "EMAIL;TYPE=";

            private const string Footer = "END:VCARD";

            public static string CreateVCard(Contact contact)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("BEGIN:VCARD\r\nVERSION:3.0");
                stringBuilder.Append("\r\n");
                if (!string.IsNullOrEmpty(contact.FirstName) || !string.IsNullOrEmpty(contact.LastName))
                {
                    stringBuilder.Append("N:");
                    stringBuilder.Append(contact.LastName);
                    stringBuilder.Append(";");
                    stringBuilder.Append(contact.FirstName);
                    stringBuilder.Append("\r\n");
                }

                if (!string.IsNullOrEmpty(contact.FormattedName))
                {
                    stringBuilder.Append("FN:");
                    stringBuilder.Append(contact.FormattedName);
                    stringBuilder.Append("\r\n");
                }

                if (!string.IsNullOrEmpty(contact.Organization))
                {
                    stringBuilder.Append("ORG:");
                    stringBuilder.Append(contact.Organization);
                    stringBuilder.Append("\r\n");
                }

                if (!string.IsNullOrEmpty(contact.Title))
                {
                    stringBuilder.Append("TITLE:");
                    stringBuilder.Append(contact.Title);
                    stringBuilder.Append("\r\n");
                }

                if (!string.IsNullOrEmpty(contact.DateOfBirth))
                {
                stringBuilder.Append("EMAIL;TYPE=");
                stringBuilder.Append(contact.DateOfBirth);
                    stringBuilder.Append("\r\n");
                }

            foreach (Email item in contact.Email)
            {
                stringBuilder.Append("EMAIL;TYPE=");
                stringBuilder.Append(item.Type);
                stringBuilder.Append(":");
                stringBuilder.Append(item.Mail);
                stringBuilder.Append("\r\n");
            }

            foreach (Phone phone in contact.Phones)
                {
                    stringBuilder.Append("TEL;TYPE=");
                    stringBuilder.Append(phone.Type);
                    stringBuilder.Append(",VOICE:");
                    stringBuilder.Append(phone.Number);
                    stringBuilder.Append("\r\n");
                }

            

         
                stringBuilder.Append("END:VCARD");
                return stringBuilder.ToString();
            }

            public static Contact ReadVCard(string contents)
            {
                StringReader stringReader = new StringReader(contents);
                Contact contact = new Contact();
                for (string text = stringReader.ReadLine(); text != null; text = stringReader.ReadLine())
                {
                    if (!text.ToUpper().Equals("BEGIN:VCARD") || !text.ToUpper().Equals("BEGIN:VCARD"))
                    {
                        if (text.ToUpper().Contains("BDAY;VALUE="))
                        {
                            string text3 = (contact.DateOfBirth = text.ToUpper().Replace("BDAY;VALUE=DATE:", ""));
                        }
                        else if (text.ToUpper().Substring(0, 2).Contains("N:"))
                        {
                            text = text.Replace("N:", "");
                            text = text.Replace("n:", "");
                            string[] array = Split(';', text);
                            contact.FirstName = array[1];
                            contact.LastName = array[0];
                        }
                        else if (text.ToUpper().Substring(0, 3).Contains("FN:"))
                        {
                            text = text.Replace("FN:", "");
                            text = (contact.FormattedName = text.Replace("fn:", ""));
                        }
                        else if (text.ToUpper().Substring(0, 4).Contains("ORG:"))
                        {
                            text = text.Replace("ORG:", "");
                            text = (contact.Organization = text.Replace("org:", ""));
                        }
                        else if (text.ToUpper().Substring(0, 4).Contains("ADR;"))
                        {
                            text = text.Replace("ADR;", "");
                            text = text.Replace("adr;", "");
                            string[] array2 = Split(';', text);
                            string type = array2[0].Replace(":", "").Replace(";", "").Replace("TYPE=", "");
                            string description = array2[1].Replace(";", "\n");
                            if (contact.Addresses == null)
                            {
                                contact.Addresses = new List<Address>();
                            }

                            contact.Addresses.Add(new Address
                            {
                                Type = type,
                                Description = description
                            });
                        }
                        else if (text.ToUpper().Substring(0, 4).Contains("TEL;"))
                        {
                            text = text.Replace("TEL;", "");
                            text = text.Replace("tel;", "");
                            string[] array3 = Split(':', text);
                            string type2 = array3[0].Replace(":", "").Replace("TYPE=", "");
                            string number = array3[1];
                            if (contact.Phones == null)
                            {
                                contact.Phones = new List<Phone>();
                            }

                            contact.Phones.Add(new Phone
                            {
                                Type = type2,
                                Number = number
                            });
                        }
                        else if (text.ToUpper().Substring(0, 6).Contains("EMAIL;"))
                        {
                            text = text.Replace("EMAIL;", "");
                            text = text.Replace("email;", "");
                            string[] array4 = Split(':', text);
                            string type3 = array4[0].Replace("TYPE=", "").Replace(":", "");
                            string mail = array4[1];
                            if (contact.Email == null)
                            {
                                contact.Email = new List<Email>();
                            }

                            contact.Email.Add(new Email
                            {
                                Type = type3,
                                Mail = mail
                            });
                        }
                    }
                }

                return contact;
            }

            private static string[] Split(char key, string param)
            {
                char[] separator = new char[2] { key, ' ' };
                int count = 2;
                return param.Split(separator, count, StringSplitOptions.None);
            }
        
    }
}