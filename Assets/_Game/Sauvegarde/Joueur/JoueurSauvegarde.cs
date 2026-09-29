using System;
using System.Collections.Generic;

[Serializable]
public class JoueurSauvegarde
{
    // ----------- CARTES -----------
    public List<CarteSauvegarde> cartes = new List<CarteSauvegarde>();
    public List<DeckSauvegarde> decks = new List<DeckSauvegarde>();

    public int indexDeckSelectionne;

    // ----------- TOTEMS -----------
    public List<TotemSauvegarde> totems = new List<TotemSauvegarde>();
    public List<EnsembleTotemSauvegarde> ensemblesTotems = new List<EnsembleTotemSauvegarde>();

    public int indexEnsembleTotemSelectionne;

    // ----------- AUTRE -----------
    public ProgressionJoueurSauvegarde progression = new ProgressionJoueurSauvegarde();
}