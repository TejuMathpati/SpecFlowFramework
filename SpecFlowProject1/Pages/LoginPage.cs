using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V120.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class LoginPage
    { 
        public void LoginActions(IWebDriver driver, string username, string password)

        {
            // Open turn up portal
            driver.Manage().Window.Maximize();
            string baseUrl= "http://horse.industryconnect.io/";
            driver.Navigate().GoToUrl(baseUrl);

            //Enter valid user name and password
            IWebElement userNameTextbox = driver.FindElement(By.Id("UserName"));
            userNameTextbox.SendKeys(username);
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys(password);
            IWebElement logInButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            logInButton.Click();
        }
    }
}
