using System.Collections.Generic;
using UnityEngine;

public class GestionnaireCartes : MonoBehaviour
{
    [SerializeField]
    private ReglesDeck reglesDeck;

    [SerializeField]
    private int nombreDecks = 3;

    [SerializeField]
    private ReglesFusionCartes reglesFusion;

    private CollectionCartes collection;
    private GestionnaireDecks gestionnaireDecks;
    private SystemeFusionCartes systemeFusionCartes;

    public CollectionCartes Collection => collection;
    public GestionnaireDecks GestionnaireDecks => gestionnaireDecks;
    public DeckJoueur DeckSelectionne => gestionnaireDecks?.DeckSelectionne;

    public void Initialiser()
    {
        collection = new CollectionCartes();
        gestionnaireDecks = new GestionnaireDecks(reglesDeck, nombreDecks);
        systemeFusionCartes = new SystemeFusionCartes(reglesFusion);

        Debug.Log("Gestionnaire de cartes initialisé.");
    }

    public bool AjouterCarte(CarteDefinition definition, int niveau)
    {
        if (definition == null)
        {
            return false;
        }

        if (niveau < 1 || niveau > definition.niveauMaximum)
        {
            Debug.LogWarning($"Niveau de carte invalide : {niveau}");
            return false;
        }

        CarteInstance carte = new CarteInstance(definition, niveau);

        collection.AjouterCarte(carte);

        return true;
    }

    public bool AjouterCarteAuDeck(CarteInstance carte)
    {
        if (gestionnaireDecks == null || carte == null)
        {
            return false;
        }

        if (!collection.ContientCarte(carte))
        {
            return false;
        }

        DeckJoueur deck = gestionnaireDecks.DeckSelectionne;

        if (deck == null)
        {
            return false;
        }

        return deck.AjouterCarte(carte);
    }

    public bool RetirerCarteDuDeck(CarteInstance carte)
    {
        if (gestionnaireDecks == null)
        {
            return false;
        }

        DeckJoueur deck = gestionnaireDecks.DeckSelectionne;

        if (deck == null)
        {
            return false;
        }

        return deck.RetirerCarte(carte);
    }

    public bool SelectionnerDeck(int index)
    {
        if (gestionnaireDecks == null)
        {
            return false;
        }

        return gestionnaireDecks.SelectionnerDeck(index);
    }

    public CarteInstance FusionnerCartes(List<CarteInstance> cartes)
    {
        if (systemeFusionCartes == null)
        {
            return null;
        }

        return systemeFusionCartes.Fusionner(collection, cartes);
    }
}