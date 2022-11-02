using MarsQA_1.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using static MarsQA_1.Global.GlobalDefinitions;
using MarsQA_1.Global;

namespace MarsQA_1.Pages
{
    public static class Signin
    {
        private static IWebElement SignInbtn => Driver.driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']"));
        private static IWebElement emailTxtBox => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        private static IWebElement PasswordTxtBox => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        private static IWebElement LoginBtn => Driver.driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));
        
        public static void SignIn()
        {
            Driver.NavigateURL();
            LoginSteps();
            //SignInbtn.Click();
            //emailTxtBox.SendKeys(ConstantHelpers.username);
            //PasswordTxtBox.SendKeys(ConstantHelpers.password);
            //LoginBtn.Click();
        }

        public static void LoginSteps()
        {
            //Populate excel data
            ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            //Click on Signin button
            SignInbtn.Click();

            //Enter email
            emailTxtBox.SendKeys(ExcelLib.ReadData(2, "Username"));

            //Enter password
            PasswordTxtBox.SendKeys(ExcelLib.ReadData(2, "Password"));

            //Click Login button
            LoginBtn.Click();
            

        }


    }
}
