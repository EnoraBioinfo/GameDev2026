using UnityEngine;

[CreateAssetMenu(
    fileName = "ReglesDeck",
    menuName = "Jeu/Cartes/Règles de deck"
)]
public class ReglesDeck : ScriptableObject
{
    [Header("Taille du deck")]
    [Min(0)]
    public int nombreMinimumCartes = 5;

    [Min(1)]
    public int nombreMaximumCartes = 10;

    [Header("Limite par carte")]
    [Min(1)]
    public int nombreMaximumMemeCarte = 3;
}