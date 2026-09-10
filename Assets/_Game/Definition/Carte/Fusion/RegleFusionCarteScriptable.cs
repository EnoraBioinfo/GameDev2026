using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "ReglesFusionCartes",
    menuName = "Jeu/Cartes/Règles de fusion"
)]
public class ReglesFusionCartesScriptable : ScriptableObject
{
    [Header("Valeur de fusion par niveau")]
    public List<ValeurFusionCarte> valeursFusion = new List<ValeurFusionCarte>();

    [Header("Points nécessaires par niveau")]
    public List<CoutEvolutionCarte> coutsEvolution = new List<CoutEvolutionCarte>();

    public int ObtenirValeurFusion(int niveau)
    {
        foreach (ValeurFusionCarte valeur in valeursFusion)
        {
            if (valeur.niveau == niveau)
            {
                return valeur.points;
            }
        }

        return 0;
    }

    public int ObtenirCoutEvolution(int niveau)
    {
        foreach (CoutEvolutionCarte cout in coutsEvolution)
        {
            if (cout.niveau == niveau)
            {
                return cout.pointsNecessaires;
            }
        }

        return 0;
    }
}

[System.Serializable]
public class ValeurFusionCarte
{
    [Min(1)]
    public int niveau;

    [Min(1)]
    public int points;
}

[System.Serializable]
public class CoutEvolutionCarte
{
    [Min(1)]
    public int niveau;

    [Min(1)]
    public int pointsNecessaires;
}