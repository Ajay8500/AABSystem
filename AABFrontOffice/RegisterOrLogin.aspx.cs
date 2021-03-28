using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AabCars.Classes;

namespace AabCars
{
    public partial class RegisterOrLogin : System.Web.UI.Page
    {
        Dictionary<object, object> param = new Dictionary<object, object>();
        public static string cs;

        
        

        protected void Page_Load(object sender, EventArgs e)
        {
             cs = ConfigurationManager.ConnectionStrings["AabCars"].ConnectionString;

            if (UserDetail.UserId != -1 && UserDetail.flag == false)
            {
                
                GetUserData();
                
            }
        }


        public void GetUserData()
        {
            try
            {
                param.Clear();
                param.Add("@UserID", UserDetail.UserId);
                DataSet ds = DAL.showDataWhere(param, cs, "SpGetUserData");

                if (ds.Tables[0].Rows.Count>0)
                {
                    _userId.Value = ds.Tables[0].Rows[0]["userid"].ToString();
                    _txtName.Value = ds.Tables[0].Rows[0]["UserName"].ToString();
                    _userContact.Value = ds.Tables[0].Rows[0]["Contact"].ToString();
                    _txtEmail.Value = ds.Tables[0].Rows[0]["Email"].ToString();
                    _txtPassword.Value = ds.Tables[0].Rows[0]["password"].ToString();
                    _address.Value = ds.Tables[0].Rows[0]["Address"].ToString();

                    UserDetail.flag = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Registeration(int id, string name,string contact, string address, string email, string password, bool istaff)
        {

            try
            {
                int userId;
                param.Clear();
                param.Add("@UserID", id);
                param.Add("@UserName", name);
                param.Add("@Contact", contact);
                param.Add("@Email", email);
                param.Add("@Address", address);
                param.Add("@Password", password);
                if (istaff)
                {

                    param.Add("@IsStaff", 1);
                }
                else
                {

                    param.Add("@IsStaff", 0);
                }

                DataSet ds = DAL.showDataWhere(param, cs, "UserRegistrationOrupdate");

                UserDetail.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["userId"]);

               

                if (ds.Tables[0].Rows.Count > 0)
                {

                    if (id == UserDetail.UserId)
                    {
                        lblMsgsuccess.Text = "Successfully Update";
                    }
                    else
                    {
                        lblMsgsuccess.Text = "Successfully Register";
                    }

                    UserDetail.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["userid"]);
                    UserDetail.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                    UserDetail.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
                    UserDetail.Contact = ds.Tables[0].Rows[0]["Email"].ToString();
                    UserDetail.Password = ds.Tables[0].Rows[0]["password"].ToString();
                    UserDetail.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    UserDetail.flag = false;

                    System.Threading.Thread.Sleep(5000);
                    Response.Redirect("Home.aspx", false);
                }
                else
                {
                    lblMsgfail.Text = "Something went wrong! Please check internet";
                }
            


            }
            catch (Exception ex)
            {

            }
        }


        public  void _btnRegister_ServerClick(object sender, EventArgs e)
        {
            
            string Name = _txtName.Value;
            string Contact = _userContact.Value;
            string Email = _txtEmail.Value;
            string Password = _txtPassword.Value;
            string address = _address.Value;

            if (Name == "" && Contact == "" && Email == "" && Password == "" && address == "")
            {
                lblMsgfail.Text = "Please Add All Fields";
            }
            else
            {

                int userId = Convert.ToInt32(_userId.Value);

                Registeration(userId, Name, Contact, address, Email, Password, false);
            }


        }
    }
}