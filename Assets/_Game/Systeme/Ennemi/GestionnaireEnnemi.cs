using UnityEngine;

public class GestionnaireEnnemi : MonoBehaviour
{
    [SerializeField]
    private EnnemiDefinitionScriptable ennemiDefinitionScriptable;

    [SerializeField]
    private GrilleVisuel grilleVisuel;

    private EnnemiEtat ennemiEtat;
    private EnnemiStatistiques ennemiStatistiques;
    private EnnemiSysteme ennemiSysteme;

    private EnnemiVisuel ennemiVisuel;

    private void Start()
    {
        GrillePosition positionInitiale = new GrillePosition(0, 3);

        ennemiStatistiques = new EnnemiStatistiques(ennemiDefinitionScriptable, 1);
        ennemiEtat = new EnnemiEtat(ennemiStatistiques);
        ennemiSysteme = new EnnemiSysteme(ennemiEtat, positionInitiale);

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
        GameObject ennemiObjet = Instantiate(ennemiDefinitionScriptable.prefab);

        ennemiVisuel = ennemiObjet.GetComponent<EnnemiVisuel>();

        ennemiVisuel.Initialiser(ennemiSysteme);
    }
}