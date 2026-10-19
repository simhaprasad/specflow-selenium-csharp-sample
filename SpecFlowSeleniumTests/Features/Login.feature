Feature: Login
  As a user
  I want to login to the demo site
  So that I can access the secure area

  Scenario: Successful login
    Given I navigate to the demo login page
    When I enter valid credentials
    Then I should see the secure area
