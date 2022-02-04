namespace Td2BddM1;

public class Candidats
{
    public string nom;
    public string prenom;
    public int nombreDeVote;
    //public int pourcentageVote;
    
    public Candidats(string _prenom, string _nom)
    {
        //Définit le nom du candidat
        prenom = _prenom;
        nom = _nom;
    }

    public int CalculerPourcentage(int _nombreVoteTotal)
    {
        int pourcentageVote = nombreDeVote * 100 / _nombreVoteTotal;
        return pourcentageVote; 
    }
}