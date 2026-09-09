using UnityEngine;

public class TestObstaclesGrille : MonoBehaviour
{
    [SerializeField]
    private GrilleVisuel grilleVisuel;

    private void Start()
    {
        BloquerCellule(new GrillePosition(4, 4));
        BloquerCellule(new GrillePosition(4, 5));
        BloquerCellule(new GrillePosition(4, 6));
    }

    private void BloquerCellule(GrillePosition position)
    {
        grilleVisuel.Grille.DefinirCelluleTraversable(
            position,
            false
        );

        grilleVisuel.AfficherCelluleBloquee(position);
    }
}