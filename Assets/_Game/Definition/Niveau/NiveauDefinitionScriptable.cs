using UnityEngine;

[CreateAssetMenu(
    fileName = "NiveauDefinitionScriptable",
    menuName = "Jeu/Niveau/Définition d'un niveau"
)]
public class NiveauDefinitionScriptable : ScriptableObject
{
    [Header("Niveau")]
    [Min(1)]
    public int numeroNiveau = 1;

    [Header("Grille")]
    public GrilleDefinition grilleDefinition;

    [Header("Grille")]
    public int seed = 0;
}
