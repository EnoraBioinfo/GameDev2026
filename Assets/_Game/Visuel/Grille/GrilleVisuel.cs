using UnityEngine;

public class GrilleVisuel : MonoBehaviour
{
    [SerializeField]
    private GrilleDefinition definition;

    [SerializeField]
    private GameObject cellulePrefab;

    private GrilleSysteme grille;

    private void Awake()
    {
        grille = new GrilleSysteme(definition);

        CreerVisuelGrille();
    }

    private void CreerVisuelGrille()
    {
        for (int x = 0; x < definition.hauteur; x++)
        {
            for (int y = 0; y < definition.largeur; y++)
            {
                var position = new GrillePosition(x, y);

                Vector3 mondePosition =
                    GrilleEnMonde(position);

                Instantiate(
                    cellulePrefab,
                    mondePosition,
                    Quaternion.identity,
                    transform
                );
            }
        }
    }

    private Vector3 GrilleEnMonde(GrillePosition position)
    {
        return new Vector3(
            position.x * definition.tailleCelluleGrille,
            0f,
            position.y * definition.tailleCelluleGrille
        );
    }
}