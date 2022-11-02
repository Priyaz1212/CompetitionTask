using MarsQA_1.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using static MarsQA_1.Global.GlobalDefinitions;
using MarsQA_1.Global;
using System.Data;
using NUnit.Framework;

namespace MarsQA_1.Pages
{
    public class ManageListings
    {

        public ManageListings()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement? manageListingsLink { get; set; }


        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement? view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement? delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement? edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']/button")]
        private IList<IWebElement>? clickActionsButton { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//div[@id='listing-management-section']//tbody/tr/td[3]")]
        private IList<IWebElement>? Titles { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='listing-management-section']//tbody/tr/td[4]")]
        private IList<IWebElement>? Descriptions { get; set; }


        //message
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement? message { get; set; }

        private string e_message = "//div[@class='ns-box-inner']";


        public void NaviageToManageListings()
        {

            Driver.ImplicitWaitMethod();
            manageListingsLink.Click();


        }

        public string GetURL()
        {
            String url = Driver.driver.Url;
            return url;
        }



        public string VerifyTheManageListingTitle(string expectedTitle)
        {
            
            int titleCount = Titles.Count;
            string actualTitle = "null";

            if (titleCount.Equals(0))
            {
                return actualTitle;
            }
            else
            {
                //Verify if title is deleted
                for (int i = 0; i < titleCount; i++)
                {
                    // actualTitle = Titles[i].Text;
                    if (expectedTitle.Equals(Titles[i].Text))
                    {
                        actualTitle = Titles[i].Text;
                        break;
                    }
                }
                return actualTitle;
            }
           
        }

        //Click on manage listing
        internal void GoToManageListings()
        {
            try
            {
                //Click Manage Listing
                manageListingsLink.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Manage Listing link is not found.", ex.Message);
            }
        }
        public void ViewListing(int rowNumber, string worksheet)
        {

            //Click on ManageListing
            GoToManageListings();
            Driver.ImplicitWaitMethod();

            //Read data
            ExcelLib.PopulateInCollection(Base.ExcelPath, worksheet);
            string expectedTitle = ExcelLib.ReadData(rowNumber, "Title");

            //Click on button View
            string e_View = "//div[@id='listing-management-section']//tbody/tr[" + GetTitleIndex(expectedTitle) + "]/td[8]/div/button[1]";
            IWebElement btnView = Driver.driver.FindElement(By.XPath(e_View));
            btnView.Click();

            Driver.ImplicitWaitMethod();
        }

        public void DeleteListing(int rowNumber, string worksheet)
        {

            //Click on ManageListing
            GoToManageListings();
            Driver.ImplicitWaitMethod();

            //Read data
            ExcelLib.PopulateInCollection(Base.ExcelPath, worksheet);
            string expectedTitle = ExcelLib.ReadData(rowNumber, "Title");

            //Click on button View
            string e_del= "//div[@id='listing-management-section']//tbody/tr[" + GetTitleIndex(expectedTitle) + "]/td[8]/div/button[3]";
            IWebElement btndel = Driver.driver.FindElement(By.XPath(e_del));
            btndel.Click();
            Driver.ImplicitWaitMethod();

               
            //Read data
            string isDelete = ExcelLib.ReadData(rowNumber, "isDelete");
            //Click Yes

            if (isDelete.Equals("Yes"))
            {
                clickActionsButton[1].Click();
                
            }
            else
            {
                clickActionsButton[0].Click();
                
            }

        }
        
        public int GetExcelRowsCount(string worksheet)
        {

            Driver.ImplicitWaitMethod();

            //Read data
            ExcelLib.PopulateInCollection(Base.ExcelPath, worksheet);
            int rowcount = ExcelLib.GetRowsCount();

            return rowcount;
            
        }
        internal string GetTitleIndex(string expectedTitle)
        {
            //Check if there is no listing's title
            string recordIndex = "";
            int titleCount = Titles.Count();
            if (titleCount.Equals(0))
            {
                Assert.Ignore("There is no listing record.");
            }
            else
            {
                //Find title: Break loop when finding a title. Output: recordIndex
                for (int i = 0; i < titleCount; i++)
                {
                    string actualTitle = Titles[i].Text;
                    if (actualTitle.Equals(expectedTitle))
                    {
                        recordIndex = (i + 1).ToString();
                        break;
                    }
                }
                //If title-to-delete is not found
                if (recordIndex.Equals(""))
                {
                    Assert.Ignore("Listing '" + expectedTitle + "' is not found.");
                }
            }
            return recordIndex;
        }

        //Edit listing
        public void EditListing(int rowNumber1, int rowNumber2, string worksheet)
        {
            Driver.ImplicitWaitMethod();
            ShareSkill shareSkillObj = new ShareSkill();
            //Click on ManageListing
            GoToManageListings();
            Driver.ImplicitWaitMethod();
            //Populate the Excel Sheet
            ExcelLib.PopulateInCollection(Base.ExcelPath, worksheet);

            //Read data
            string expectedTitle = ExcelLib.ReadData(rowNumber1, "Title");

            //Click on button Edit
            string e_Edit = "//div[@id='listing-management-section']//tbody/tr[" + GetTitleIndex(expectedTitle) + "]/td[8]/div/button[2]";
            IWebElement btnEdit = Driver.driver.FindElement(By.XPath(e_Edit));
            btnEdit.Click();
            Driver.ImplicitWaitMethod();

            shareSkillObj.ClearData();
            Driver.ImplicitWaitMethod();
            shareSkillObj.AddListing(rowNumber2, worksheet);
            Driver.ImplicitWaitMethod();
        }

        public string GetMessage()
        {

            string str = "";
            try
            {
                if (message != null)
                {
                    str = message.Text;
                }
                return str;
            }
            catch (Exception e)
            {
                return str;
            }


        }




    }
}
