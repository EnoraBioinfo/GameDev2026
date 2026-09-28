using System;
using System.Collections.Generic;

[Serializable]
public class JoueurSauvegarde
{
    public List<CarteSauvegarde> cartes = new List<CarteSauvegarde>();
    public List<DeckSauvegarde> decks = new List<DeckSauvegarde>();

    public int indexDeckSelectionne;
}