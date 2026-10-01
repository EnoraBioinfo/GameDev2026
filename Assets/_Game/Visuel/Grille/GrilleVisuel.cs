using UnityEngine;

public class GrilleVisuel : MonoBehaviour
{
    [SerializeField]
    private GestionnaireNiveau gestionnaireNiveau;

    [SerializeField]
    private GameObject cellulePrefab;

    private GrilleSysteme grille;

    public GrilleSysteme Grille => grille;

    public void Initialiser()
    {
        if (!ValidationReferencesUnity.Verifier(
                this,
                (nameof(gestionnaireNiveau), gestionnaireNiveau),
                (nameof(cellulePrefab), cellulePrefab)))
        {
            return;
        }

        GrilleDefinition definition = gestionnaireNiveau.NiveauSysteme.GrilleDefinition;
        this.grille = new GrilleSysteme(definition);

        CreerVisuelGrille(definition);
        CreerObstacles();
        CreerDecorations(definition);
    }

    private void CreerVisuelGrille(GrilleDefinition definition)
    {
        for (int x = 0; x < definition.hauteur; x++)
        {
            for (int y = 0; y < definition.largeur; y++)
            {
                GrillePosition position = new GrillePosition(x, y);

                Vector3 positionMonde = GrilleVersMonde(position, definition);
                positionMonde.y = -0.2f;

                GameObject cellule = Instantiate(
                    cellulePrefab,
                    positionMonde,
                    Quaternion.identity,
                    transform
                );

                GrilleCelluleVisuel celluleVisuel = cellule.GetComponent<GrilleCelluleVisuel>();

                if (celluleVisuel == null)
                {
                    Debug.LogError(
                        $"{nameof(GrilleVisuel)} '{name}' : le prefab '{cellulePrefab.name}' " +
                        $"ne contient pas le composant {nameof(GrilleCelluleVisuel)}.",
                        this);
                    Destroy(cellule);
                    return;
                }

                celluleVisuel.Initialiser(position);
            }
        }
    }

    private void CreerDecorations(GrilleDefinition grilleDefinition)
    {
        for (int x = 0; x < grilleDefinition.hauteur; x++)
        {
            for (int y = 0; y < grilleDefinition.largeur; y++)
            {
                GameObject decorationPrefab = gestionnaireNiveau.NiveauSysteme.ObtenirDecorationPourCellule();
                if(decorationPrefab == null)
                {
                    continue;
                }

                GrillePosition position = new GrillePosition(x, y);

                Vector3 positionMonde = GrilleVersMonde(position, grilleDefinition);

                float amplitude = grilleDefinition.tailleCelluleGrille * 0.2f;
                positionMonde += gestionnaireNiveau.NiveauSysteme.ObtenirVariationDecoration(amplitude);

                float rotationY = gestionnaireNiveau.NiveauSysteme.ObtenirRotationY();

                GameObject decoration = Instantiate(
                    decorationPrefab,
                    positionMonde,
                    Quaternion.Euler(0f, rotationY, 0f),
                    transform
                );

                Debug.Log($"Décoration créée en {decoration.transform.position}");
            }
        }

    }

    private Vector3 GrilleVersMonde(GrillePosition position, GrilleDefinition definition)
    {
        return new Vector3(
            position.x * definition.tailleCelluleGrille,
            0f,
            position.y * definition.tailleCelluleGrille
        );
    }

    private void CreerObstacles()
    {
        foreach (ObsctaclesAPlacer obstacleAPlacer in gestionnaireNiveau.NiveauSysteme.ObsctaclesAPlacer)
        {
            for (int i = 0; i < obstacleAPlacer.nombreAPlacer; i++)
            {
                if (obstacleAPlacer.obstacleGameObject == null)
                {
                    continue;
                }

                bool positionTrouvee = gestionnaireNiveau.NiveauSysteme.EssayerObtenirPositionLibre(
                    grille,
                    out GrillePosition position);

                if (!positionTrouvee)
                {
                    Debug.LogWarning($"Impossible de trouver une cellule libre pour l'obstacle {obstacleAPlacer.obstacleGameObject.name}.");
                    continue;
                }

                ObstacleSysteme obstacleSysteme = new ObstacleSysteme();

                if (!grille.PlacerObstacle(obstacleSysteme, position))
                {
                    continue;
                }

                CreerVisuelObstacle(obstacleAPlacer.obstacleGameObject, position);
            }
        }
    }

    private void CreerVisuelObstacle(GameObject prefab, GrillePosition position)
    {
        GrilleDefinition definition = gestionnaireNiveau.NiveauSysteme.GrilleDefinition;
        Vector3 positionMonde = GrilleVersMonde(position, definition);

        positionMonde.y = 0.1f;

        Instantiate(
            prefab,
            positionMonde,
            Quaternion.identity,
            transform
        );
    }
}