using System.Collections.Generic;
using UnityEngine;

public class GestionnaireEnnemi : MonoBehaviour
{
    [SerializeField]
    private List<EnnemiAPlacer> ennemiAPlacer = new();

    [SerializeField]
    private GrilleVisuel grilleVisuel;

    private EnnemiEtat ennemiEtat;
    private EnnemiStatistiques ennemiStatistiques;
    private EnnemiSysteme ennemiSysteme;

    private EnnemiVisuel ennemiVisuel;

    private void Start()
    {
        CreerEnnemis();
    }

    private void CreerEnnemis()
    { 
        foreach(EnnemiAPlacer ennemi in ennemiAPlacer)
        {
            ennemiStatistiques = new EnnemiStatistiques(ennemi.ennemiDefinitionScriptable, ennemi.niveau);
            ennemiEtat = new EnnemiEtat(ennemiStatistiques);
            ennemiSysteme = new EnnemiSysteme(ennemiEtat, ennemi.position);

            bool placementReussi = grilleVisuel.Grille.PlacerOccupant(ennemiSysteme, ennemi.position);

            if (!placementReussi)
            {
                Debug.LogError($"Impossible de placer l'ennemi en {ennemi.position}");

                return;
            }

            CreerEnnemiVisuel(ennemiSysteme, ennemi.ennemiDefinitionScriptable.prefab);
        }
    }

    private void CreerEnnemiVisuel(EnnemiSysteme ennemiSysteme, GameObject prefab)
    {
        GameObject ennemiObjet = Instantiate(prefab);

        ennemiVisuel = ennemiObjet.GetComponent<EnnemiVisuel>();

        ennemiVisuel.Initialiser(ennemiSysteme);
    }
}