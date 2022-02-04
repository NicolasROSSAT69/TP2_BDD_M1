namespace Td2BddM1;

public class Scrutin
{
    public bool etatScrutin = false;
    public int nombreVoteTotal { get; set; }
    public int nombreDeTours;
    public List<Candidats> listCandidats = null!;

    public Scrutin(List<Candidats> _listCandidats)
    {
        listCandidats = new List<Candidats>();
        foreach (var c in _listCandidats)
        {
            listCandidats.Add(c);
        }
        
    }

    public string AfficherNombreVoteCandidats()
    {
        if (etatScrutin) //Verification de la cloture du scrutin
        {
            string affichage = "Nombre de vote: ";
            
            foreach (var c in listCandidats)
            {
                affichage += c.nom + " : " + c.nombreDeVote + ",";
            }
            
            return affichage;
        }
        
        return "Le scrutin n'est pas cloturé";
    }
    
    public string AfficherPourcentageVoteCandidats()
    {
        if (etatScrutin) //Verification de la cloture du scrutin
        {
            string affichage = "Pourcentage de vote: ";
            
            foreach (var c in listCandidats)
            {
                int resultat = c.CalculerPourcentage(nombreVoteTotal);
                affichage += c.nom + " : " + resultat + ",";
            }
            
            return affichage;
        }
        
        return "Le scrutin n'est pas cloturé";
    }
    
    public string DefinirVainqueur()
    {
        if (etatScrutin) //Verification si le scrutin est terminé
        {
            if (nombreDeTours == 1)
            {
                foreach (var c in listCandidats)
                {
                    int pourcentage =  c.CalculerPourcentage(nombreVoteTotal);
                    if (pourcentage >= 50) //verifie si un candidat a 50% ou plus des votes
                    {
                        return c.nom; // Un vainqueur est trouvé 
                    }
                }
                listCandidats = listCandidats.OrderByDescending(x => x.nombreDeVote).ToList();
                return "Refaire un tour de scrutin avec ces deux candidat : " + listCandidats[0].nom + " et " + listCandidats[1].nom;
            }
            else if (nombreDeTours == 2)
            {
                foreach (var c in listCandidats)//parcours de la liste de candidat du deuxième tour
                {
                    int pourcentage =  c.CalculerPourcentage(nombreVoteTotal);
                    if (pourcentage > 50)
                    {
                        return c.nom; // Un vainqueur est trouvé 
                    }
                }
                return "Pas de vainqueur";
            }
            return "Erreur 1";
        }
        else if (etatScrutin == false)
        {
            return "Le scrutin n'est pas cloturé";
        }
        return "Erreur 2";
    }
}