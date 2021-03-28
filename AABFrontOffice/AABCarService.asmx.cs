using AABFrontOffice.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using Ubiety.Dns.Core;

namespace AABFrontOffice
{
    /// <summary>
    /// Summary description for AAB Car Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AabCarService : System.Web.Services.WebService
    {
        public static string cs = ConfigurationManager.ConnectionStrings["AabCars"].ConnectionString;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }



        [WebMethod(EnableSession = true)]
        public string AddOrUpdateEmp(
           int EmpId,
           string StaffName,
           string password,
           string ContactNumber,
           string StaffEmailAddress,
           string Address,
           string DOB
            )
        {

            string responseMsg = string.Empty;
            string statusCode = string.Empty;
            string message = string.Empty;
            try
            {
                Dictionary<object, object> param = new Dictionary<object, object>();

                param.Clear();
                param.Add("@UserID", EmpId);
                param.Add("@UserName", StaffName);
                param.Add("@Contact", ContactNumber);
                param.Add("@Email", StaffEmailAddress);
                param.Add("@Address", Address);
                param.Add("@Password", password);

                param.Add("@IsStaff", 1);

                DataSet response = DAL.showDataWhere(param, cs, "UserRegistrationOrupdate");
                if (response.Tables.Count > 0)
                {
                    statusCode = response.Tables[0].Rows[0]["userId"].ToString();
                }
                else
                {
                }


            }

            catch (Exception ex)
            {
            }

            return JsonConvert.SerializeObject(new { statusCode = statusCode, message = responseMsg, userMessage = message });

        }




        [WebMethod]
        public string GetAllStaff()
        {
            string JSONString = string.Empty;
            try
            {
                JSONString = DAL.getJSONData(cs, "SpGetStaffList");
            }

            catch (Exception ex)
            {

            }
            return JSONString;
        }

        [WebMethod]
        public bool DeleteStaff(int empid)
        {
            Dictionary<object, object> parameters = new Dictionary<object, object>();

            bool boo = false;
            try
            {
                parameters.Clear();
                parameters.Add("@UserId", empid);

                boo = DAL.updateData(parameters, "SpDeleteUser", cs);

            }
            catch (Exception ex)
            {

            }

            return boo;
        }


        [WebMethod(enableSession: true)]
        public bool DeleteAccount(int EmpId)
        {
            Dictionary<object, object> parameters = new Dictionary<object, object>();

            bool boo = false;
            try
            {
                parameters.Clear();
                parameters.Add("@UserId", UserDetail.UserId);

                boo = DAL.updateData(parameters, "SpDeleteUser", cs);
                if (boo)
                {
                    UserDetail.DestroySessions();
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                    Session.Clear();
                }
            }
            catch (Exception ex)
            {

            }

            return boo;
        }




        [WebMethod(EnableSession = true)]
        public string AddOrUpdateCar(int CarId, string Model, string Price, string Body, string Color
                                            )
        {

            string responseMsg = string.Empty;
            string statusCode = string.Empty;
            string message = string.Empty;
            try
            {
                Dictionary<object, object> param = new Dictionary<object, object>();

                param.Clear();
                param.Add("@CarId", CarId);
                param.Add("@Model", Model);
                param.Add("@Price", Price);
                param.Add("@Body", Body);
                param.Add("@Color", Color);

                DataSet response = DAL.showDataWhere(param, cs, "AddOrUpdateCar");
                if (response.Tables.Count > 0)
                {
                    statusCode = response.Tables[0].Rows[0]["statusCode"].ToString();
                }
                else
                {
                }


            }

            catch (Exception ex)
            {
            }

            return JsonConvert.SerializeObject(new { statusCode = statusCode, message = responseMsg, userMessage = message });

        }


        [WebMethod(EnableSession = true)]
        public string AddBooking(int CarId, string BookingDate)
        {

            string responseMsg = string.Empty;
            string statusCode = string.Empty;
            string message = string.Empty;
            try
            {
                Dictionary<object, object> param = new Dictionary<object, object>();

                param.Clear();
                param.Add("@CarId", CarId);
                param.Add("@UserId", UserDetail.UserId);
                param.Add("@BookingDate", BookingDate);

                DataSet response = DAL.showDataWhere(param, cs, "spBookingAppointment");
                if (response.Tables.Count > 0)
                {
                    statusCode = response.Tables[0].Rows[0]["statusCode"].ToString();
                }
                else
                {
                }


            }

            catch (Exception ex)
            {
            }

            return JsonConvert.SerializeObject(new { statusCode = statusCode, message = responseMsg, userMessage = message });

        }


        [WebMethod(EnableSession = true)]
        public string CarPurchase(int CarId, string CardNo, string Cvv)
        {

            string responseMsg = string.Empty;
            string statusCode = string.Empty;
            string message = string.Empty;
            try
            {
                Dictionary<object, object> param = new Dictionary<object, object>();

                param.Clear();
                param.Add("@CarId", CarId);
                param.Add("@UserId", UserDetail.UserId);
                param.Add("@CardNo", CardNo);
                param.Add("@Cvv", Cvv);


                DataSet response = DAL.showDataWhere(param, cs, "CarPurchase");
                if (response.Tables.Count > 0)
                {
                    statusCode = response.Tables[0].Rows[0]["statusCode"].ToString();
                }
                else
                {
                    statusCode = "01";
                }


            }

            catch (Exception ex)
            {
            }

            return JsonConvert.SerializeObject(new { statusCode = statusCode, message = responseMsg, userMessage = message });

        }

        [WebMethod(EnableSession = true)]
        public string CancelBooking(int BookingId)
        {

            string responseMsg = string.Empty;
            string statusCode = string.Empty;
            string message = string.Empty;
            try
            {
                Dictionary<object, object> param = new Dictionary<object, object>();

                param.Clear();
                param.Add("@BookingId", BookingId);

                DataSet response = DAL.showDataWhere(param, cs, "spCancelAppointment");
                if (response.Tables.Count > 0)
                {
                    statusCode = response.Tables[0].Rows[0]["statusCode"].ToString();
                }
                else
                {
                }


            }

            catch (Exception ex)
            {
            }
            return JsonConvert.SerializeObject(new { statusCode = statusCode, message = responseMsg, userMessage = message });

        }

        [WebMethod(enableSession: true)]
        public string GetOrders()
        {
            string JSONString = string.Empty;
            try
            {
                Dictionary<object, object> parameters = new Dictionary<object, object>();
                parameters.Clear();
                parameters.Add("@UserID", UserDetail.UserId);
                JSONString = DAL.getJSONDataWhere(parameters, cs, "SpGetOrder");
            }

            catch (Exception ex)
            {

            }
            return JSONString;
        }

        [WebMethod(enableSession: true)]
        public string UpdateOrder(int purchaseId, int confirm)
        {
            string responseMsg = string.Empty;
            string statusCode = string.Empty;
            string message = string.Empty;
            try
            {
                Dictionary<object, object> param = new Dictionary<object, object>();

                param.Clear();
                param.Add("@UserId", UserDetail.UserId);
                param.Add("@purchaseId", purchaseId);
                param.Add("@CancelOrConfirm", confirm);

                DataSet response = DAL.showDataWhere(param, cs, "SpUpdateOrder");
                if (response.Tables.Count > 0)
                {
                    statusCode = response.Tables[0].Rows[0]["statusCode"].ToString();
                }
                else
                {
                }
            }

            catch (Exception ex)
            {
            }
            return JsonConvert.SerializeObject(new { statusCode = statusCode, message = responseMsg, userMessage = message });


        }


        [WebMethod]
        public string GetAllCars()
        {
            string JSONString = string.Empty;
            try
            {
                JSONString = DAL.getJSONData(cs, "SpGetCarList");
            }

            catch (Exception ex)
            {

            }
            return JSONString;
        }


        //this function will get all active customer only for staff members
        [WebMethod]
        public string GetAllCustomers()
        {
            string JSONString = string.Empty;
            try
            {
                JSONString = DAL.getJSONData(cs, "SpGetCustomersList");
            }

            catch (Exception ex)
            {

            }
            return JSONString;
        }


        [WebMethod(enableSession: true)]
        public string GetAllBooking()
        {
            string JSONString = string.Empty;
            try
            {
                Dictionary<object, object> parameters = new Dictionary<object, object>();
                parameters.Clear();
                parameters.Add("@UserID", UserDetail.UserId);
                JSONString = DAL.getJSONDataWhere(parameters, cs, "SpGetBookings");

            }

            catch (Exception ex)
            {

            }
            return JSONString;
        }

        [WebMethod]
        public bool DeleteCar(int carId)
        {
            Dictionary<object, object> parameters = new Dictionary<object, object>();

            bool boo = false;
            try
            {
                parameters.Clear();
                parameters.Add("@carId", carId);

                boo = DAL.updateData(parameters, "SpDeleteCar", cs);

            }
            catch (Exception ex)
            {

            }

            return boo;
        }





        [WebMethod]
        public string GetStaffById(int EmpId)
        {
            string JSONString = string.Empty;
            try
            {
                Dictionary<object, object> parameters = new Dictionary<object, object>();
                parameters.Clear();
                parameters.Add("@UserID", EmpId);
                JSONString = DAL.getJSONDataWhere(parameters, cs, "SpGetUserData");
            }

            catch (Exception ex)
            {

            }
            return JSONString;

        }

    }
}
