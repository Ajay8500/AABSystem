using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AABFrontOffice.Classes
{
    public class UserDetail
    {
        public static int UserId
        {
            get
            {
                var val = HttpContext.Current.Session["UserId"];
                if (val != null)
                {
                    return (int)val;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }



        public static bool flag { get; set; } = false;


        public static string UserName
        {
            get
            {
                var val = HttpContext.Current.Session["UserName"];
                if (val != null)
                {
                    return val.ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }

        public static string Password
        {
            get
            {
                var val = HttpContext.Current.Session["Password"];
                if (val != null)
                {
                    return val.ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["Password"] = value;
            }
        }



        public static string Contact
        {
            get
            {
                var val = HttpContext.Current.Session["Contact"];
                if (val != null)
                {
                    return val.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["Contact"] = value;
            }
        }

        public static string Email
        {
            get
            {
                var val = HttpContext.Current.Session["Email"];
                if (val != null)
                {
                    return val.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }


        public static string Address
        {
            get
            {
                var val = HttpContext.Current.Session["Address"];
                if (val != null)
                {
                    return val.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["Address"] = value;
            }
        }

        public static int IsStaff
        {
            get
            {
                var val = HttpContext.Current.Session["IsStaff"];
                if (val != null)
                {
                    return (int)val;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                HttpContext.Current.Session["IsStaff"] = value;
            }
        }



        public static bool isAdmin()
        {
            bool b = false;
            if (IsStaff == 1)
            {
                b = true;
            }
            return b;
        }



        public static void DestroySessions()
        {

            UserName = null;
            Password = null;
            Email = null;
            UserId = 0;
            Address = null;
            IsStaff = 0;
            Password = null;
            flag = false;
        }

    }
}