using System.Collections.Generic;
using UnityEngine;

public class SystemeFusionCartes
{
    public bool PeutFusionner( List<CarteInstance> cartes, out int niveauResultat)
    {
        niveauResultat = 0;

        if (cartes == null || cartes.Count == 0)
        {
            return false;
        }

        CarteDefinition definition = cartes[0].Definition;

        if (definition == null)
        {
            return false;
        }

        int pointsFusion = 0;

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

            pointsFusion += carte.ObtenirValeurFusion();
        }

        niveauResultat = ObtenirNiveauResultat(pointsFusion);

        if (niveauResultat <= 0)
        {
            return false;
        }

        if (niveauResultat > definition.niveauMaximum)
        {
            return false;
        }

        return true;
    }

    public CarteInstance Fusionner(CollectionCartes collection, List<CarteInstance> cartes)
    {
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

    private int ObtenirNiveauResultat(int pointsFusion)
    {
        int niveau = 0;
        int pointsNecessaires = 0;

        while (pointsNecessaires < pointsFusion)
        {
            niveau++;
            pointsNecessaires = niveau * (niveau + 1) / 2;
        }

        if (pointsNecessaires != pointsFusion)
        {
            return 0;
        }

        return niveau;
    }
}