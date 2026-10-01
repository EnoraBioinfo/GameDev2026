using System.Collections.Generic;
using UnityEngine;

public class GestionnaireEnnemi : MonoBehaviour
{
    [SerializeField]
    private GrilleVisuel grilleVisuel;

    [SerializeField]
    private GestionnaireNiveau gestionnaireNiveau;

    private List<EnnemiSysteme> ennemis = new();
    public IReadOnlyList<EnnemiSysteme> Ennemis => ennemis;

    public void Initialiser()
    {
        CreerEnnemis();
    }

    private void CreerEnnemis()
    { 
        foreach(EnnemiAPlacer ennemi in gestionnaireNiveau.NiveauSysteme.EnnemisAPlacer)
        {
            for (int i = 0; i < ennemi.nombreAPlacer; i++)
            {
                EnnemiStatistiques ennemiStatistiques = new EnnemiStatistiques(ennemi.ennemiDefinitionScriptable, ennemi.niveau);
                EnnemiEtat ennemiEtat = new EnnemiEtat(ennemiStatistiques);
                GrillePosition positionEnnemi = gestionnaireNiveau.NiveauSysteme.ObtenirPositionDepartEnnemi();
                EnnemiSysteme ennemiSysteme = new EnnemiSysteme(ennemiEtat, positionEnnemi);

                bool placementReussi = grilleVisuel.Grille.PlacerOccupant(ennemiSysteme, positionEnnemi);

                if (!placementReussi)
                {
                    Debug.LogError($"Impossible de placer l'ennemi en {positionEnnemi}");

                    continue;
                }

                if (!CreerEnnemiVisuel(ennemiSysteme, ennemi.ennemiDefinitionScriptable.prefab))
                {
                    continue;
                }
                ennemis.Add(ennemiSysteme);
            }
        }
    }

    private bool CreerEnnemiVisuel(EnnemiSysteme ennemiSysteme, GameObject prefab)
    {
        GameObject ennemiObjet = Instantiate(prefab);

        EnnemiVisuel ennemiVisuel = ennemiObjet.GetComponent<EnnemiVisuel>();

        if (ennemiVisuel == null)
        {
            Destroy(ennemiObjet);
            return false;
        }

        ennemiVisuel.Initialiser(ennemiSysteme);

        return true;
    }
}