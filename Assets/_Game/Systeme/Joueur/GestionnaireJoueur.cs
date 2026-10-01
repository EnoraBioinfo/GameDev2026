using UnityEngine;

public class GestionnaireJoueur : MonoBehaviour
{
    [SerializeField]
    private GameObject joueurPrefab;

    [SerializeField]
    private GestionnaireNiveau gestionnaireNiveau;

    [SerializeField]
    private GrilleVisuel grilleVisuel;

    [SerializeField]
    private JoueurDefinitionScriptable joueurDefinitionScriptable;

    private JoueurStatistiques joueurStatistiques;
    private JoueurEtat joueurEtat;
    public JoueurEtat JoueurEtat => joueurEtat;
    private JoueurSysteme joueurSysteme;
    private JoueurVisuel joueurVisuel;
    private SegmentActionJoueur segmentActionActuel;

    public void Initialiser()
    {
        bool positionTrouvee = gestionnaireNiveau.NiveauSysteme.EssayerObtenirPositionLibre(
            grilleVisuel.Grille,
            gestionnaireNiveau.NiveauSysteme.ZoneDepartJoueur,
            out GrillePosition positionInitiale);

        if (!positionTrouvee)
        {
            Debug.LogWarning("Impossible de trouver une cellule libre pour le joueur.");
            return;
        }

        joueurStatistiques = new JoueurStatistiques(joueurDefinitionScriptable);
        joueurEtat = new JoueurEtat(joueurStatistiques);
        joueurSysteme = new JoueurSysteme(grilleVisuel.Grille, joueurEtat, positionInitiale);

        grilleVisuel.Grille.PlacerOccupant(joueurSysteme, positionInitiale);

        CreerJoueurVisuel();
    }

    private void CreerJoueurVisuel()
    {
        GameObject joueurObjet = Instantiate(joueurPrefab);

        joueurVisuel = joueurObjet.GetComponent<JoueurVisuel>();

        joueurVisuel.Initialiser(joueurSysteme);
    }

    public void CommencerTour()
    {
        joueurEtat.RestaurerSegmentsActions();
        joueurEtat.RestaurerPointsDeMouvements();
        segmentActionActuel = null;
    }

    public void DeplacerVers(GrillePosition position)
    {
        if (!PeutFaireAction(TypeActionJoueur.Deplacement))
        {
            return;
        }

        bool deplacementReussi = joueurSysteme.SeDeplacerVers(position);

        if (!deplacementReussi)
        {
            Debug.Log($"Déplacement impossible vers {position}");
            return;
        }

        joueurVisuel.ActualiserPosition();
    }

    public void RestaurerPointsMouvement()
    {
        joueurSysteme.RestaurerPointsMouvement();
    }

    public bool PeutCommencerUnSegment()
    {
        if (segmentActionActuel != null)
        {
            return false;
        }

        return joueurEtat.SegmentsActionsRestants > 0;
    }

    public bool CommencerSegment(TypeActionJoueur typeAction)
    {
        if (!PeutCommencerUnSegment())
        {
            return false;
        }

        joueurEtat.UtiliserSegmentAction();
        segmentActionActuel = new SegmentActionJoueur(typeAction);

        Debug.Log($"Segment commencé : {typeAction}");

        return true;
    }

    public void TerminerSegment()
    {
        segmentActionActuel = null;
    }

    public bool PeutFaireAction(TypeActionJoueur typeAction)
    {
        if (segmentActionActuel == null)
        {
            return false;
        }

        return segmentActionActuel.Type == typeAction;
    }

    public bool PossedeEncoreUnSegment()
    {
        return joueurEtat.SegmentsActionsRestants > 0;
    }

    public void RecalculerStatistiques()
    {
        joueurStatistiques.Recalculer();
        joueurEtat.AdapterAuxStatistiquesMaximum();
    }
}