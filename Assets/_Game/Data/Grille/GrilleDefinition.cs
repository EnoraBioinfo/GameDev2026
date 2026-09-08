using UnityEngine;

[CreateAssetMenu(
    fileName = "GrilleDefinition",
    menuName = "Game/Grille/Grille Definition"
)]
public class GrilleDefinition : ScriptableObject
{
    [Header("Dimensions")]
    [Min(1)]
    public int hauteur = 10;

    [Min(1)]
    public int largeur = 10;

    [Header("Visual")]
    public float tailleCelluleGrille = 1f;
}