using System.Collections.Generic;

public class GestionnaireDecks
{
    private readonly List<DeckJoueur> decks;
    private readonly ReglesDeck reglesDeck;

    private int indexDeckSelectionne;

    public IReadOnlyList<DeckJoueur> Decks => decks;
    public DeckJoueur DeckSelectionne => ObtenirDeckSelectionne();

    public GestionnaireDecks(ReglesDeck reglesDeck, int nombreDecks)
    {
        this.reglesDeck = reglesDeck;
        decks = new List<DeckJoueur>();
        indexDeckSelectionne = 0;

        for (int i = 0; i < nombreDecks; i++)
        {
            CreerDeck($"Deck {i + 1}");
        }
    }

    public DeckJoueur CreerDeck(string nom)
    {
        if (reglesDeck == null)
        {
            return null;
        }

        if (string.IsNullOrWhiteSpace(nom))
        {
            return null;
        }

        DeckJoueur deck = new DeckJoueur(reglesDeck, nom);

        decks.Add(deck);

        return deck;
    }

    public bool SupprimerDeck(DeckJoueur deck)
    {
        if (deck == null)
        {
            return false;
        }

        if (!decks.Contains(deck))
        {
            return false;
        }

        if (decks.Count <= 1)
        {
            return false;
        }

        int indexDeck = decks.IndexOf(deck);

        decks.Remove(deck);

        if (indexDeckSelectionne > indexDeck)
        {
            indexDeckSelectionne--;
        }
        else if (indexDeckSelectionne == indexDeck && indexDeckSelectionne >= decks.Count)
        {
            indexDeckSelectionne = decks.Count - 1;
        }

        return true;
    }

    public bool RenommerDeck(DeckJoueur deck, string nouveauNom)
    {
        if (deck == null)
        {
            return false;
        }

        if (!decks.Contains(deck))
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(nouveauNom))
        {
            return false;
        }

        deck.Renommer(nouveauNom);

        return true;
    }

    public DeckJoueur ObtenirDeck(int index)
    {
        if (index < 0 || index >= decks.Count)
        {
            return null;
        }

        return decks[index];
    }

    public DeckJoueur ObtenirDeckSelectionne()
    {
        return ObtenirDeck(indexDeckSelectionne);
    }

    public bool SelectionnerDeck(int index)
    {
        if (index < 0 || index >= decks.Count)
        {
            return false;
        }

        indexDeckSelectionne = index;

        return true;
    }

    public int ObtenirNombreDecks()
    {
        return decks.Count;
    }
}