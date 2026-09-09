using UnityEngine;

public class GrilleVisuel : MonoBehaviour
{
    [SerializeField]
    private GrilleDefinition definition;

    [SerializeField]
    private GameObject cellulePrefab;

    [SerializeField]
    private GameObject obstaclePrefab;

    private GrilleSysteme grille;

    public GrilleSysteme Grille => grille;

    private void Awake()
    {
        this.grille = new GrilleSysteme(definition);

        CreerVisuelGrille();
    }

    private void CreerVisuelGrille()
    {
        for (int x = 0; x < definition.hauteur; x++)
        {
            for (int y = 0; y < definition.largeur; y++)
            {
                GrillePosition position = new GrillePosition(x, y);

                Vector3 positionMonde = GrilleVersMonde(position);

                GameObject cellule = Instantiate(
                    cellulePrefab,
                    positionMonde,
                    Quaternion.identity,
                    transform
                );

                GrilleCelluleVisuel celluleVisuel = cellule.GetComponent<GrilleCelluleVisuel>();

                celluleVisuel.Initialiser(position);
            }
        }
    }

    private Vector3 GrilleVersMonde(GrillePosition position)
    {
        return new Vector3(
            position.x * definition.tailleCelluleGrille,
            0f,
            position.y * definition.tailleCelluleGrille
        );
    }

    public void AfficherCelluleBloquee(GrillePosition position)
    {
        GrilleCelluleVisuel celluleVisuel = TrouverCelluleVisuelle(position);

        if (celluleVisuel == null)
        {
            return;
        }

        celluleVisuel.DefinirBloquee();

        CreerObstacle(position);
    }

    private GrilleCelluleVisuel TrouverCelluleVisuelle(GrillePosition position)
    {
        GrilleCelluleVisuel[] cellules = GetComponentsInChildren<GrilleCelluleVisuel>();

        foreach (GrilleCelluleVisuel cellule in cellules)
        {
            if (cellule.Position == position)
            {
                return cellule;
            }
        }

        return null;
    }

    private void CreerObstacle(GrillePosition position)
    {
        if (obstaclePrefab == null)
        {
            return;
        }

        Vector3 positionMonde = GrilleVersMonde(position);

        positionMonde.y = 0.5f;

        Instantiate(
            obstaclePrefab,
            positionMonde,
            Quaternion.identity,
            transform
        );
    }
}