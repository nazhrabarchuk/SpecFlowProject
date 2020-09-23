Feature: NewsPageSteps

 Background: 
	Given the BBC Home page is open
	And I go to News

@smoke
 Scenario: Navigate to the copied link
	 When click on Entertainment & Arts tab
	 And click the first article
	 And click Share
	 And copy the link
	 And navigate the link
	 Then the same article is open

@smoke
 Scenario: Send the coronovirus story
	 When click on Coronavirus tab
	 And click on Your Coronavirus Stories tab
	 And go to “How to share with BBC news”
	 And fill in the information on the bottom
	 | Story       | Name | EmailAddress   | ContactNumber | Location                                |
	 | Lorem ipsum |      | test@test.test | 11111         | 4 Privet Drive, Little Whinging, Surrey |
	 And click Submit
	 Then the story is not sent