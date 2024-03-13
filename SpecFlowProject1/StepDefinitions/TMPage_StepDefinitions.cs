using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Pages;
using SpecFlowProject1.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowProject1
{
    [Binding]
    public class TMPage_StepDefinitions : CommonDriver
    {
        LoginPage loginPage = new LoginPage();
        HomePage homePage = new HomePage();
        TimeAndMaterialPage timeAndMaterialPage = new TimeAndMaterialPage();

        [BeforeScenario]
        public void TM_SetUp()
        {
            driver = new ChromeDriver();
        }
        [AfterScenario]
        public void TM_TearDown() 
        {
            driver.Quit();
        }

      
      
        [Given(@"User is able to login into the turn up portal '([^']*)' '([^']*)'")]
        public void GivenUserIsAbleToLoginIntoTheTurnUpPortal(string username, string password)
        {
            loginPage.LoginActions(driver, username, password);
        }
        [When(@"User navigates to TM page")]
        public void WhenUserNavigatesToTMPage()
        {
            homePage.NavigateToTMPage(driver);
            homePage.VerifyLoggedInUser(driver);
        }
       
        

        [When(@"User create new Time record '([^']*)' '([^']*)' (.*)")]
        public void WhenUserCreateNewTimeRecord(string code, string description, string price)
        {
            timeAndMaterialPage.CreateTimeandMaterial(driver, code, description);
        }


        [Then(@"The new Time record get saved successfully\.")]
        public void ThenTheNewTimeRecordGetSavedSuccessfully_()
        {
            
            timeAndMaterialPage.CheckTimeRecordSavedorNot(driver);
          
        }

        [When(@"User edits new Time record")]
        public void WhenUserEditsNewTimeRecord()
        {
            timeAndMaterialPage.editTimeAndMaterial(driver);
        }

        [Then(@"The edited Time record get saved successfully\.")]
        public void ThenTheEditedTimeRecordGetSavedSuccessfully_()
        {
            timeAndMaterialPage.editTimeRecordAssert(driver);
        }

        [When(@"User delete the Time record")]
        public void WhenUserDeleteTheTimeRecord()
        {
            timeAndMaterialPage.deleteTimeAndMaterial(driver);
        }

        [Then(@"The Time record gets deleted successfully\.")]
        public void ThenTheTimeRecordGetsDeletedSuccessfully_()
        {
            timeAndMaterialPage.deleteRecordAssert(driver);
        }

    }
}
