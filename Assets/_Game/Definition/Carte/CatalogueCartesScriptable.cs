using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "CatalogueCartes",
    menuName = "Jeu/Cartes/Catalogue de cartes"
)]
public class CatalogueCartesScriptable : ScriptableObject
{
    [Header("Cartes disponibles")]
    public List<CarteDefinitionScriptable> cartes = new List<CarteDefinitionScriptable>();

    public CarteDefinitionScriptable ObtenirCarte(string identifiant)
    {
        if (string.IsNullOrEmpty(identifiant))
        {
            return null;
        }

        foreach (CarteDefinitionScriptable carte in cartes)
        {
            if (carte == null)
            {
                continue;
            }

            if (carte.identifiant == identifiant)
            {
                return carte;
            }
        }

        return null;
    }
}