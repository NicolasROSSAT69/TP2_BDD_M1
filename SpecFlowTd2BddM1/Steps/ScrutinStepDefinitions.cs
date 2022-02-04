using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Td2BddM1;
using TechTalk.SpecFlow;

namespace SpecFlowTd2BddM1.Steps;

[Binding]
public sealed class ScrutinStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    public Scrutin _Scrutin;
    public Candidats candidat1;
    public Candidats candidat2;
    public Candidats candidat3;
    private string _result = "";

    public ScrutinStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        candidat1 = new Candidats("Nicolas", "ROSSAT");
        candidat2 = new Candidats("Jean", "Mars");
        candidat3 = new Candidats("Philipe", "Rue");
        List<Candidats> listCandidats = new List<Candidats>();
        listCandidats.Add(candidat1);
        listCandidats.Add(candidat2);
        listCandidats.Add(candidat3);
        _Scrutin = new Scrutin(listCandidats);
    }

    [Given(@"The total number of votes of ballots is (.*)")]
    public void GivenTheTotalNumberOfVotesOfBallotsIs(int p0)
    {
        _Scrutin.nombreVoteTotal = p0;
    }

    [Given(@"The number of votes for the first candidate is (.*)")]
    public void GivenTheNumberOfVotesForTheFirstCandidateIs(string p0)
    {
        candidat1.nombreDeVote = int.Parse(p0);
    }

    [Given(@"The number of votes for the second candidate is (.*)")]
    public void GivenTheNumberOfVotesForTheSecondCandidateIs(string p0)
    {
        candidat2.nombreDeVote = int.Parse(p0);
    }

    [Given(@"The number of votes for the third candidate is (.*)")]
    public void GivenTheNumberOfVotesForTheThirdCandidateIs(string p0)
    {
        candidat3.nombreDeVote = int.Parse(p0);
    }

    [Given(@"The number of ballots is (.*)")]
    public void GivenTheNumberOfBallotsIs(string nombretour)
    {
        _Scrutin.nombreDeTours = int.Parse(nombretour);
    }
    [Given(@"The state of the ballot is (.*)")]
    public void GivenTheStateOfTheBallotIs(string etatscrutin)
    {
        _Scrutin.etatScrutin = bool.Parse(etatscrutin);
    }
    
    [When(@"the winner is obtained")]
    public void WhenTheWinnerIsObtained()
    {
        this._result = _Scrutin.DefinirVainqueur();
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(string result)
    {
        this._result.Should().Be(result);
    }
    
    [When(@"the number of votes is displayed")]
    public void WhenTheNumberOfVotesIsDisplayed()
    {
        candidat1.nombreDeVote = 150;
        candidat2.nombreDeVote = 112;
        candidat3.nombreDeVote = 38;
        this._result = _Scrutin.AfficherNombreVoteCandidats();
    }

    [When(@"the vote percentage is displayed")]
    public void WhenTheVotePercentageIsDisplayed()
    {
        candidat1.nombreDeVote = 150;
        candidat2.nombreDeVote = 112;
        candidat3.nombreDeVote = 38;
        _Scrutin.nombreVoteTotal = 300;
        this._result = _Scrutin.AfficherPourcentageVoteCandidats();
    }
}