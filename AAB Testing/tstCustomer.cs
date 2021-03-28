using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AAB_Testing
{
    [TestClass]
    public class tstCustomer
    {
        //good test data
        //create some test data to pass the method
        string CustomerFirstName = "John";
        string CustomerLastName = "Joe";
        string CustomerEmail = "John@gmail.com";
        string CustomerTeleNo = "XXXXXXXXXX";

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //test to see that it exists
            Assert.IsNotNull(ACustomer);
        }

        [TestMethod]
        public void ActivePropertyOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //create some test data to assign to the property
            Boolean TestData = true;
            //assign the data to the property
            ACustomer.Active = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(ACustomer.Active, TestData);
        }

        [TestMethod]
        public void CustomerIDPropertyOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            ACustomer.CustomerID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(ACustomer.CustomerID, TestData);
        }

        [TestMethod]
        public void CustomerFirstNamePropertyOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //create some test data to assign to the property
            string TestData = "First Name";
            //assign the data to the property
            ACustomer.CustomerFirstName = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(ACustomer.CustomerFirstName, TestData);
        }

        [TestMethod]
        public void CustomerLastNamePropertyOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //create some test data to assign to the property
            string TestData = "Last Name";
            //assign the data to the property
            ACustomer.CustomerLastName = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(ACustomer.CustomerLastName, TestData);
        }
        [TestMethod]

        public void CustomerEmailPropertyOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //create some test data to assign to the property
            string TestData = "Some Email";
            //assign the data to the property
            ACustomer.CustomerEmail = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(ACustomer.CustomerEmail, TestData);
        }

        [TestMethod]
        public void CustomerTeleNoPropertyOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //create some test data to assign to the property
            string TestData = "First Name";
            //assign the data to the property
            ACustomer.CustomerTeleNo = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(ACustomer.CustomerTeleNo, TestData);
        }
        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //boolean variable to store the reslt ofg the validation
            Boolean Found = false;
            //create sometest data to use wiht the method
            Int32 CustomerID = 1;
            Found = ACustomer.Find(CustomerID);
            //test to see if the relst is true
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestCustomerIDFound()
        {
            //create an instance of the calss we want to create 
            clsCustomer ACustomer = new clsCustomer();
            //booealn variable to streot he reiult of the search 
            Boolean Found = true;
            //boolean variabnle to record if data is ok 
            Boolean OK = true;
            //create some test data to use with the method
            Int32 CustomerID = 1;
            //invke teh method
            Found = ACustomer.Find(CustomerID);
            //chech the customer id
            if (ACustomer.CustomerID != 1)
            {
                OK = false;
            }
            //test ito see that the result is correct
            Assert.IsTrue(OK);

        }

        [TestMethod]
        public void TestActiveFound()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 CustomerID = 1;
            //invoke the method
            Found = ACustomer.Find(CustomerID);
            //check the property
            if (ACustomer.Active != true)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestCustomerFirstNameFound()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 CustomerID = 1;
            //invoke the method
            Found = ACustomer.Find(CustomerID);
            //chech the customer id
            if (ACustomer.CustomerFirstName != "Ajay")
            {
                OK = false;
            }
            //test ito see that the result is correct
            Assert.IsTrue(OK);

        }

        [TestMethod]
        public void TestCustomerLastNameFound()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 CustomerID = 1;
            //invoke the method
            Found = ACustomer.Find(CustomerID);
            //chech the customer id
            if (ACustomer.CustomerLastName != "Solanki")
            {
                OK = false;
            }
            //test ito see that the result is correct
            Assert.IsTrue(OK);

        }

        [TestMethod]
        public void TestCustomerEmailFound()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 CustomerID = 1;
            //invoke the method
            Found = ACustomer.Find(CustomerID);
            //chech the customer id
            if (ACustomer.CustomerEmail != "AjaySolanki@gmail.com")
            {
                OK = false;
            }
            //test ito see that the result is correct
            Assert.IsTrue(OK);

        }

        [TestMethod]
        public void TestCustomerTeleNoFound()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 CustomerID = 1;
            //invoke the method
            Found = ACustomer.Find(CustomerID);
            //chech the customer id
            if (ACustomer.CustomerTeleNo != "07448253666")
            {
                OK = false;
            }
            //test ito see that the result is correct
            Assert.IsTrue(OK);

        }

        [TestMethod]
        public void ValidMethodOK()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string cariable to store any erroe message
            String Error = "";
            //invoke the method 
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //tet to see that reulst is correct 
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerFirstNameMin()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerFirstName = "a"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerFirstNameMinLessOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //this should fail
            string CustomerFirstName = "";
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }


        [TestMethod]
        public void CustomerFirstNameMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerFirstName = "aa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerFirstNameMaxLessOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerFirstName = "aaaaaaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerFirstNameMax()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerFirstName = "aaaaaaaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerFirstNameMid()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerFirstName = "aaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerFirstNameMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerFirstName = "aaaaaaaaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void CustomerFirstNameExtremeMax()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerFirstName = "";
            CustomerFirstName = CustomerFirstName.PadRight(500, 'a'); //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void CustomerLastNameMin()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerLastName = "a"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerLastNameMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerLastName = "aa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerLastNameMinLessOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //this should fail
            string CustomerLastName = "";
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerLastNameMaxLessOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerLastName = "aaaaaaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerLastNameMax()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerLastName = "aaaaaaaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerLastNameMid()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerLastName = "aaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerLastNameMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerLastName = "aaaaaaaaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void CustomerLastNameExtremeMax()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerLastName = "";
            CustomerLastName = CustomerLastName.PadRight(500, 'a'); //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void CustomerEmailMin()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerEmail = "a"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerEmail = "aa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void CustomerEmailMinLessOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //this should fail
            string CustomerEmail = "";
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerEmailMaxLessOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerEmail = "";
            CustomerEmail = CustomerEmail.PadRight(34, 'a'); //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void CustomerEmailMid()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerEmail = "";
            CustomerEmail = CustomerEmail.PadRight(25, 'a'); //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void CustomerEmailMax()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerEmail = "";
            CustomerEmail = CustomerEmail.PadRight(50, 'a'); //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void CustomerEmailMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerEmail = "";
            CustomerEmail = CustomerEmail.PadRight(51, 'a'); //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void CustomerEmailExtremeMax()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerEmail = "";
            CustomerEmail = CustomerEmail.PadRight(500, 'a'); //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void CustomerTeleNoMin()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerTeleNo = "a"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerTeleNoMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerTeleNo = "aa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void CustomerTeleNoMinLessOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //this should fail
            string CustomerTeleNo = "";
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CustomerTeleNoMaxLessOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerTeleNo = "aaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void CustomerTeleNoMid()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerTeleNo = "aaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void CustomerTeleNoMax()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerTeleNo = "aaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CustomerTeleNoMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerTeleNo = "aaaaaaaaaaaaaaaa"; //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }

        [TestMethod]
        public void CustomerTeleNoExtremeMax()
        {
            //create an instance of the class we want to create
            clsCustomer ACustomer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            string CustomerTeleNo = "";
            CustomerTeleNo = CustomerTeleNo.PadRight(500, 'a'); //this should be ok
            //invoke the method
            Error = ACustomer.Valid(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerTeleNo);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }


        [TestMethod]
        public void AddMethodOK()
        {
            //create an instanceof the clas we watn to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create the item of test data
            clsCustomer TestItem = new clsCustomer();
            //var to streo the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.Active = true;
            TestItem.CustomerID = 1;
            TestItem.CustomerFirstName = "First";
            TestItem.CustomerLastName = "Last";
            TestItem.CustomerEmail = "Admin@gmail.com";
            TestItem.CustomerTeleNo = "XXXXXXXXXX";
            //set thiscustomer to thetest data
            AllCustomers.ThisCustomer = TestItem;
            //add the record
            PrimaryKey = AllCustomers.Add();
            //find the record
            TestItem.CustomerID = PrimaryKey;
            //find the record
            AllCustomers.ThisCustomer.Find(PrimaryKey);
            //test to see that the teo valies are the same
            Assert.AreEqual(AllCustomers.ThisCustomer, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //create an instanceof the clas we watn to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create the item of test data
            clsCustomer TestItem = new clsCustomer();
            //var to streo the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.Active = true;
            TestItem.CustomerID = 1;
            TestItem.CustomerFirstName = "First";
            TestItem.CustomerLastName = "Last";
            TestItem.CustomerEmail = "Admin@gmail.com";
            TestItem.CustomerTeleNo = "XXXXXXXXXX";
            //set thiscustomer to thetest data
            AllCustomers.ThisCustomer = TestItem;
            //add the record
            PrimaryKey = AllCustomers.Add();
            //find the record
            TestItem.CustomerID = PrimaryKey;
            AllCustomers.ThisCustomer.Find(PrimaryKey);
            //delete the record
            AllCustomers.Delete();
            //now find the record
            Boolean Found = AllCustomers.ThisCustomer.Find(PrimaryKey);
            //test to see that the record was not found
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            //create an instanceof the clas we watn to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create the item of test data
            clsCustomer TestItem = new clsCustomer();
            //var to streo the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.Active = true;
            TestItem.CustomerID = 1;
            TestItem.CustomerFirstName = "First";
            TestItem.CustomerLastName = "Last";
            TestItem.CustomerEmail = "Admin@gmail.com";
            TestItem.CustomerTeleNo = "XXXXXXXXXX";
            //set thiscustomer to thetest data
            AllCustomers.ThisCustomer = TestItem;
            //add the record
            PrimaryKey = AllCustomers.Add();
            //find the record
            TestItem.CustomerID = PrimaryKey;
            //modify teh test data
            TestItem.Active = false;
            TestItem.CustomerID = 2;
            TestItem.CustomerFirstName = "First2";
            TestItem.CustomerLastName = "Last2";
            TestItem.CustomerEmail = "Admin2@gmail.com";
            TestItem.CustomerTeleNo = "XXXXXXXXX2";
            //set the record basedon the new test data
            AllCustomers.ThisCustomer = TestItem;
            //update the record
            AllCustomers.Update();
            //findt the record
            AllCustomers.ThisCustomer.Find(PrimaryKey);
            //test to see that the teo valies are the same
            Assert.AreEqual(AllCustomers.ThisCustomer, TestItem);

        }

        [TestMethod]
        public void ReportByEmailMethodOK()
        {
            //createa an instance of the calss contaion unfiltered results
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create an instance of the fultered data
            clsCustomerCollection FilteredCustomers = new clsCustomerCollection();
            //apply a blank string 
            FilteredCustomers.ReportByEmail("");
            //test to see that the two values are the same
            Assert.AreEqual(AllCustomers.Count, FilteredCustomers.Count);
        }

        [TestMethod]
        public void ReportByEmailNotFound()
        {
            //create an instance of the filtered adata
            clsCustomerCollection FilteredCustomers = new clsCustomerCollection();
            //apply a post code that doesnt exist
            FilteredCustomers.ReportByEmail("xxxx@xxxx.xxx");
            //test to see that there are no records
            Assert.AreEqual(0, FilteredCustomers.Count);
        }
    }
}
}
