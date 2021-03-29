using AABFrontOffice.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AabCars
{
    public partial class SiteMaster : MasterPage
    {
        Dictionary<object, object> param = new Dictionary<object, object>();
        public static string cs;
        protected void Page_Load(object sender, EventArgs e)
        {
            cs = ConfigurationManager.ConnectionStrings["AabCars"].ConnectionString;

        }

        protected void _btnLogOut_ServerClick(object sender, EventArgs e)
        {
            UserDetail.DestroySessions();
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies.

            Response.Redirect("Login.aspx");

        }

        protected void _btnEdit_ServerClick(object sender, EventArgs e)
        {
            if (UserDetail.UserId != 0)
            {
                //RegisterOrLogin r = new RegisterOrLogin();
                
                Response.Redirect("RegisterOrLogin.aspx", false);
                //r.GetUserData();
            }
            else
            Response.Redirect("Login.aspx", false);
        }



        private void GetUserData(int userId)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}