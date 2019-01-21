using CreditCardsPages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UIFramework;

namespace CreditCards
{
    [Binding]
    public class TestingBasicFunctionalitiesOfCreditCardsLandingPageSteps 
    {
        LandingPage LandingPage ;

        [Given(@"I am a consumer and I navigated to the landing page of the credit cards web site")]
        public void GivenIAmAConsumerAndINavigatedToTheLandingPageOfTheCreditCardsWebSite()
        {
            LandingPage = new LandingPage();    
        }

        [When(@"I hover over ""(.*)"" menu")]
        public void WhenIHoverOverMenu(string menu)
        {
            LandingPage.HooverOverMenu(menu);
        }
      
        [Then(@"I should see a ""(.*)"" icon displayed correctly")]
        public void ThenIShouldSeeAIconDisplayedCorrectly(string icon)
        {
            var res = LandingPage.GetIcon(icon);
            Assert.True(res);
        }

        [When(@"I scroll down on the page")]
        public void WhenIScrollDownOnThePage()
        {
            LandingPage.ScrollDown();
        }

        [Then(@"the menu bar stays visible all the time")]
        public void ThenTheMenuBarStaysAvailableAllTheTime()
        {
            Assert.IsTrue(LandingPage.IsMenuBarVisible());
        }

        [When(@"I click on View details button")]
        public void WhenIClickOnViewDetailsButton()
        {
            LandingPage.ClickOnViewDetailsButton();
        }

        [Then(@"I will be redirected to bank-of-america-cash-rewards-credit-card site")]
        public void ThenIWillBeRedirectedToBank_Of_America_Cash_Rewards_Credit_CardSite()
        {
            var res = new BasePage().GetPageUrl("bank-of-america-cash-rewards-credit-card");
            Assert.IsTrue(res);
        }
        
        [AfterScenario()]
        public static void AfterScenario()
        {
          DriverHandler.CloseBrowser();
        }
    }
}

