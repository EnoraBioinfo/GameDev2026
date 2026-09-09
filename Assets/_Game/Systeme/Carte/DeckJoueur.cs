using System.Collections.Generic;
using System.Linq;

public class DeckJoueur
{
    private readonly List<CarteInstance> cartes;
    private readonly int nombreMaximumMemeCarte;

    public IReadOnlyList<CarteInstance> Cartes => cartes;

    public DeckJoueur(int nombreMaximumMemeCarte)
    {
        cartes = new List<CarteInstance>();
        this.nombreMaximumMemeCarte = nombreMaximumMemeCarte;
    }

    public bool PeutAjouterCarte(CarteInstance carte)
    {
        if (carte == null)
        {
            return false;
        }

        int nombreDejaPresent = ObtenirNombreCartes(carte.Definition);

        return nombreDejaPresent < nombreMaximumMemeCarte;
    }

    public bool AjouterCarte(CarteInstance carte)
    {
        if (!PeutAjouterCarte(carte))
        {
            return false;
        }

        cartes.Add(carte);

        return true;
    }

    public bool RetirerCarte(CarteInstance carte)
    {
        if (carte == null)
        {
            return false;
        }

        return cartes.Remove(carte);
    }

    public int ObtenirNombreCartes()
    {
        return cartes.Count;
    }

    public int ObtenirNombreCartes(CarteDefinition definition)
    {
        return cartes.Count(carte => carte.Definition == definition);
    }
}