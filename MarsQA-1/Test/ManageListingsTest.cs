using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsQA_1.Pages.ShareSkill;

namespace MarsQA_1.Test
{
    [TestFixture]
    [Parallelizable]
    public class ManageListingsTest :  Global.Base// Driver
    {
        ManageListings manageListingsObj;
        ShareSkill shareSkillObj;

        string errmsg = "has been deleted";


        [Test, Order(1)]
        public void TC_001ClickManageListings()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.NaviageToManageListings();
            String URL = manageListingsObj.GetURL();
            Assert.That(URL.Contains("ListingManagement"), "Failed click to Manage Listing");

        }


        [Test, Order(2)]
        public void TC_002VerifyListingDetails()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Driver.ImplicitWaitMethod();
            VerifyListingDetails(2, "ShareSkill");

        }


        [Test, Order(3)]
        public void TC_003VerifyViewIconofManageListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Driver.ImplicitWaitMethod();
         
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            manageListingsObj.ViewListing(2, "ShareSkill");


        }
        [Test, Order(4)]
        public void TC_004EditListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.EditListing(2, 3, "ManageListings");
            VerifyListingDetails(3, "ManageListings");
        }


        [Test, Order(5)]
        public void TC_005VerifyDeleteManageListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Driver.ImplicitWaitMethod();

            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();

            manageListingsObj.DeleteListing(3, "ManageListings");
            //manageListingsObj.DeleteListing(2, "ManageListings");
            string errormessage = manageListingsObj.GetMessage();
            Assert.That(errormessage.Contains(errmsg), "Delete Failed");
            VerifyDelete(3, "ManageListings");

        }
             

        public void VerifyListingDetails(int rowNumber, string worksheet)
        {
            //Click on view Listing
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            manageListingsObj.ViewListing(rowNumber, worksheet);

            Listing excel = new Listing();
            Listing web = new Listing();


            shareSkillObj.GetExcel(rowNumber, worksheet, out excel);

            shareSkillObj.GetWeb(out web);

            //Assertions
            Assert.Multiple(() =>
            {

                //Verify expected Title vs actual Title
                Assert.AreEqual(excel.title, web.title);

                //Verify expected Description vs actual Description
                Assert.AreEqual(excel.description, web.description);

                //Verify expected Category vs actual Category
                Assert.AreEqual(excel.category, web.category);

                //Verify expected Subcategory vs actual Subcategory
                Assert.AreEqual(excel.subcategory, web.subcategory);

                //Verify expected ServiceType vs actual ServiceType
                string serviceTypeText = "Hourly";
                if (excel.serviceType == "One-off service")
                    serviceTypeText = "One-off";
                Assert.AreEqual(serviceTypeText, web.serviceType);

                //Verify expected StartDate vs actual StartDate
                string expectedStartDate = DateTime.Parse(DateTime.Today.ToString()).ToString("yyyy-MM-dd");
                Assert.AreEqual(expectedStartDate, web.startDate);

                //Verify expected EndDate vs actual EndDate
                string expectedEndDate = DateTime.Parse(DateTime.Today.ToString()).ToString("yyyy-MM-dd");
                //string expectedEndDate = DateTime.Parse(DateTime.Today.AddDays(1).ToString()).ToString("yyyy-MM-dd");
                Assert.AreEqual(expectedEndDate, web.endDate);

                //Verify expected LocationType vs actual LocationType
                string expectedLocationType = excel.locationType;
                if (expectedLocationType.Equals("On-site"))
                    expectedLocationType = "On-Site";
                Assert.AreEqual(expectedLocationType, web.locationType);

                //Verify Skills Trade
                if (excel.skillTrade == "Credit")
                    Assert.AreEqual("None Specified", shareSkillObj.GetSkillTrade("Credit"));
                else
                    Assert.AreEqual(excel.skillExchange, shareSkillObj.GetSkillTrade("Skill-exchange"));
            });

        }
        


        public void VerifyDelete(int rowNumber, string worksheet)
        {
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();

            //Populate excel data
            Listing excel = new Listing();
            shareSkillObj.GetExcel(rowNumber, worksheet, out excel);

            //Click on Manage Listing
            manageListingsObj.NaviageToManageListings();

            //Assertion
            Assert.AreNotEqual(excel.title, manageListingsObj.VerifyTheManageListingTitle(excel.title), "Delete Failed");
        }

    }
}
