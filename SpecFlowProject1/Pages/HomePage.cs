using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class HomePage
    {
       /* public void NavigateToCustomerPage(IWebDriver driver)
        {
            // Navigate to Time and material modeule
            IWebElement administartionDrpdown = driver.FindElement(By.XPath("//a[text()='Administration ']"));
            administartionDrpdown.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement customerOption = driver.FindElement(By.XPath("//a[text()='Customers']"));
            customerOption.Click();
            Console.WriteLine("User is on customer page");

        }*/

        public void NavigateToTMPage(IWebDriver driver)
        {
            // Navigate to Time and material modeule
            IWebElement administartionDrpdown = driver.FindElement(By.XPath("//a[text()='Administration ']"));
            administartionDrpdown.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]"));
            timeAndMaterialOption.Click();

        }
       public void VerifyLoggedInUser(IWebDriver driver)
        {
            //checking user is successfully logged in or not
            IWebElement loggedInUser = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            
            Thread.Sleep(1000);

            if (loggedInUser.Text == "Hello hari!")
            {
                Console.WriteLine("User Logged in Successfully");
            }
            else
            {
                Console.WriteLine("User is not logged in successfully");
            }

        }
    }
}

            
    

