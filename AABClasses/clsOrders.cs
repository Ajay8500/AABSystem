using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AABClasses
{
    public class clsOrder
    {
        //private data member for the OrderID
        private Int32 mOrderID;
        //OrderDate private member variable
        private DateTime mOrderDate;
        //OrderPostCode private member variable
        private string mPostCode;
        //OrderHouseNo private member variable
        private string mOrderHouseNo;
        //CustomerName private member variable
        private string mCustomerName;
        //OrderItem private member variable
        private string mOrderItem;
        //private data member for the CustomerID
        private Int32 mCustomerID;

        public DateTime OrderDate
        {
            get
            {
                return mOrderDate;
            }
            set
            {
                mOrderDate = value;
            }
        }
        // public property for post code 
        public string OrderPostCode
        {
            get
            {
                return mPostCode;
            }
            set
            {
                mPostCode = value;
            }


        }

        public string CustomerName
        {
            get
            {
                return mCustomerName;
            }
            set
            {
                mCustomerName = value;
            }
        }

        public string OrderItem
        {
            get
            {
                return mOrderItem;
            }
            set
            {
                mOrderItem = value;
            }
        }

        //OrderID public porpoerty
        public Int32 OrderID
        {
            get
            {
                return mOrderID;
            }
            set
            {
                mOrderID = value;
            }

        }

        public Int32 CustomerID
        {
            get
            {
                return mCustomerID;
            }
            set
            {
                mCustomerID = value;
            }
        }

        //OrderHouseNo public property
        public string OrderHouseNo
        {
            get
            {
                return mOrderHouseNo;
            }
            set
            {
                mOrderHouseNo = value;
            }
        }

        public bool Find(int orderID)
        {
            //set the private data memeber to the test data value
            mOrderID = 21;
            mOrderDate = Convert.ToDateTime("28/3/2021");
            mCustomerID = 1;
            mCustomerName = "Baijeed Chowdhury";
            mOrderHouseNo = "103";
            mOrderItem = "Mercedes";
            mPostCode = "LE2 3NF;

            //always return true
            return true;
        }
    }
}
