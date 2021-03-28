using AABFrontOffice.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AabCars
{
    public partial class Login : System.Web.UI.Page
    {
        Dictionary<Object, Object> parameters = null;
        string cs = ConfigurationManager.ConnectionStrings["AabCars"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void UserLogin(string email, string password)
        {

            try
            {

                parameters = new Dictionary<object, object>();
                parameters.Add("@Email", email);
                parameters.Add("@Password", password);

                DataSet ds = DAL.showDataWhere(parameters, cs, "SpLogin");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    UserDetail.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["userid"]);
                    UserDetail.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                    UserDetail.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
                    UserDetail.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    UserDetail.Password = ds.Tables[0].Rows[0]["password"].ToString();
                    UserDetail.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    UserDetail.IsStaff =Convert.ToInt32(ds.Tables[0].Rows[0]["IsStaff"]);

                    if(UserDetail.IsStaff == 0)
                    {
                        Response.Redirect("Home.aspx", false);

                    }
                    else
                    {
                        Response.Redirect("CarList.aspx", false);

                    }
                }

                // when user authenticate from AD only
                else
                {
                    ;
                    //lblMsg.Text = "Email not found or changed";
                    lblMsg.Text = "Wrong username or password";

                }
            }

            catch (Exception ex)
            {

            }

        }

        protected void _btnLogin_ServerClick(object sender, EventArgs e)
        {
            UserLogin(_txtEmail.Value, _txtPassword.Value);
        }

        protected void _btnRegister_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("RegisterOrLogin.aspx", false);
        }
    }
}