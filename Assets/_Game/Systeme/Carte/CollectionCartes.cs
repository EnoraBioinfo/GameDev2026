using System.Collections.Generic;
using System.Linq;

public class CollectionCartes
{
    private readonly List<CarteInstance> cartes;

    public IReadOnlyList<CarteInstance> Cartes => cartes;

    public CollectionCartes()
    {
        cartes = new List<CarteInstance>();
    }

    public void AjouterCarte(CarteInstance carte)
    {
        if (carte == null)
        {
            return;
        }

        cartes.Add(carte);
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

    public List<CarteInstance> ObtenirCartes(CarteDefinition definition)
    {
        return cartes
            .Where(carte => carte.Definition == definition)
            .ToList();
    }

    public int ObtenirNombreCartes(CarteDefinition definition)
    {
        return cartes.Count(carte => carte.Definition == definition);
    }

    public List<CarteInstance> ObtenirCartesDeNiveau(CarteDefinition definition, int niveau)
    {
        return cartes
            .Where(carte =>
                carte.Definition == definition &&
                carte.Niveau == niveau)
            .ToList();
    }
}