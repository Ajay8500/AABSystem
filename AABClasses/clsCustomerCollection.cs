using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AABClasses
{
    public class clsCustomerCollection
    {
        List<clsCustomer> mCustomerList = new List<clsCustomer>();
        //private the data member thiscustomer
        clsCustomer mThisCustomer = new clsCustomer();

        //public property for the address list
        public List<clsCustomer> CustomerList
        {
            get
            {
                //return the private data
                return mCustomerList;
            }
            set
            {
                //set the private data
                mCustomerList = value;
            }
        }

        //public property for count
        public int Count
        {
            get
            {
                //return the private data
                return mCustomerList.Count;
            }
            set
            {

            }
        }

        public clsCustomer ThisCustomer
        {
            get
            {
                //return the private data
                return mThisCustomer;
            }
            set
            {
                //set theprivate data
                mThisCustomer = value;
            }
        }

        public clsCustomerCollection()
        {

            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("sproc_tblCustomer_SelectAll");
            //popilate the array list with data table 
            PopulateArray(DB);

        }

        public int Add()
        {
            //add a new record to the database based on the values on mThisCustomer
            //connect to the datbase 
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CustomerFirstName", mThisCustomer.CustomerFirstName);
            DB.AddParameter("@CustomerLastName", mThisCustomer.CustomerLastName);
            DB.AddParameter("@CustomerEmail", mThisCustomer.CustomerEmail);
            DB.AddParameter("@CustomerTeleNo", mThisCustomer.CustomerTeleNo);
            DB.AddParameter("@Active", mThisCustomer.Active);
            //execute the stored procedure returning the primary key val of hte new record 
            return DB.Execute("sproc_tblCustomer_Insert");
        }

        public void Delete()
        {
            //deletes the record pointed to by thisCustomer
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CustomerID", mThisCustomer.CustomerID);
            //execute the stored procedure
            DB.Execute("sproc_tblCustomer_Delete");
        }

        public void Update()
        {
            //create a connection to the database
            clsDataConnection DB = new clsDataConnection();
            //add the address no parameter
            DB.AddParameter("@CustomerID", mThisCustomer.CustomerID);
            //add the CustomerFirstName  parameter
            DB.AddParameter("@CustomerFirstName", mThisCustomer.CustomerFirstName);
            //add the street parameter
            DB.AddParameter("@CustomerLastName", mThisCustomer.CustomerLastName);
            //add the town parameter
            DB.AddParameter("@CustomerEmail", mThisCustomer.CustomerEmail);
            //add the post code parameter
            DB.AddParameter("@CustomerTeleNo", mThisCustomer.CustomerTeleNo);
            //add the active parameter
            DB.AddParameter("@Active", mThisCustomer.Active);
            //execute the query
            DB.Execute("sproc_tblCustomer_Update");
        }

        public void ReportByEmail(string CustomerEmail)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CustomerEmail", CustomerEmail);
            //execute stored procedure
            DB.Execute("sproc_tblCustomer_FilterByEmail");
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            //var for the index
            Int32 Index = 0;
            //car to store the record count
            Int32 RecordCount;
            //object fro data connection
            RecordCount = DB.Count;
            //clear the pricate arraylist 
            mCustomerList = new List<clsCustomer>();
            //while threre are records to process
            while (Index < RecordCount)
            {
                //create a vlank customer
                clsCustomer ACustomer = new clsCustomer();
                //read the fields form the current record
                ACustomer.Active = Convert.ToBoolean(DB.DataTable.Rows[Index]["Active"]);
                ACustomer.CustomerID = Convert.ToInt32(DB.DataTable.Rows[Index]["CustomerID"]);
                ACustomer.CustomerFirstName = Convert.ToString(DB.DataTable.Rows[Index]["CustomerFirstName"]);
                ACustomer.CustomerLastName = Convert.ToString(DB.DataTable.Rows[Index]["CustomerLastName"]);
                ACustomer.CustomerEmail = Convert.ToString(DB.DataTable.Rows[Index]["CustomerEmail"]);
                ACustomer.CustomerTeleNo = Convert.ToString(DB.DataTable.Rows[Index]["CustomerTeleNo"]);
                //add the record to the private data member
                mCustomerList.Add(ACustomer);
                //point at hte nexxt record
                Index++;
            }
        }
    }
}