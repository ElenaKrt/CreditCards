using UIFramework;

namespace CreditCardsPages
{
    public class LandingPage:BasePage
    {
        #region Variables
        public Domain.DomElement _cardCategoryMenu = new Domain.DomElement(Domain.DomElementType.XPath,
            "//*[text()='Card category']");

        public Domain.DomElement _cardIssuerMenu = new Domain.DomElement(Domain.DomElementType.XPath,
            "//*[text()='Card issuer']");

        public Domain.DomElement _bestCreditCardIcon = new Domain.DomElement(Domain.DomElementType.XPath,
            "//*[text()='Best Credit Cards']");

        public Domain.DomElement _americanExpressIcon = new Domain.DomElement(Domain.DomElementType.XPath,
            "//*[text()='American Express']");

        public Domain.DomElement _menuBar = new Domain.DomElement(Domain.DomElementType.ClassName,
            "boxy__menu");

        public Domain.DomElement _viewDetailsButton = new Domain.DomElement(Domain.DomElementType.ClassName,
            "home-page-issuer__button");



        #endregion Variables

        public LandingPage()
        {
            if (Driver == null)
            {
                StartBrowser();
            }
            GoToUrl(BrowserUrl);
            WaitForWindowsToLoad();
        }

        public void HooverOverMenu(string icon)
        {
            if(icon=="Card Category")
                HooverOver(_cardCategoryMenu);
            else if (icon=="Card Issuer")
                HooverOver(_cardIssuerMenu);
        }

        public bool GetIcon(string icon)
        {
            if (icon == "Best Credit Cards")
                return Find(_bestCreditCardIcon) != null;
            if (icon == "American Express")
                return Find(_americanExpressIcon) != null;
            return false;
        }


        public bool IsMenuBarVisible()
        {
            var result = Find(_menuBar);
            return result != null;
        }

        public bool ClickOnViewDetailsButton()
        {
            var element = Find(_viewDetailsButton);
            return Click(element);
        }

    }
}
