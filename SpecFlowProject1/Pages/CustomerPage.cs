using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class CustomerPage : HomePage
    {
        public void CreateNewCustomer(IWebDriver driver)
        {
            //create new customer record
            IWebElement creatNewCutomerButton = driver.FindElement(By.XPath("//a[contains(text(),'Create New')]"));
            creatNewCutomerButton.Click();

            
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.SendKeys("Sophie");

            //Edit Contact 
            IWebElement editContactButton = driver.FindElement(By.Id("EditContactButton"));
           editContactButton.Click();

            driver.SwitchTo().Frame(0);
            

            IWebElement enterFirstNameTextbox = driver.FindElement(By.Id("FirstName"));
            enterFirstNameTextbox.SendKeys("Sophie");
            IWebElement enterLastNameTextbox = driver.FindElement(By.Id("LastName"));
            enterLastNameTextbox.SendKeys("Turner");
            IWebElement enterPreferedNameTextbox = driver.FindElement(By.Id("PreferedName"));
            enterPreferedNameTextbox.SendKeys("Sophie");
            IWebElement enterPhoneTextbox = driver.FindElement(By.Id("Phone"));
            enterPhoneTextbox.SendKeys("045000000");
            IWebElement enterMobileTextbox = driver.FindElement(By.Id("Mobile"));
            enterMobileTextbox.SendKeys("05676788");

            IWebElement enterEmailTextbox = driver.FindElement(By.Id("email"));
            enterEmailTextbox.SendKeys("sophie@gmail.com");

            IWebElement enterFaxTextbox = driver.FindElement(By.Id("Fax"));
            enterFaxTextbox.SendKeys("1234567");

            /*IWebElement editAddressTextbox = driver.FindElement(By.XPath("//input[@placeholder='Enter your address']"));
            editAddressTextbox.SendKeys("M");
            driver.SwitchTo().Frame(1);
            driver.FindElement(By.XPath("//button[contains(text(),'OK')]")).Click();
            //IAlert simpleAlert = driver.SwitchTo().Alert();
             editAddressTextbox.SendKeys("Melbourne");*/



            IWebElement enterStreetTextbox = driver.FindElement(By.Id("Street"));
            enterStreetTextbox.SendKeys("Station street");

            IWebElement enterCityTextbox = driver.FindElement(By.Id("City"));
            enterCityTextbox.SendKeys("Melbourne");

            IWebElement enterPostCodeTextbox = driver.FindElement(By.Id("Postcode"));
            enterPostCodeTextbox.SendKeys("3130");

            IWebElement enterCountryTextbox = driver.FindElement(By.Id("Country"));
            enterCountryTextbox.SendKeys("Austarlia");

            IWebElement saveContactButton = driver.FindElement(By.XPath("//input[@value='Save Contact']"));
            saveContactButton.Click();

            // Edit billing contact
            //WaitUtils.WaitToBeVisible(driver, "XPath", "//input[@type='checkbox']", 2);
            driver.SwitchTo().DefaultContent();
            IWebElement sameAsAboveCheckbox = driver.FindElement(By.Id("IsSameContact"));
            
            sameAsAboveCheckbox.Click();

            // Add GST record

            IWebElement gstTextbox = driver.FindElement(By.Id("GST"));
            gstTextbox.SendKeys("12");

            //save customer record

            IWebElement saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
            saveButton.Click();

            // Checking Customer Record is saved or not
            
            Thread.Sleep(3000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

           
            IWebElement findLastRecord = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[last()]/td[2]"));
            
            Assert.That((findLastRecord.Text == "Sophie"), "The Customer record is not been created.");
               
           
        }

        public void editCustomer(IWebDriver driver)
        {

            //go to last page
            IWebElement goToLastpageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            goToLastpageButton.Click();
            Thread.Sleep(2000);

            IWebElement clickOnEditButton = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[last()]/td[4]/a[1]"));
            clickOnEditButton.Click();
            driver.SwitchTo().Frame(0);

            IWebElement editNameTextbox = driver.FindElement(By.Id("Name"));
            editNameTextbox.SendKeys("Sophie edited");

            /*IWebElement editContactButton = driver.FindElement(By.Id("EditContactButton"));
            editContactButton.Click();

            driver.SwitchTo().Frame(0);
            //edit contact details
            IWebElement editFirstNameTextbox = driver.FindElement(By.XPath("//input[@id='FirstName']"));
            editFirstNameTextbox.Clear();
            editFirstNameTextbox.SendKeys("Sophie edited");

            IWebElement editLastNameTextbox = driver.FindElement(By.Id("LastName"));
            editLastNameTextbox.Clear();
            editLastNameTextbox.SendKeys("Turner edited");

            IWebElement editPreferedNameTextbox = driver.FindElement(By.Id("PreferedName"));
            editPreferedNameTextbox.Clear();
            editPreferedNameTextbox.SendKeys("Sophie edited");

            IWebElement editPhoneTextbox = driver.FindElement(By.Id("Phone"));
            editPhoneTextbox.Clear();
            editPhoneTextbox.SendKeys("045111111");

            IWebElement editMobileTextbox = driver.FindElement(By.Id("Mobile"));
            editMobileTextbox.SendKeys("067678867");

            IWebElement editEmailTextbox = driver.FindElement(By.Id("email"));
            editEmailTextbox.Clear();
            editEmailTextbox.SendKeys("sophie1@gmail.com");

            IWebElement editFaxTextbox = driver.FindElement(By.Id("Fax"));
            editFaxTextbox.Clear();
            editFaxTextbox.SendKeys("4567890");

            IWebElement editStreetTextbox = driver.FindElement(By.Id("Street"));
            editStreetTextbox.Clear();
            editStreetTextbox.SendKeys("Artur street");

            IWebElement editCityTextbox = driver.FindElement(By.Id("City"));
            editCityTextbox.Clear();
            editCityTextbox.SendKeys("Melbourne");

            IWebElement editPostCodeTextbox = driver.FindElement(By.Id("Postcode"));
            editPostCodeTextbox.SendKeys("3130");

            IWebElement editCountryTextbox = driver.FindElement(By.Id("Country"));
            editCountryTextbox.Clear();
            editCountryTextbox.SendKeys("Austarlia");

            IWebElement saveContactButton = driver.FindElement(By.XPath("//input[@id=\"submitButton\"]"));
            saveContactButton.Click();
            
          *//*Thread.Sleep(2000);
            IWebElement editGstTextbox = driver.FindElement(By.XPath("//input[@id='GST']"));
            editGstTextbox.SendKeys("45");*/

            IWebElement saveButton = driver.FindElement(By.Id("submitButton"));
            saveButton.Click();

            driver.Navigate().Refresh();
            driver.SwitchTo().DefaultContent();

            IWebElement goToLastpageButtonafterRefresh = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            goToLastpageButtonafterRefresh.Click();
            Thread.Sleep(2000);
            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[last()]/td[2]"));

           // Assert.That((findEditedRecord.Text == "Sophie edited"), "Record is not being saved successfully.");
        }
    }
}
