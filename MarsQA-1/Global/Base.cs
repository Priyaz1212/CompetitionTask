using MarsQA_1.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsQA_1.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using MarsQA_1.Pages;
using static MarsQA_1.Global.GlobalDefinitions;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework.Interfaces;


namespace MarsQA_1.Global
{
    public class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string AutoScriptPath = MarsResource.AutoScriptPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        #endregion
        
        #region reports
        public static AventStack.ExtentReports.ExtentReports extent;
        public static AventStack.ExtentReports.ExtentTest test;
        #endregion


        #region setup and tear down
        [OneTimeSetUp]
        protected void ExtentStart()
        {
            //Initialize report
            string reportName = ReportPath
            + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("_dd-MM-yyyy_HHmm")
            + Path.DirectorySeparatorChar;

            //start reporters
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportName);
            extent = new AventStack.ExtentReports.ExtentReports();

            extent.AttachReporter(htmlReporter);


        }
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {

            switch (Browser)
            {

                case 1:
                    Driver.driver = new FirefoxDriver();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;

            }

            #region Initialise Reports






            #endregion

            if (MarsResource.IsLogin == "true")
            {

                Signin.SignIn();
            }
            else
            {
                //SignUp obj = new SignUp();
                //obj.register();
            }

        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
 

            var exec_status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            string TC_Name = TestContext.CurrentContext.Test.Name;
            string base64 = SaveScreenShotClass.GetScreenshot(Driver.driver);

            Status logStatus = Status.Pass;
            switch (exec_status)
            {
                case TestStatus.Failed:

                    logStatus = Status.Fail;
                    test.Log(Status.Fail, exec_status + errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;

                case TestStatus.Skipped:

                    logStatus = Status.Skip;
                    test.Log(Status.Skip, errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;

                case TestStatus.Inconclusive:

                    logStatus = Status.Warning;
                    test.Log(Status.Warning, "Test ");
                    break;

                case TestStatus.Passed:

                    logStatus = Status.Pass;
                    test.Log(Status.Pass, "Test Passed");
                    break;

                default:
                    break;
            }



            
            // Close the driver :)          
            Driver.driver.Close();
            Driver.driver.Quit();
        }
        #endregion

        [OneTimeTearDown]
        protected void ExtentClose()
        {
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
        }
        
    }
}
