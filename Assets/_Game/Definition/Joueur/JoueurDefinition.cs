using UnityEngine;

[CreateAssetMenu(
    fileName = "JoueurDefinition",
    menuName = "Jeu/Joueur/Définition du joueur"
)]
public class JoueurDefinition : ScriptableObject
{
    [Header("Déplacement")]
    [Min(0)]
    public int pointsMouvementMaximum = 3;
}