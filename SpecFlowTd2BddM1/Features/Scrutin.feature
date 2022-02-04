Feature: Scrutin
	api for result of scrutin majoritaire

Scenario: Show number of votes 
	Given The state of the ballot is <etatscrutin> 
	When the number of votes is displayed
	Then the result should be <result>
	Examples:
	  | etatscrutin | result                                            |
	  | true        | Nombre de vote: ROSSAT : 150,Mars : 112,Rue : 38, |
	  | false       | Le scrutin n'est pas cloturé                      |
   
Scenario: Show vote percentage
	Given The state of the ballot is <etatscrutin> 
	And The total number of votes of ballots is <totalvote>
	When the vote percentage is displayed 
	Then the result should be <result>
Examples:
  | etatscrutin | totalvote | result                                               |
  | true        | 300       | Pourcentage de vote: ROSSAT : 50,Mars : 37,Rue : 12, |
  | false       | 300       | Le scrutin n'est pas cloturé                         |
	
@mytag
Scenario: Obtain winner
	Given The total number of votes of ballots is <totalvote>
	And The number of votes for the first candidate is <votecandidat1>
	And The number of votes for the second candidate is <votecandidat2>
	And The number of votes for the third candidate is <votecandidat3>
	And The number of ballots is <nombretour>
	And The state of the ballot is <etatscrutin> 
	When the winner is obtained 
	Then the result should be <result>
	Examples: 
	  | totalvote | votecandidat1 | votecandidat2 | votecandidat3 | nombretour | etatscrutin | result                                                            |
	  | 200       | 101           | 50            | 49            | 1          | true        | ROSSAT                                                            |
	  | 200       | 10            | 10            | 180           | 1          | true        | Rue                                                               |
	  | 300       | 120           | 75            | 105           | 1          | false       | Le scrutin n'est pas cloturé                                      |
	  | 300       | 120           | 75            | 105           | 1          | true        | Refaire un tour de scrutin avec ces deux candidat : ROSSAT et Rue |
	  | 300       | 150           | 150           | 0             | 2          | true        | Pas de vainqueur                                                  |
	  | 300       | 155           | 145           | 0             | 2          | true        | ROSSAT                                                            |
	  | 300       | 155           | 145           | 0             | 2          | false       | Le scrutin n'est pas cloturé                                      |
