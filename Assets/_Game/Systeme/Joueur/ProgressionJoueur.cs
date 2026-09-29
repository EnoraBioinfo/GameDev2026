public class ProgressionJoueur
{
    public int Pieces { get; private set; }
    public int Diamants { get; private set; }

    public int Experience { get; private set; }
    public int Niveau { get; private set; }

    public ProgressionJoueur()
    {
        Pieces = 0;
        Diamants = 0;
        Experience = 0;
        Niveau = 1;
    }

    public void RestaurerEtat(int pieces, int diamants, int experience, int niveau)
    {
        Pieces = pieces;
        Diamants = diamants;
        Experience = experience;
        Niveau = niveau;
    }

    public void AjouterPieces(int quantite)
    {
        if (quantite <= 0)
        {
            return;
        }

        Pieces += quantite;
    }

    public bool DepenserPieces(int quantite)
    {
        if (quantite <= 0 || quantite > Pieces)
        {
            return false;
        }

        Pieces -= quantite;

        return true;
    }

    public void AjouterDiamants(int quantite)
    {
        if (quantite <= 0)
        {
            return;
        }

        Diamants += quantite;
    }

    public bool DepenserDiamants(int quantite)
    {
        if (quantite <= 0 || quantite > Diamants)
        {
            return false;
        }

        Diamants -= quantite;

        return true;
    }

    public void AjouterExperience(int quantite)
    {
        if (quantite <= 0)
        {
            return;
        }

        Experience += quantite;
    }
}