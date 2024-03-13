using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProject1.Utilities;


namespace SpecFlowProject1.Pages
{
    public class TimeAndMaterialPage
    {
        public void CreateTimeandMaterial(IWebDriver driver, string code, string description)
        {
            //create new Time and material entry
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            IWebElement selectTimeOptionDropdown = driver.FindElement(By.XPath("//span[contains(text(),'select')]"));
            selectTimeOptionDropdown.Click();
            Thread.Sleep(1000);

            IWebElement selectTimeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            selectTimeOption.Click();

            WaitUtils.WaitToBeVisible(driver, "Id", "Code", 2);
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys(code);

            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys(description);

            WaitUtils.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]", 2);

            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("50");

            // save new time and material entry
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(1000);         

        }

        public void CheckTimeRecordSavedorNot(IWebDriver driver)
        {
            IWebElement pageArrowButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            pageArrowButton.Click();

            IWebElement newRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            Thread.Sleep(2000);
            Assert.That((newRecordDescription.Text == "Specflow 3"), "New Time/ Material Record is not created");
        }
        public void editTimeAndMaterial(IWebDriver driver)

        {
            //Go to the last page
            IWebElement pageArrowButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            pageArrowButton.Click();

            // Click on edit button
            WaitUtils.WaitToBeVisible(driver, "XPath", "//tbody/tr[last()]/td[5]/a[1]", 2);
            IWebElement editButton = driver.FindElement(By.XPath("//tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Edit Code in Code Textbox
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("Turn up edited");

            //Edit Description in Description Textbox
            IWebElement editDescriptionTextBox = driver.FindElement(By.Id("Description"));
            editDescriptionTextBox.Clear();
            editDescriptionTextBox.SendKeys("Description Edited");

           Thread.Sleep(1000);

            //Edit Price in Price Textbox
            IWebElement editPriceOverlappingTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editPriceTextBox = driver.FindElement(By.Id("Price"));
            editPriceOverlappingTag.Click();
            editPriceTextBox.Clear();
            editPriceOverlappingTag.Click();
            editPriceTextBox.SendKeys("5000");

            //Click on save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
               

        }

        public void editTimeRecordAssert(IWebDriver driver)
        {
            // Click on goToLastPage Button
            Thread.Sleep(2000);
            IWebElement editGoToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            editGoToLastPageButton.Click();

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


            Thread.Sleep(2000);
            
            Assert.That((editedCode.Text == "Turn up edited"), "Time and material record is not updated");
        }

        public void deleteTimeAndMaterial(IWebDriver driver)
        {
            Thread.Sleep(2000);
            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 3);
            IWebElement editGoToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            editGoToLastPageButton.Click();

            IWebElement deleteRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteRecord.Click();

            IAlert simpleAlert = driver.SwitchTo().Alert();
            simpleAlert.Accept();
            Thread.Sleep(2000);

            
        }
        public void deleteRecordAssert(IWebDriver driver)
        {
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(1000);
            IWebElement lastCodeInTable = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That((lastCodeInTable.Text != "Turn up edited"), "Time Record has not been deleted");
        }

    }
}
