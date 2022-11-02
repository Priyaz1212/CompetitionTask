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
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Diagnostics;

namespace MarsQA_1.Pages
{
    public class ShareSkill
    {

        public ShareSkill()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        //Tittle
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement? Title { get; set; }

        //Desc
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement? Desc { get; set; }

        //categoryId
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement? Category { get; set; }

        //categoryId
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement? Subcategory { get; set; }

       
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        private IWebElement? AddNewTag { get; set; }

        //Entered displayed Tags input
        [FindsBy(How = How.ClassName, Using = "ReactTags__tag")]
        private IList<IWebElement>? EnteredTags { get; set; }

        //serviceType
        [FindsBy(How = How.Name, Using = "serviceType")]
        private IList<IWebElement>? serviceType { get; set; }

        //LocationType
        [FindsBy(How = How.Name, Using = "locationType")]
        private IList<IWebElement>? locationType { get; set; }

        //*[@name="startDate"]
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement? startDate { get; set; }

        //*[@name="startDate"]
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement? endDate { get; set; }

        //AvailableDays
        [FindsBy(How = How.Name, Using = "Available")]
        private IList<IWebElement>? AvailableDays { get; set; }

        //StartTime
        [FindsBy(How = How.Name, Using = "StartTime")]
        private IList<IWebElement>? StartTime { get; set; }


        //EndTime
        [FindsBy(How = How.Name, Using = "EndTime")]
        private IList<IWebElement>? EndTime { get; set; }

        //EndTime
        [FindsBy(How = How.Name, Using = "skillTrades")]
        private IList<IWebElement>? skillTrades { get; set; }
        //charge
        [FindsBy(How = How.Name, Using = "charge")]
        private IWebElement? charge { get; set; }

        //Skill Exchange Tag
        
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        private IWebElement? SkillExchangeTag { get; set; }

        //Active
        [FindsBy(How = How.Name, Using = "isActive")]
        private IList<IWebElement>? Active { get; set; }


        //Work Samples button
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement? btnWorkSamples { get; set; }

        //Save btn

        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement? Save { get; set; }

        //Cancel btn

        [FindsBy(How = How.XPath, Using = "//input[@value='Cancel']")]
        private IWebElement? Cancel { get; set; }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement?  ShareSkillLink { get; set; }

        //message
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement? message { get; set; }
        private string e_message = "//div[@class='ns-box-inner']";

        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")]
        private IWebElement? e_messageErr { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[@class='file pdf']")]
        private IWebElement? e_fileupload { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='remove sign icon floatRight']")]
        private IWebElement? fileUploadDel { get; set; }
        



        #region Page Objects for VerifyShareSkill
        //Title

        [FindsBy(How = How.XPath, Using = "//span[@class='skill-title']")]
        private IWebElement? actualTitle { get; set; }

        //Description
        [FindsBy(How = How.XPath, Using = "//div[text()='Description']//following-sibling::div")]
        private IWebElement? actualDescription { get; set; }

        //Category
        [FindsBy(How = How.XPath, Using = "//div[text()='Category']//following-sibling::div")]
        private IWebElement? actualCategory { get; set; }

        //Subcategory
        [FindsBy(How = How.XPath, Using = "//div[text()='Subcategory']//following-sibling::div")]
        private IWebElement? actualSubcategory { get; set; }
        //Service Type
        [FindsBy(How = How.XPath, Using = "//div[text()='Service Type']//following-sibling::div")]
        private IWebElement? actualServiceType { get; set; }
        //Start Date
        [FindsBy(How = How.XPath, Using = "//div[text()='Start Date']//following-sibling::div")]
        private IWebElement? actualStartDate { get; set; }
        //End Date

        [FindsBy(How = How.XPath, Using = "//div[text()='End Date']//following-sibling::div")]
        private IWebElement? actualEndDate { get; set; }
        //Location Type
        [FindsBy(How = How.XPath, Using = "//div[text()='Location Type']//following-sibling::div")]
        private IWebElement? actualLocationType { get; set; }
        //Skill Trade
        [FindsBy(How = How.XPath, Using = "//div[text()='Skills Trade']//following-sibling::div")]
        private IWebElement? actualSkillsTrade { get; set; }
        //Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[text()='Skills Trade']//following-sibling::div/span")]
        private IWebElement? actualSkillExchange { get; set; }
        #endregion

        //Entered displayed Tags delete button
        
        [FindsBy(How = How.XPath, Using = "//form[@class='ui form']/div[4]/div[2]/div/div/div/span/a")]
        private IList<IWebElement>? displayedTags { get; set; }

        //Entered displayed Tags delete button
        [FindsBy(How = How.XPath, Using = "//form[@class='ui form']/div[4]/div[2]/div/div/div/span")]
        private IList<IWebElement>? displayedTagsText { get; set; }

        //Error WebElements

        //Title error message
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[2]/div")]
        private IWebElement? errorTitle { get; set; }

        //Desc error message
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[2]/div")]
        private IWebElement? errorDesc { get; set; }

        //Tags error message
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div[2]")]
        private IWebElement? errorTag { get; set; }

        

   
        public void NaviageToShareSkill()
        {

            Driver.ImplicitWaitMethod();
            Driver.WaitForElementToBeClickable(Driver.driver, By.LinkText("Share Skill"), 5);
            ShareSkillLink.Click();
        }

        #region tittle methods
        public string EnterTitle(string title)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("title"), 5);
            Title.SendKeys(title);
            String str = Title.GetAttribute("value");

            return str;
        }
        public string EditTitle(string title)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("title"), 5);
            //Clear title
            Title.Click();
            Title.Clear();
            Title.SendKeys(title);
            
            String str = Title.GetAttribute("value");

            return str;
        }
        public string DeleteTitle(string title)
        {
            //Clear title
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("title"), 5);
            Title.Click();
            Title.SendKeys(Keys.Control + "A");
            Title.SendKeys(Keys.Delete);

            Driver.ImplicitWaitMethod();
            string str = "";
            if(errorTitle != null)
            {
                str = errorTitle.Text;
            }
            return str;
        }

        public string ValidateTittle(string title)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("title"), 5);
            //Clear title
            Title.SendKeys(title);
            string str = "";
            if (errorTitle != null)
            {
                str = errorTitle.Text;
            }
            return str;


        }
        #endregion

        #region Description methods
        public string EnterDesc(string description)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("description"), 5);
            Desc.SendKeys(description);
            String str = Desc.GetAttribute("value");

            return str;
        }
        public string EditDesc(string description)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("description"), 5);
            //Clear title
            Desc.Click();
            Desc.Clear();
            Desc.SendKeys(description);

            String str = Desc.GetAttribute("value");

            return str;
        }
        public string DeleteDesc(string description)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("description"), 5);
            //Clear title
            Desc.Click();
            Desc.SendKeys(Keys.Control + "A");
            Desc.SendKeys(Keys.Delete);

            string str = "";
            if (errorDesc != null)
            {
                str = errorDesc.Text;
            }
            return str;
        }

        public string ValidateDesc(string description)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("description"), 5);
            //Clear title
            Desc.SendKeys(description);
            string str = "";
            if (errorDesc != null)
            {
                str = errorDesc.Text;
            }
            return str;


        }
        #endregion

        #region Category methods
        public string SelectCategory(string categorydata)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("categoryId"), 5);
            //Select category
            var selectCategory = new SelectElement(Category);
            selectCategory.SelectByText(categorydata);

            String str = selectCategory.SelectedOption.Text;
            //String str = selectCategory.SelectedOption.GetAttribute("value");

            return str;
        }

        

        public string SelectSubCategory(string subcategorydata)
        {
            
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("subcategoryId"), 5);
            //Select Subcategory
            var selectSubcategory = new SelectElement(Subcategory);
            selectSubcategory.SelectByText(subcategorydata);

            String str = selectSubcategory.SelectedOption.Text;

            return str;
        }

        #endregion

        #region Tags methods
        public string EnterTagName(string tagname)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"), 5);
            //Enter tag
            AddNewTag.Click();
            AddNewTag.SendKeys(tagname);
            AddNewTag.SendKeys(Keys.Return);

            string str = "";
            //Clear tags
            int countTags = displayedTagsText.Count();
            for (int i = 0; i < countTags; i++)
            {
                if (countTags > 0)
                {
                    if (displayedTagsText[i].Text.Contains(tagname))
                    {

                        string s = displayedTagsText[i].Text;
                        str = s.Remove(s.Length - 1);

                    }
                }

            }


            return str;
        }
        public string DeleteTagName(string tagname)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.XPath("(//form[@class='ui form']/div[4]/div[2]/div/div/div/span/a)[1]"), 5);

            string str = "";
            //Clear tags
            int countTags = displayedTags.Count();
            for (int i = 0; i < countTags; i++)
            {
                if (countTags > 0)
                {
                    if(displayedTagsText[i].Text.Contains(tagname))
                    {
                        displayedTags[i].Click();
  
                    }
                }
            }
   
            if (errorTag != null)
            {
                str = errorTag.Text;
            }

            return str;
        }

        #endregion

            
        #region Date methods
        public string EnterStartDate(string Startdateparam)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("startDate"), 5);
            //Enter Start date
            startDate.SendKeys(Startdateparam);
            string str = startDate.GetAttribute("value");
            return str;
        }
        public string EnterEndDate(string enddateparam)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("endDate"), 5);
            //Enter End date
            endDate.SendKeys(enddateparam);
            string str = endDate.GetAttribute("value");
            return str;
        }
        public string EditStartDate(string Startdateparam)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("startDate"), 5);
            //Clear title
            startDate.Click();
            startDate.Clear();
            //Enter Start date
            startDate.SendKeys(Startdateparam);
            
            
            string str = startDate.GetAttribute("value");
            
            return str;

        }

        public string EditEndDate(string Enddateparam)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("endDate"), 5);
            //Clear title
            endDate.Click();
            endDate.Clear();
            endDate.SendKeys(Enddateparam);
            string str = endDate.GetAttribute("value");
            return str;

        }

        public string DeleteStartDate(string startdateparam)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("startDate"), 5);
            //Clear title
            startDate.Click();
            startDate.Clear();
            string str = "";
            if(startDate != null)
                str= startDate.GetAttribute("value");

            return str;

        }

        public string DeleteEndDate(string enddateparam)
        {
            Driver.WaitForElementToBeClickable(Driver.driver, By.Name("endDate"), 5);
            //Clear title
            endDate.Click();
            endDate.Clear();
            string str = "";
            if (endDate != null)
                str = endDate.GetAttribute("value");

            return str;

        }

        #endregion


        //Filling Share-Skill details
        public void AddListing(int rowNumber, string worksheet)
        {
            //Initial a struct object and assign values
            Listing excelData = new Listing();
            GetExcel(rowNumber, worksheet, out excelData);

            Driver.ImplicitWaitMethod();
            //Enter Title 
            string title = excelData.title;
            Title.SendKeys(title);

            //Enter Description
            Desc.SendKeys(excelData.description);

            //Select category
            var selectCategory = new SelectElement(Category);
            selectCategory.SelectByText(excelData.category);

            //Select Subcategory
            var selectSubcategory = new SelectElement(Subcategory);
            selectSubcategory.SelectByText(excelData.subcategory);

            //Enter tag
            AddNewTag.Click();
            AddNewTag.SendKeys(excelData.tags);
            AddNewTag.SendKeys(Keys.Return);

            //Select Service type
            SelectServiceType(excelData.serviceType);

            //Select Location type
            SelectLocationType(excelData.locationType);

            //Enter Start date
            startDate.SendKeys(DateTime.Today.ToString("dd/MM/yyyy"));

            //Enter End date
            //endDate.SendKeys(excelData.endDate);
            endDate.SendKeys(DateTime.Today.ToString("dd/MM/yyyy"));

            //Enter Available days and hours
            EnterAvailableDaysAndHours((excelData.availableDays), (excelData.startTime), (excelData.endTime));

            //Select Skill Trade: "Credeit" or "Skill-exchange"
            SelectSkillTrade(excelData.skillTrade, excelData.skillExchange, excelData.credit);

            //Click button Upload Work Samples
            //UploadWorkSamples();

            //Click Active or Hidden
            ClickActiveOption(excelData.ActiveOption);


            //Click on Save
            Save.Click();

           
            
        }

        public void ClickSave()
        {
            
            //Click on Save
            Save.Click();
            
            
        }
        public void ClickCancel()
        {

            //Click on Save
            Cancel.Click();

        }
        public string GetMessage()
        {
            //Driver.WaitForElement(Driver.driver, By.XPath(e_message), 5);
            //return message.Text;
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

        public string GetMessageError()
        {

            string str = "";
            try
            {
                if (e_messageErr != null)
                {
                    str = e_messageErr.Text;
                }
                return str;
            }
            catch (Exception e)
            {
                return str;
            }

        }

        public string FileUploadStr()
        {

            string str = "";
            try
            {
                if (e_fileupload != null)
                {
                    str = e_fileupload.Text;
                }
                return str;
            }
            catch (Exception e)
            {
                return str;
            }

        }
        public bool FileUploadDel()
        {
            bool str = false;
            try
            {
                if (fileUploadDel != null)
                {
                    fileUploadDel.Click();
                    str = true;
                }
                return str;
            }
            catch (Exception e)
            {
                return str;
            }

        }
        




        #region Sub-methods for EnterShareSkill
        //Select Service type
        public bool SelectServiceType(string serviceTypeText)
        {
            bool selected = false;
            string elementValue = "0";
            if (serviceTypeText.Equals("One-off service"))
                elementValue = "1";

            for (int i = 0; i < serviceType.Count(); i++)
            {
                string actualElementValue = serviceType[i].GetAttribute("Value");
                if (elementValue.Equals(actualElementValue))
                    serviceType[i].Click();
                selected = true;
            }
            return selected;
            
        }
        

        //Select Location type
        public bool SelectLocationType(string locationTypeText)
        {
            bool selected = false;
            //Select Location type
            string elementValue = "0";
            if (locationTypeText.Equals("Online"))
                elementValue = "1";

            for (int i = 0; i < locationType.Count(); i++)
            {
                string actualElementValue = locationType[i].GetAttribute("Value");
                if (elementValue.Equals(actualElementValue))
                    locationType[i].Click();
                selected = true;
            }

            return selected;

        }

        //Enter Available days and hours
        public  void EnterAvailableDaysAndHours(string availableDaysText, string startTimeText, string endTimeText)
        {
            bool selected = false;
            //Enter available Days array = 
            string indexValue = "";

            switch (availableDaysText)
            {
                case "Sun":
                    indexValue = "0";
                    break;
                case "Mon":
                    indexValue = "1";
                    break;
                case "Tue":
                    indexValue = "2";
                    break;
                case "Wed":
                    indexValue = "3";
                    break;
                case "Thu":
                    indexValue = "4";
                    break;
                case "Fri":
                    indexValue = "5";
                    break;
                case "Sat":
                    indexValue = "6";
                    break;
                default:
                    Assert.Ignore("Day is invalid.");
                    break;
            }

            for (int i = 0; i < AvailableDays.Count; i++)
            {
                if (indexValue.Equals(AvailableDays[i].GetAttribute("index")))
                {
                    AvailableDays[i].Click();
                    StartTime[i].SendKeys(startTimeText);
                    EndTime[i].SendKeys(endTimeText);
                    selected = true;
                    Assert.True(AvailableDays[i].Selected);
                }
               
                
            }
            if(!selected)
                Assert.Fail("Failed to select available days");



        }

        public void EditOrDeleteAvailableDaysAndHours(string availableDaysText, string startTimeText, string endTimeText, bool delete)
        {
            bool selected = false;

            for (int i = 0; i < AvailableDays.Count; i++)
            {
                if(AvailableDays[i].Selected)
                {
                    AvailableDays[i].Click();
                    StartTime[i].Clear();

                    EndTime[i].Clear();

                }
                
            }
            if(!delete)
            EnterAvailableDaysAndHours(availableDaysText, startTimeText, endTimeText);

        }

        //Select Skill trade
        public bool SelectSkillTrade(string skillTradeText, string skillExchangeText, string creditText)
        {
            bool selected = false;
            //Select "Skill Trade" options
            string elementValue = "true";

            if (skillTradeText.Equals("Credit"))
                elementValue = "false";

            for (int i = 0; i < skillTrades.Count(); i++)
            {
                string actualElementValue = skillTrades[i].GetAttribute("value");
                if (elementValue.Equals(actualElementValue))
                {
                    //Select "Skill exchange" or "Credit"
                    skillTrades[i].Click();
                    Driver.ImplicitWaitMethod();

                    if (skillTradeText.Equals("Skill-exchange"))
                    {
                        //Enter tags for Skill-exchange
                        SkillExchangeTag.Click();
                        SkillExchangeTag.SendKeys(skillExchangeText);
                        SkillExchangeTag.SendKeys(Keys.Return);
                        selected = true;
                    }
                    else
                    {
                        //Enter Credit amount
                        charge.SendKeys(creditText);
                        selected = true;
                    }
                }
            }
            return selected;
        }

        public bool ClearSkillTrade()
        {
            bool selected = false;
            

            //Clear skill trade
            for (int i = 0; i < skillTrades.Count; i++)
            {
                string value = skillTrades[i].GetAttribute("Value");
                bool state = skillTrades[i].Selected;

                //Clear skill trade tags
                if (value.Equals("true") & state.Equals(true))
                {
                    for (int j = 0; j < skillTrades.Count; j++)
                    {
                        skillTrades[j].Click();
                        selected = true;
                    }

                }
                //Clear credit amount
                else if (value.Equals("false") & state.Equals(true))
                {
                    charge.Click();
                    charge.Clear();
                    selected = true;
                }
            }
            return selected;
        }
        

        //Click Active or Hidden
        public bool ClickActiveOption(string ActiveOptionText)
        {
            bool selected = false;
            string elementValue = "true";
            if (ActiveOptionText.Equals("Hidden"))
                elementValue = "false";

            for (int i = 0; i < Active.Count(); i++)
            {
                string actualElementValue = Active[i].GetAttribute("Value");
                if (elementValue.Equals(actualElementValue))
                    Active[i].Click();
                selected = true;
            }
            return selected;
        }

        public string GetSkillTrade(string skillTradeOption)
        {
            if (skillTradeOption == "Credit")
                return actualSkillsTrade.Text;
            else
                return actualSkillExchange.Text;
        }
        #endregion

        //sub-method for Edit
        public void ClearData()
        {
            //Clear title
            Title.Click();
            Title.SendKeys(Keys.Control + "A");
            Title.SendKeys(Keys.Delete);


            //Clear description
            Desc.Click();
            Desc.SendKeys(Keys.Control + "A");
            Desc.SendKeys(Keys.Delete);
            
            //Clear Category

            //Clear tags
            int countTags = displayedTags.Count();
            for (int i = 0; i < countTags; i++)
            {
                if (countTags > 0)
                    //displayedTags[i].Click();
                    displayedTags[0].Click();
            }

            //Clear days
            for (int i = 0; i < AvailableDays.Count; i++)
            {
                bool dayState = AvailableDays[i].Selected;
                if (dayState.Equals(true))
                {
                    //Unselected day
                    AvailableDays[i].Click();

                    //Clear StartTime
                    StartTime[i].SendKeys(Keys.Delete);
                    StartTime[i].SendKeys(Keys.Tab);
                    StartTime[i].SendKeys(Keys.Delete);
                    StartTime[i].SendKeys(Keys.Tab);
                    StartTime[i].SendKeys(Keys.Delete);

                    //Clear Entime
                    EndTime[i].SendKeys(Keys.Delete);
                    EndTime[i].SendKeys(Keys.Tab);
                    EndTime[i].SendKeys(Keys.Delete);
                    EndTime[i].SendKeys(Keys.Tab);
                    EndTime[i].SendKeys(Keys.Delete);
                }
            }
            Driver.ImplicitWaitMethod();

            //Clear skill trade
            for (int i = 0; i < skillTrades.Count; i++)
            {
                string value = skillTrades[i].GetAttribute("Value");
                bool state = skillTrades[i].Selected;

                //Clear skill trade tags
                if (value.Equals("true") & state.Equals(true))
                {
                    for (int j = 0; j < skillTrades.Count; j++)
                    {
                        skillTrades[j].Click();
                    }
                }
                //Clear credit amount
                else if (value.Equals("false") & state.Equals(true))
                {
                    charge.Click();
                    charge.Clear();
                }
            }

        }

        //Upload Work samples
        public void UploadWorkSamples()
        {
            
            Driver.ImplicitWaitMethod();
            btnWorkSamples.Click();

            //Run AutoIT-script to execute file uploading
            using (Process exeProcess = Process.Start(Base.AutoScriptPath))
            {
                exeProcess.WaitForExit();
            }
        }

        public struct Listing
        {
            public string title;
            public string description;
            public string category;
            public string subcategory;
            public string startDate;
            public string endDate;
            public string serviceType;
            public string locationType;
            public string skillTrade;
            public string skillExchange;
            public string tags;
            public string availableDays;
            public string startTime;
            public string endTime;
            public string credit;
            public string ActiveOption;
            public string isClickSaveFirst;
        }
        public void GetExcel(int rowNumber, string worksheet, out Listing excelData)
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, worksheet);

            excelData.title = ExcelLib.ReadData(rowNumber, "Title");
            excelData.description = ExcelLib.ReadData(rowNumber, "Description");
            excelData.category = ExcelLib.ReadData(rowNumber, "Category");
            excelData.subcategory = ExcelLib.ReadData(rowNumber, "Subcategory");
            excelData.startDate = ExcelLib.ReadData(rowNumber, "StartDate");
            excelData.endDate = ExcelLib.ReadData(rowNumber, "EndDate");
            excelData.serviceType = ExcelLib.ReadData(rowNumber, "ServiceType");
            excelData.locationType = ExcelLib.ReadData(rowNumber, "LocationType");
            excelData.skillTrade = ExcelLib.ReadData(rowNumber, "SkillTradeOption");
            excelData.skillExchange = ExcelLib.ReadData(rowNumber, "SkillExchange");
            excelData.tags = ExcelLib.ReadData(rowNumber, "Tags");
            excelData.availableDays = ExcelLib.ReadData(rowNumber, "Days");
            excelData.startTime = ExcelLib.ReadData(rowNumber, "StartTime");
            excelData.endTime = ExcelLib.ReadData(rowNumber, "EndTime");
            excelData.credit = ExcelLib.ReadData(rowNumber, "CreditAmount");
            excelData.ActiveOption = ExcelLib.ReadData(rowNumber, "ActiveOption");
            excelData.isClickSaveFirst = ExcelLib.ReadData(rowNumber, "isClickSaveFirst");

        }

        public void GetWeb(out Listing webData)
        {
            webData.title = actualTitle.Text;
            webData.description = actualDescription.Text;
            webData.category = actualCategory.Text;
            webData.subcategory = actualSubcategory.Text;
            webData.startDate = actualStartDate.Text;
            webData.endDate = actualEndDate.Text;
            webData.serviceType = actualServiceType.Text;
            webData.locationType = actualLocationType.Text;

            webData.skillTrade = "dummy";
            webData.skillExchange = "dummy";
            webData.tags = "dummy";
            webData.availableDays = "dummy";
            webData.startTime = "dummy";
            webData.endTime = "dummy";
            webData.credit = "dummy";
            webData.ActiveOption = "dummy";
            webData.isClickSaveFirst = "dummy";
        }


    }
}
