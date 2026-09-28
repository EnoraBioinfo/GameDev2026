using UnityEngine;
using UnityEngine.InputSystem;

public class TestSauvegarde : MonoBehaviour
{
    [SerializeField]
    private GestionnaireSauvegarde gestionnaireSauvegarde;

    [SerializeField]
    private GestionnaireCartes gestionnaireCartes;

    private void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            SauvegarderEtAfficherResultat();
        }

        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            ChargerEtAfficherResultat();
        }
    }

    private void SauvegarderEtAfficherResultat()
    {
        gestionnaireSauvegarde.Sauvegarder();

        AfficherEtatActuel("Après sauvegarde");
    }

    private void ChargerEtAfficherResultat()
    {
        gestionnaireSauvegarde.Charger();

        AfficherEtatActuel("Après chargement");
    }

    private void AfficherEtatActuel(string titre)
    {
        Debug.Log($"--- {titre} ---");

        Debug.Log(
            $"Nombre de cartes : {gestionnaireCartes.Collection.ObtenirNombreCartes()}");

        Debug.Log(
            $"Nombre de decks : {gestionnaireCartes.GestionnaireDecks.ObtenirNombreDecks()}");

        for (int i = 0; i < gestionnaireCartes.GestionnaireDecks.ObtenirNombreDecks(); i++)
        {
            DeckJoueur deck = gestionnaireCartes.GestionnaireDecks.ObtenirDeck(i);

            Debug.Log(
                $"Deck {i + 1} : {deck.Nom} - {deck.ObtenirNombreCartes()} cartes");
        }
    }
}