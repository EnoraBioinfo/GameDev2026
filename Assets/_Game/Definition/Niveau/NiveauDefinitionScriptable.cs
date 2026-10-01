using System.Collections.Generic;
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

    [Header("Zone de spawn")]
    public RectInt zoneDepartJoueur = new RectInt(0, 0, 2, 2);
    public RectInt zoneSortie = new RectInt(7, 7, 2, 2);

    [SerializeField]
    public List<EnnemiAPlacer> ennemiAPlacer = new();

    [SerializeField]
    public List<GameObject> decorations = new();

    [SerializeField]
    public List<ObsctaclesAPlacer> obstaclesAPlacer = new();
}
