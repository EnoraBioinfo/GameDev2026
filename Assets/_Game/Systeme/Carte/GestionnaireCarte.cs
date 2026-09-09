using System.Collections.Generic;
using UnityEngine;

public class GestionnaireCartes : MonoBehaviour
{
    [SerializeField]
    private int nombreMaximumMemeCarteDansDeck = 3;

    private CollectionCartes collection;
    private DeckJoueur deck;

    public CollectionCartes Collection => collection;
    public DeckJoueur Deck => deck;
    private SystemeFusionCartes systemeFusionCartes;

    public void Initialiser()
    {
        collection = new CollectionCartes();
        deck = new DeckJoueur(nombreMaximumMemeCarteDansDeck);
        systemeFusionCartes = new SystemeFusionCartes();

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
        if (deck == null)
        {
            return false;
        }

        return deck.AjouterCarte(carte);
    }

    public bool RetirerCarteDuDeck(CarteInstance carte)
    {
        if (deck == null)
        {
            return false;
        }

        return deck.RetirerCarte(carte);
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