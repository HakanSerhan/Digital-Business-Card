using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalBusinessCard.Controllers
{
    static class Current
    {
        static int _id;

        public static int Cid
        {
            set { _id = value; }
            get { return _id; }
        }
        static string _name;

        public static string Cname
        {
            set { _name = value; }
            get { return _name; }
        }
    }

}