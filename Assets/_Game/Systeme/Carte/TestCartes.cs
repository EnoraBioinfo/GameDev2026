using System.Collections.Generic;
using UnityEngine;

public class TestCartes : MonoBehaviour
{
    [SerializeField]
    private GestionnaireCartes gestionnaireCartes;

    [SerializeField]
    private CarteDefinitionScriptable epeeDeBronze;

    private void Start()
    {
        gestionnaireCartes.Initialiser();

        gestionnaireCartes.AjouterCarte(epeeDeBronze, 1);
        gestionnaireCartes.AjouterCarte(epeeDeBronze, 3);
        gestionnaireCartes.AjouterCarte(epeeDeBronze, 3);

        CarteInstance carte = gestionnaireCartes.Collection.ObtenirCartesDeNiveau(epeeDeBronze, 1)[0];

        Debug.Log($"Nombre de decks : {gestionnaireCartes.GestionnaireDecks.ObtenirNombreDecks()}");

        DeckJoueur nouveauDeck = gestionnaireCartes.GestionnaireDecks.CreerDeck("Deck Test");

        Debug.Log($"Nouveau deck : {nouveauDeck.Nom}");

        gestionnaireCartes.GestionnaireDecks.RenommerDeck(nouveauDeck, "Deck Guerrier");

        Debug.Log($"Nouveau nom : {nouveauDeck.Nom}");

        gestionnaireCartes.GestionnaireDecks.SelectionnerDeck(3);

        Debug.Log($"Deck sélectionné : {gestionnaireCartes.DeckSelectionne.Nom}");

        bool ajoutDeck2 = gestionnaireCartes.AjouterCarteAuDeck(carte);

        Debug.Log($"Ajout au deck  {gestionnaireCartes.DeckSelectionne.Nom} : {ajoutDeck2}");

        bool suppression = gestionnaireCartes.GestionnaireDecks.SupprimerDeck(nouveauDeck);

        Debug.Log($"Suppression réussie : {suppression}");



    }
}