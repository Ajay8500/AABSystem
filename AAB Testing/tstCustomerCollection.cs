using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AAB_Testing
{
    [TestClass]
    public class tstCustomerCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the clas we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //tesst to see that it exists
            Assert.IsNotNull(AllCustomers);
        }

        [TestMethod]
        public void CustomerListOK()
        {
            //create an instanceof the clas we want to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create some test data to asign ot the property 
            // in this case the data needs ot be a list of objects
            List<clsCustomer> TestList = new List<clsCustomer>();
            //add an item to the list
            //create the ote, pf test data
            clsCustomer TestItem = new clsCustomer();
            //set its properties
            TestItem.Active = true;
            TestItem.CustomerID = 1;
            TestItem.CustomerFirstName = "First";
            TestItem.CustomerLastName = "Last";
            TestItem.CustomerEmail = "Admin@gmail.com";
            TestItem.CustomerTeleNo = "XXXXXXXXXX";
            //add the item to the test list
            TestList.Add(TestItem);
            //asign the data to the property
            AllCustomers.CustomerList = TestList;
            //test to see that the teo valies are the same
            Assert.AreEqual(AllCustomers.CustomerList, TestList);
        }

        [TestMethod]
        public void ThisCustomerPropertyOK()
        {
            //create an instanceof the clas we watn to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create some test data to asign ot the property 
            clsCustomer TestCustomer = new clsCustomer();
            //set its properties
            TestCustomer.Active = true;
            TestCustomer.CustomerID = 1;
            TestCustomer.CustomerFirstName = "First";
            TestCustomer.CustomerLastName = "Last";
            TestCustomer.CustomerEmail = "Admin@gmail.com";
            TestCustomer.CustomerTeleNo = "XXXXXXXXXX";
            //asign the data to the property
            AllCustomers.ThisCustomer = TestCustomer;
            //test to see that the teo valies are the same
            Assert.AreEqual(AllCustomers.ThisCustomer, TestCustomer);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            //create an instanceof the clas we watn to create
            clsCustomerCollection AllCustomers = new clsCustomerCollection();
            //create some test data to asign ot the property 
            // in this case the data needs ot be a list of objects
            List<clsCustomer> TestList = new List<clsCustomer>();
            //add an item to the list
            //create the ote, pf test data
            clsCustomer TestItem = new clsCustomer();
            //set its properties
            TestItem.Active = true;
            TestItem.CustomerID = 1;
            TestItem.CustomerFirstName = "First";
            TestItem.CustomerLastName = "Last";
            TestItem.CustomerEmail = "Admin@gmail.com";
            TestItem.CustomerTeleNo = "XXXXXXXXXX";
            //add the item to the test list
            TestList.Add(TestItem);
            //asign the data to the property
            AllCustomers.CustomerList = TestList;
            //test to see that the teo valies are the same
            Assert.AreEqual(AllCustomers.Count, TestList.Count);
        }
    }
}
}
