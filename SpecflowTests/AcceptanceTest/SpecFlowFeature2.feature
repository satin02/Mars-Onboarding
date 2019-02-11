Feature: SpecFlowFeature2
	In order to update my profile
	As a skill trader
	I want to add details to my profile

@mytag
Scenario: Check if user is able to add a skill
	Given I clicked on the skill tab under profile page
	When I add a new skill
	Then that skill should be added on my listing

Scenario: Check if user is able to edit a skill
    Given I clicked on the skill tab under Profile page
	And I click on edit button
	When I make changes to one or more fields
	Then changes should be displayed on my listings

Scenario: Check if user is able to delete a skill
	Given I clicked on the skill tab under Profile page
	When I click delete button
	Then that language should be deleted 

Scenario: Check if user is able to add education
	Given I clicked on the education tab under Profile page
	When I add a new education
	Then that education should be displayed on my listings

Scenario: Check if user is able to edit education
	Given I clicked on the education tab under Profile page
    And I click on edit button
	When I change one or more fields
	Then changes should be displayed on my listings

Scenario: Check if user is able to delete education 
	Given I clicked on the education tab under Profile page
	When I delete education
	Then that education should not be displayed on my listings

Scenario: Check if user is able to add certifications
	Given I clicked on the certifications tab under Profile page
	When I add a new certification
	Then that certification should be displayed on my listings

Scenario: Check if user is able to edit certifications
	Given I clicked on the certifications tab under Profile page
    And I click on edit button
	When I change one or more fields
	Then changes should be displayed on my listings

Scenario: Check if user is able to delete certification
	Given I clicked on the certification tab under Profile page
	When I delete certification
	Then that certification should not be displayed on my listings

Scenario: Check if user is able to add profile picture
    Given I click on Profile page
	When  I upload profle picture
	Then  picture should be displayed on my Profile Page

Scenario: Check if user is able to add description 
    Given I clicked on the edit description under the Profile page
	When I add description and click on save button
	Then descripton should be displayed on my profile

Scenario: Check if user is able to add location
    Given I click on location under Profile Page
	When I enter the country and city name
	Then location is displayed on my profile

Scenario: Check if user is able to add availability
    Given I click on the edit availability under Profile page
	When I choose my availability
	Then my availability should be displayed on my profile

Scenario: Check if user is able to add hours 
    Given I click on edit hours under Profile page
	When I choose my hours
	Then my hours should be displayed on my profile

Scenario: Check if user is able to add earn target
    Given I click on edit earn target under Profile Page
	When I choose my earn target
	Then my earn target should be displayed on my profile






