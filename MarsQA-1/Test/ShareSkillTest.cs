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
    public class ShareSkillTest :  Global.Base
    {
        ShareSkill shareSkillObj;
        ManageListings manageListingsObj;

        string errmsgtitle = "Please type a Title.";
        string errmsgdesc = "Please type a description.";
        string errmsgSplChar = "Special characters are not allowed.";
        string errmsgsplChar2 = "First character must be an alphabet character or a number.";
        string errtag = "Please enter a tag";
        string errdatemsg = "Start Date shouldn't be greater than End Date";
        string formerrormsg = "Please complete the form correctly.";
        string formmsg = "Service Listing Added Sucessfully";
        string errmsgupload = "There is an error when updating Work Samples - undefined";


        [Test, Order(1)]
        public void TC_001ValidateTitle()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            Listing excel = new Listing();
            string worksheet = "ShareSkill";
            shareSkillObj.GetExcel(2, worksheet, out excel);

            //Assertions
            Assert.Multiple(() =>
            {
    
                Assert.AreEqual(excel.title, shareSkillObj.EnterTitle(excel.title));
                Assert.AreEqual(excel.title, shareSkillObj.EditTitle(excel.title));
                Assert.AreEqual(errmsgtitle, shareSkillObj.DeleteTitle(excel.title));
                Assert.AreEqual(errmsgSplChar, shareSkillObj.ValidateTittle("A@5$dfsd"));//Negatoive Test
            });

        }


        [Test, Order(2)]
        public void TC_002ValidateDesc()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            Listing excel = new Listing();
            string worksheet = "ShareSkill";
            shareSkillObj.GetExcel(2, worksheet, out excel);

            //Assertions
            Assert.Multiple(() =>
            {
                //Verify expected Title vs actual Title
                Assert.AreEqual(excel.description, shareSkillObj.EnterDesc(excel.description));
                Assert.AreEqual(excel.description, shareSkillObj.EditDesc(excel.description));
                Assert.AreEqual(errmsgdesc, shareSkillObj.DeleteDesc(excel.description));
                Assert.AreEqual(errmsgsplChar2, shareSkillObj.ValidateDesc("@5$dfsdcsdd^$&zcsfseset#%"));//Negative
            });

        }



        [Test, Order(3)]
        public void TC_003ValidateCategory()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            Listing excel = new Listing();
            Listing excel1 = new Listing();
            string worksheet = "ShareSkill";
            shareSkillObj.GetExcel(2, worksheet, out excel);
            shareSkillObj.GetExcel(3, worksheet, out excel1);

            //Assertions
            Assert.Multiple(() =>
            {
                //Verify expected Title vs actual Title
                Assert.AreEqual(excel.category, shareSkillObj.SelectCategory(excel.category));
                Assert.AreEqual(excel.subcategory, shareSkillObj.SelectSubCategory(excel.subcategory));
                //Change Category and SubCategory
                Assert.AreEqual(excel1.category, shareSkillObj.SelectCategory(excel1.category));
                Assert.AreEqual(excel1.subcategory, shareSkillObj.SelectSubCategory(excel1.subcategory));
            });

        }


        [Test, Order(4)]
        public void TC_004ValidateTags()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            Listing excel = new Listing();
            string worksheet = "ShareSkill";
            shareSkillObj.GetExcel(2, worksheet, out excel);
   
            //Assertions
            Assert.Multiple(() =>
            {
                //Verify expected Title vs actual Title
                Assert.AreEqual(excel.tags, shareSkillObj.EnterTagName(excel.tags));
                Assert.AreEqual(errtag, shareSkillObj.DeleteTagName(excel.tags));

            });

        }

        [Test, Order(5)]
        public void TC_005ValidateServiceType()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            Listing excel = new Listing();
            string worksheet = "ShareSkill";
            shareSkillObj.GetExcel(2, worksheet, out excel);
            Assert.That(shareSkillObj.SelectServiceType(excel.serviceType), "Error Selecting Service Type");
            shareSkillObj.GetExcel(3, worksheet, out excel);
            Assert.That(shareSkillObj.SelectServiceType(excel.serviceType), "Error Selecting Service Type");
        }
        [Test, Order(6)]
        public void TC_006ValidateLocationType()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            Listing excel = new Listing();
            string worksheet = "ShareSkill";
            shareSkillObj.GetExcel(2, worksheet, out excel);
            //Checking Onsite option
            Assert.That(shareSkillObj.SelectLocationType(excel.locationType), "Error Selecting Location Type");
            //Checking Online option
            shareSkillObj.GetExcel(3, worksheet, out excel);
            Assert.That(shareSkillObj.SelectLocationType(excel.locationType), "Error Selecting Location Type");

        }

        [Test, Order(7)]
        public void TC_007ValidateStartDate()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();

            string worksheet = "ShareSkill";
   

            //Assertions
            Assert.Multiple(() =>
            {
                string expectedStartDate = DateTime.Parse(DateTime.Today.ToString()).ToString("yyyy-MM-dd");
                string expectedDate = DateTime.Parse(DateTime.Today.AddDays(1).ToString()).ToString("yyyy-MM-dd");
                string strtdatenew = DateTime.Today.ToString("dd/MM/yyyy");
                string strtdateedit = DateTime.Today.AddDays(1).ToString("dd/MM/yyyy");
                Assert.AreEqual(expectedStartDate, shareSkillObj.EnterStartDate(strtdatenew));
                Assert.AreEqual(expectedDate, shareSkillObj.EditStartDate(strtdateedit));
                Assert.AreEqual("", shareSkillObj.DeleteStartDate(DateTime.Today.ToString()));
            });

        }

        [Test, Order(8)]
        public void TC_008ValidateEndDate()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            string worksheet = "ShareSkill";
            //Assertions
            Assert.Multiple(() =>
            {
                string expectedendDate = DateTime.Parse(DateTime.Today.ToString()).ToString("yyyy-MM-dd");
                string endDate = DateTime.Parse(DateTime.Today.AddDays(1).ToString()).ToString("yyyy-MM-dd");
                string enddatenew = DateTime.Today.ToString("dd/MM/yyyy");
                string enddateedit = DateTime.Today.AddDays(1).ToString("dd/MM/yyyy");
                Assert.AreEqual(expectedendDate, shareSkillObj.EnterEndDate(enddatenew));
                Assert.AreEqual(endDate, shareSkillObj.EditEndDate(enddateedit));
                Assert.AreEqual("", shareSkillObj.DeleteEndDate(DateTime.Today.ToString()));
            });

        }
        [Test, Order(9)]
        public void TC_009ValidateAvailableDays()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            Listing excel = new Listing();
            string worksheet = "ShareSkill";
            shareSkillObj.GetExcel(2, worksheet, out excel);
            //Assertions
            shareSkillObj.EnterAvailableDaysAndHours(excel.availableDays, excel.startTime, excel.endTime);
            bool isDelete = false;
            shareSkillObj.EditOrDeleteAvailableDaysAndHours(excel.availableDays, excel.startTime, excel.endTime, isDelete);
            isDelete = true;
            shareSkillObj.EditOrDeleteAvailableDaysAndHours(excel.availableDays, excel.startTime, excel.endTime, isDelete);

        }

        [Test, Order(10)]
        public void TC_010ValidateSkillSTrade()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            Listing excel = new Listing();
            string worksheet = "ShareSkill";
            shareSkillObj.GetExcel(2, worksheet, out excel);
            //Assertions
            Assert.Multiple(() =>
            {
                Assert.That(shareSkillObj.SelectSkillTrade(excel.skillTrade, excel.skillExchange, excel.credit), "Error Selecting Skills Trade");
                Assert.That(shareSkillObj.ClearSkillTrade(), "Error clearing Skills Trade");
                Assert.That(shareSkillObj.SelectSkillTrade("Skill-exchange", "Test", ""), "Error Selecting Skills Exchange");
                Assert.That(shareSkillObj.ClearSkillTrade(), "Error clearing Skills Exchange");
            });

        }
        [Test, Order(11)]
        public void TC_011ValidateWorkSamples()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();

            //yet to complete
            shareSkillObj.UploadWorkSamples();
            string str = shareSkillObj.FileUploadStr();
            
            Assert.That(str.Contains("Test"), "File Upload Failed");
            Assert.That(shareSkillObj.FileUploadDel, "File Delete Failed");
            
        }

        [Test, Order(12)]
        public void TC_012ValidateActive()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            Listing excel = new Listing();
            string worksheet = "ShareSkill";
            shareSkillObj.GetExcel(2, worksheet, out excel);
            //Assertions
            Assert.Multiple(() =>
            {
                Assert.That(shareSkillObj.ClickActiveOption(excel.ActiveOption), "Error Selecting Active option");

            });

        }

        [Test, Order(13)]
        public void TC_013ValidateSaveWithoutUploadFile()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            
            string worksheet = "ShareSkill";

            int rows = manageListingsObj.GetExcelRowsCount(worksheet);
            Assert.That(rows > 0, "No rows returned in excel " + worksheet);
            
                Listing excel = new Listing();
                shareSkillObj.GetExcel(2, worksheet, out excel);

                //Assertions
                Assert.Multiple(() =>
                {
                    //Verify expected Title vs actual Title
                    Assert.AreEqual(excel.title, shareSkillObj.EnterTitle(excel.title));
                    Assert.AreEqual(excel.description, shareSkillObj.EnterDesc(excel.description));
                    Assert.AreEqual(excel.category, shareSkillObj.SelectCategory(excel.category));
                    Assert.AreEqual(excel.subcategory, shareSkillObj.SelectSubCategory(excel.subcategory));
                    //Verify expected Title vs actual Title
                    Assert.AreEqual(excel.tags, shareSkillObj.EnterTagName(excel.tags));
                    Assert.That(shareSkillObj.SelectServiceType(excel.serviceType), "Error Selecting Service Type");
                    Assert.That(shareSkillObj.SelectLocationType(excel.locationType), "Error Selecting Location Type");


                    string startDatenew = DateTime.Today.ToString("dd/MM/yyyy");
                    string enddatenew = DateTime.Today.ToString("dd/MM/yyyy");


                    string expectedStartDate = DateTime.Parse(DateTime.Today.ToString()).ToString("yyyy-MM-dd");
                    Assert.AreEqual(expectedStartDate, shareSkillObj.EnterStartDate(startDatenew));
                    string expectedendDate = DateTime.Parse(DateTime.Today.ToString()).ToString("yyyy-MM-dd");
                    Assert.AreEqual(expectedendDate, shareSkillObj.EnterEndDate(enddatenew));
                    shareSkillObj.EnterAvailableDaysAndHours(excel.availableDays, excel.startTime, excel.endTime);
                    Assert.That(shareSkillObj.SelectSkillTrade(excel.skillTrade, excel.skillExchange, excel.credit), "Error Selecting Skills Trade");
                    Assert.That(shareSkillObj.ClickActiveOption(excel.ActiveOption), "Error Selecting Active option");
                    //shareSkillObj.UploadWorkSamples();
                    shareSkillObj.ClickSave();

                    Assert.AreNotEqual(formerrormsg, shareSkillObj.GetMessage());
                    Assert.That(Driver.driver.Url.Contains("ListingManagement") ,"Save Failed");
                });
        }

        
        [Test, Order(14)]
        public void TC_014ValidateSaveWithUpload()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();

            string worksheet = "ShareSkill";

            int rows = manageListingsObj.GetExcelRowsCount(worksheet);
            Assert.That(rows > 0, "No rows returned in excel " + worksheet);

            Listing excel = new Listing();
            shareSkillObj.GetExcel(2, worksheet, out excel);

            //Assertions
            Assert.Multiple(() =>
            {
                //Verify expected Title vs actual Title
                Assert.AreEqual(excel.title, shareSkillObj.EnterTitle(excel.title));
                Assert.AreEqual(excel.description, shareSkillObj.EnterDesc(excel.description));
                Assert.AreEqual(excel.category, shareSkillObj.SelectCategory(excel.category));
                Assert.AreEqual(excel.subcategory, shareSkillObj.SelectSubCategory(excel.subcategory));
                //Verify expected Title vs actual Title
                Assert.AreEqual(excel.tags, shareSkillObj.EnterTagName(excel.tags));
                Assert.That(shareSkillObj.SelectServiceType(excel.serviceType), "Error Selecting Service Type");
                Assert.That(shareSkillObj.SelectLocationType(excel.locationType), "Error Selecting Location Type");


                string startDatenew = DateTime.Today.ToString("dd/MM/yyyy");
                string enddatenew = DateTime.Today.ToString("dd/MM/yyyy");


                string expectedStartDate = DateTime.Parse(DateTime.Today.ToString()).ToString("yyyy-MM-dd");
                Assert.AreEqual(expectedStartDate, shareSkillObj.EnterStartDate(startDatenew));
                string expectedendDate = DateTime.Parse(DateTime.Today.ToString()).ToString("yyyy-MM-dd");
                Assert.AreEqual(expectedendDate, shareSkillObj.EnterEndDate(enddatenew));
                shareSkillObj.EnterAvailableDaysAndHours(excel.availableDays, excel.startTime, excel.endTime);
                Assert.That(shareSkillObj.SelectSkillTrade(excel.skillTrade, excel.skillExchange, excel.credit), "Error Selecting Skills Trade");
                Assert.That(shareSkillObj.ClickActiveOption(excel.ActiveOption), "Error Selecting Active option");
                shareSkillObj.UploadWorkSamples();
                shareSkillObj.ClickSave();
                string errmsg = shareSkillObj.GetMessageError();
                if(errmsg == errmsgupload)
                {
                    Assert.Fail("Upload file Failed");
                }
                Assert.IsFalse(Driver.driver.Url.Contains("ServiceListing"));
            });

        }

        [Test, Order(15)]
        public void TC_015ValidateSaveWithoutData()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();

            string worksheet = "ShareSkill";

            int rows = manageListingsObj.GetExcelRowsCount(worksheet);
            Assert.That(rows > 0, "No rows returned in excel " + worksheet);

            Listing excel = new Listing();
            shareSkillObj.GetExcel(2, worksheet, out excel);

            //Assertions
            Assert.Multiple(() =>
            {
               
                shareSkillObj.ClickSave();
                Assert.AreEqual(formerrormsg, shareSkillObj.GetMessage());
                //Assert.AreNotEqual(formmsg, shareSkillObj.GetMessage(), "Save Failed");
            });
        }


        [Test, Order(16)]
        public void TC_016ValidateCancel()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            shareSkillObj = new ShareSkill();
            shareSkillObj.NaviageToShareSkill();
            Listing excel = new Listing();
            string worksheet = "ShareSkill";
            shareSkillObj.GetExcel(2, worksheet, out excel);
            Assert.Multiple(() =>
            {
                shareSkillObj.EnterAvailableDaysAndHours(excel.availableDays, excel.startTime, excel.endTime);
                Assert.That(shareSkillObj.SelectSkillTrade(excel.skillTrade, excel.skillExchange, excel.credit), "Error Selecting Skills Trade");
                Assert.That(shareSkillObj.ClickActiveOption(excel.ActiveOption), "Error Selecting Active option");
                shareSkillObj.ClickCancel();
                Assert.IsTrue(Driver.driver.Url.Contains("Profile"));
            });
             
        }
        [Test, Order(17)]
        public void TC_013_02ValidateSaveDuplicate()
        {
            TC_013ValidateSaveWithoutUploadFile();
        }


    }
}
