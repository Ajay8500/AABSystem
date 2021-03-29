using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AAB_Testing
{
    [TestClass]
    public class tstOrders
    {
        [TestMethod]
        public void IsInstanceOk()
        {
            //create an instance of the class we want create
            clsOrder AOrder = new clsOrder();

            //Test to see that it exists
            Assert.IsNotNull(AOrder);
        }

        [TestMethod]
        public void OrderDateOk()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //create some test data to assign to the property
            DateTime TestData = DateTime.Now.Date;
            //assign the data to the property
            AOrder.OrderDate = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AOrder.OrderDate, TestData);
        }

        [TestMethod]
        public void OrderPostCodeOk()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //create some test data to assign to the property
            string TestData = "LE2";
            //assign the data to the property
            AOrder.OrderPostCode = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AOrder.OrderPostCode, TestData);
        }
        [TestMethod]
        public void OrderHouseNo()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //create some test data to assign to the property
            string TestData = "LE2";
            //assign the data to the property
            AOrder.OrderHouseNo = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AOrder.OrderHouseNo, TestData);
        }

        [TestMethod]
        public void CustomerNameOk()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //create some test data to assign to the property
            string TestData = "Baijeed Chowdhury";
            //assign the data to the property
            AOrder.CustomerName = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AOrder.CustomerName, TestData);
        }

        [TestMethod]
        public void OrderItemOk()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //create some test data to assign to the property
            string TestData = "Mercedes";
            //assign the data to the property
            AOrder.OrderItem = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AOrder.OrderItem, TestData);
        }

        [TestMethod]
        public void OrderIDOk()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            AOrder.OrderID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AOrder.OrderID, TestData);
        }

        [TestMethod]
        public void CustomerID()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //create some test data to assign to the property
            Int32 TestData = 1;
            //assign the data to the property
            AOrder.CustomerID = TestData;
            //test to see that the two values are the same
            Assert.AreEqual(AOrder.CustomerID, TestData);
        }
        [TestMethod]
        public void FindMethodOk()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //create some test data to use with the method
            Int32 OrderID = 21;
            //invoke the method
            Found = AOrder.Find(OrderID);
            //test to see if the result is true
            Assert.IsTrue(Found);


        }
        [TestMethod]
        public void TestOrderNoFound()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to reocrd if data is Ok (assume it is)
            Boolean Ok = true;
            //create some test data to use with the method
            Int32 OrderID = 21;
            //invoke the method
            Found = AOrder.Find(OrderID);
            //check the OrderNo
            if (AOrder.OrderID != 21)
            {
                Ok = false;
            }
            //test to see if the result is true
            Assert.IsTrue(Ok);
        }
        [TestMethod]
        public void TestOrderDateFound()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to reocrd if data is Ok (assume it is)
            Boolean Ok = true;
            //create some test data to use with the method
            Int32 OrderID = 21;
            //invoke the method
            Found = AOrder.Find(OrderID);
            //check the OrderNo
            if (AOrder.OrderDate != Convert.ToDateTime("28/03/2021"))
            {
                Ok = false;
            }
            //test to see if the result is true
            Assert.IsTrue(Ok);
        }
        [TestMethod]
        public void TestOrderPostCodeFound()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 OrderID = 21;
            //invoke the method
            Found = AOrder.Find(OrderID);
            //check the property
            if (AOrder.OrderPostCode != "LE2 3NF")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }
        [TestMethod]
        public void TestOrderHouseNoFound()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 OrderID = 21;
            //invoke the method
            Found = AOrder.Find(OrderID);
            //check the property
            if (AOrder.OrderHouseNo != "103")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }
        [TestMethod]
        public void TestOrderCustomerNameFound()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 OrderID = 21;
            //invoke the method
            Found = AOrder.Find(OrderID);
            //check the property
            if (AOrder.CustomerName != "Baijeed Chowdhury")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }
        [TestMethod]
        public void TestOrderItemFound()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 OrderID = 21;
            //invoke the method
            Found = AOrder.Find(OrderID);
            //check the property
            if (AOrder.OrderItem != "Mercedes")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }
        [TestMethod]
        public void TestCustomerID()
        {
            //create an instance of the class we want to create
            clsOrder AOrder = new clsOrder();
            //boolean variable to store the result of the search
            Boolean Found = false;
            //boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 OrderID = 21;
            //invoke the method
            Found = AOrder.Find(OrderID);
            //check the property
            if (AOrder.CustomerID != 1)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

    }
}