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

    public List<CarteInstance> ObtenirCartes(CarteDefinitionScriptable definition)
    {
        return cartes
            .Where(carte => carte.Definition == definition)
            .ToList();
    }

    public CarteInstance ObtenirCarte(string identifiant)
    {
        if (string.IsNullOrEmpty(identifiant))
        {
            return null;
        }

        return cartes.FirstOrDefault(carte => carte.Identifiant == identifiant);
    }

    public int ObtenirNombreCartes(CarteDefinitionScriptable definition)
    {
        return cartes.Count(carte => carte.Definition == definition);
    }

    public List<CarteInstance> ObtenirCartesDeNiveau(CarteDefinitionScriptable definition, int niveau)
    {
        return cartes
            .Where(carte =>
                carte.Definition == definition &&
                carte.Niveau == niveau)
            .ToList();
    }

    public bool ContientCarte(CarteInstance carte)
    {
        return cartes.Contains(carte);
    }
}