Feature: LoginFeature
	I want to login to page

@mytag
Scenario Outline: LoginFeature01_LoginToPageWithValidCretendials
	Given I login to website using 'Admin' credentials
    #Then I check if home page load properly
Examples: 
    | Id  |
    | 178 |

Scenario Outline: LoginFeature02_LoginToPageWithInvalidCredentials
    Given Set PageName to 'Login'
    When I enter '' value to 'Login' input
    #And I enter '' value to 'Password' input
    #And I click 'submit' button
    #Then I wait '10' seconds until error message with '' value appear
    #When I enter 'Invalid' value to 'Login' input
    #And I enter 'Invalid' value to 'Passowrd' input
    #Then I wait '10' seconds until error message with '' value appear
Examples: 
    | Id  |
    | 179 |

#Scenario Outline: LoginFeature03_LoginToPageWithToLargeInputLength
#    Given I enter to 'LoginPage'
#    When I enter '' value to 'Login' input
#    And I enter '' value to 'Password' input
#    And I click 'submit' button
#    Then I wait '10' seconds until error message with '' value appear
#    When I enter 'Invalid' value to 'Login' input
#    And I enter 'Invalid' value to 'Passowrd' input
#    Then I wait '10' seconds until error message with '' value appear
#Examples: 
#    | Id  |
#    | 178 |