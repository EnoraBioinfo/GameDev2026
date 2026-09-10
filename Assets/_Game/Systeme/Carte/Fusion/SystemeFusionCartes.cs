using System.Collections.Generic;

public class SystemeFusionCartes
{
    private readonly ReglesFusionCartes reglesFusion;

    public SystemeFusionCartes(ReglesFusionCartes reglesFusion)
    {
        this.reglesFusion = reglesFusion;
    }

    public bool PeutFusionner(List<CarteInstance> cartes, out int niveauResultat)
    {
        niveauResultat = 0;

        if (reglesFusion == null)
        {
            return false;
        }

        if (cartes == null || cartes.Count == 0)
        {
            return false;
        }

        if (!ToutesLesCartesSontValides(cartes))
        {
            return false;
        }

        CarteDefinition definition = cartes[0].Definition;
        int pointsFusion = ObtenirPointsFusion(cartes);

        if (pointsFusion <= 0)
        {
            return false;
        }

        niveauResultat = ObtenirNiveauResultat(pointsFusion, definition.niveauMaximum);

        return niveauResultat > 0;
    }

    public int CalculerPointsFusion(List<CarteInstance> cartes)
    {
        if (reglesFusion == null)
        {
            return 0;
        }

        if (!ToutesLesCartesSontValides(cartes))
        {
            return 0;
        }

        return ObtenirPointsFusion(cartes);
    }

    public CarteInstance Fusionner(CollectionCartes collection, List<CarteInstance> cartes)
    {
        if (collection == null)
        {
            return null;
        }

        if (!PeutFusionner(cartes, out int niveauResultat))
        {
            return null;
        }

        CarteDefinition definition = cartes[0].Definition;

        foreach (CarteInstance carte in cartes)
        {
            collection.RetirerCarte(carte);
        }

        CarteInstance nouvelleCarte = new CarteInstance(definition, niveauResultat);

        collection.AjouterCarte(nouvelleCarte);

        return nouvelleCarte;
    }

    private bool ToutesLesCartesSontValides(List<CarteInstance> cartes)
    {
        CarteDefinition definition = cartes[0]?.Definition;

        if (definition == null)
        {
            return false;
        }

        foreach (CarteInstance carte in cartes)
        {
            if (carte == null)
            {
                return false;
            }

            if (carte.Definition != definition)
            {
                return false;
            }

            if (carte.Niveau < 1 || carte.Niveau > definition.niveauMaximum)
            {
                return false;
            }
        }

        return true;
    }

    private int ObtenirPointsFusion(List<CarteInstance> cartes)
    {
        int pointsFusion = 0;

        foreach (CarteInstance carte in cartes)
        {
            int valeurFusion = reglesFusion.ObtenirValeurFusion(carte.Niveau);

            if (valeurFusion <= 0)
            {
                return 0;
            }

            pointsFusion += valeurFusion;
        }

        return pointsFusion;
    }

    private int ObtenirNiveauResultat(int pointsFusion, int niveauMaximum)
    {
        int meilleurNiveau = 0;

        foreach (CoutEvolutionCarte cout in reglesFusion.coutsEvolution)
        {
            if (cout.niveau > niveauMaximum)
            {
                continue;
            }

            if (cout.pointsNecessaires <= pointsFusion && cout.niveau > meilleurNiveau)
            {
                meilleurNiveau = cout.niveau;
            }
        }

        return meilleurNiveau;
    }
}