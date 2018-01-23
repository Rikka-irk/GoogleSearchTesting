Feature: GoogleSearch
Scenario: Verify the search Functionality of Google Search page
	Given I navigate to the page "www.google.com"
	When  I see the page is loaded
	When I enter Search Keyword in the Search Text box
	| Keyword  |
	| SpecFlow |
	And I click on Search Button
	Then Search items shows the items related to SpecFlow