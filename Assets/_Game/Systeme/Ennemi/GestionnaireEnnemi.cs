using UnityEngine;

public class GestionnaireEnnemi : MonoBehaviour
{
    [SerializeField]
    private GameObject ennemiPrefab;

    [SerializeField]
    private GrilleVisuel grilleVisuel;

    private EnnemiSysteme ennemiSysteme;
    private EnnemiVisuel ennemiVisuel;

    private void Start()
    {
        GrillePosition positionInitiale = new GrillePosition(0, 3);

        ennemiSysteme = new EnnemiSysteme(positionInitiale);

        bool placementReussi = grilleVisuel.Grille.PlacerOccupant(ennemiSysteme, positionInitiale);

        if (!placementReussi)
        {
            Debug.LogError(
                $"Impossible de placer l'ennemi en {positionInitiale}"
            );

            return;
        }

        CreerEnnemiVisuel();
    }

    private void CreerEnnemiVisuel()
    {
        GameObject ennemiObjet = Instantiate(ennemiPrefab);

        ennemiVisuel = ennemiObjet.GetComponent<EnnemiVisuel>();

        ennemiVisuel.Initialiser(ennemiSysteme);
    }
}