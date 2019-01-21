@TestingBasicFunctionalitiesOfCreditCardsLandingPage
Feature: TestingBasicFunctionalitiesOfCreditCardsLandingPage

@test1
Scenario: BestCreditCardIconTest
	Given I am a consumer and I navigated to the landing page of the credit cards web site
	When I hover over "Card Category" menu
	Then I should see a "Best Credit Cards" icon displayed correctly

@Test2
Scenario: AmericanExpressIconTest
	Given I am a consumer and I navigated to the landing page of the credit cards web site
	When I hover over "Card Issuer" menu
	Then I should see a "American Express" icon displayed correctly

@Test3
Scenario: CheckMenuBarStaysVisible
	Given I am a consumer and I navigated to the landing page of the credit cards web site
	When I scroll down on the page
	Then the menu bar stays visible all the time

@Test4
Scenario: RedirectTobankOfAmericaCashRewardsCreditCardSiteTest
	Given I am a consumer and I navigated to the landing page of the credit cards web site
	When I click on View details button
    Then I will be redirected to bank-of-america-cash-rewards-credit-card site

