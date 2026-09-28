using System.Collections.Generic;
using System.Linq;

public class EnsembleTotemJoueur
{
    private readonly List<TotemInstance> totems;
    private readonly ReglesEnsembleTotemScriptable reglesEnsembleTotem;
    public string Nom { get; private set; }

    public IReadOnlyList<TotemInstance> Totems => totems;

    public EnsembleTotemJoueur(ReglesEnsembleTotemScriptable reglesEnsembleTotem, string nom)
    {
        totems = new List<TotemInstance>();
        this.reglesEnsembleTotem = reglesEnsembleTotem;
        Nom = nom;
    }

    public void Renommer(string nouveauNom)
    {
        if (string.IsNullOrWhiteSpace(nouveauNom))
        {
            return;
        }

        Nom = nouveauNom;
    }

    public bool PeutAjouterCarte(CarteInstance carte)
    {
        if (reglesDeck == null || carte == null)
        {
            return false;
        }

        if (cartes.Contains(carte))
        {
            return false;
        }

        if (ObtenirNombreCartes() >= reglesDeck.nombreMaximumCartes)
        {
            return false;
        }

        return ObtenirNombreCartes(carte.Definition) < reglesDeck.nombreMaximumMemeCarte;
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

    public int ObtenirNombreCartes(CarteDefinitionScriptable definition)
    {
        return cartes.Count(carte => carte.Definition == definition);
    }

    public bool EstValide()
    {
        if (reglesDeck == null)
        {
            return false;
        }

        return cartes.Count >= reglesDeck.nombreMinimumCartes &&
               cartes.Count <= reglesDeck.nombreMaximumCartes;
    }
}