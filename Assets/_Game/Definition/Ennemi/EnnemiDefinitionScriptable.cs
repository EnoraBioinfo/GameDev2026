using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "EnnemiDefinitionScriptable",
    menuName = "Jeu/Ennemi/Définition d'un ennemi"
)]

public class EnnemiDefinitionScriptable : ScriptableObject
{ 
    [Header("Informations")]
    public string nom;
    [TextArea(2, 5)]
    public string description;

    [Header("Visuel")]
    public GameObject prefab;

    [Header("Statistiques")]
    [Min(1)]
    public int pointsDeVieMaximum = 10;

    [Min(1)]
    public int nombreActions = 1;

    [Header("Récompenses")]
    [Min(0)]
    public int recompenseOr = 10;

    public List<DropTotemEnnemi> dropsTotems = new();

    [Header("Comportement")]
    public ComportementEnnemi comportement;

    [Header("Attaques")]
    public List<AttaqueEnnemiDefinitionScriptable> attaques = new();
}