using System.Collections.Generic;
using UnityEngine;

public class TestCartes : MonoBehaviour
{
    [SerializeField]
    private GestionnaireCartes gestionnaireCartes;

    [SerializeField]
    private CarteDefinition epeeDeBronze;

    private void Start()
    {
        gestionnaireCartes.Initialiser();

        gestionnaireCartes.AjouterCarte(epeeDeBronze, 1);
        gestionnaireCartes.AjouterCarte(epeeDeBronze, 1);
        gestionnaireCartes.AjouterCarte(epeeDeBronze, 1);

        List<CarteInstance> cartesAFusionner =
            gestionnaireCartes.Collection.ObtenirCartesDeNiveau(epeeDeBronze, 1);

        CarteInstance nouvelleCarte =
            gestionnaireCartes.FusionnerCartes(cartesAFusionner);

        if (nouvelleCarte != null)
        {
            Debug.Log($"Fusion réussie : {nouvelleCarte.Definition.nom} N{nouvelleCarte.Niveau}");
        }

        Debug.Log($"Cartes restantes : {gestionnaireCartes.Collection.ObtenirNombreCartes()}");
    }
}