using UnityEngine;

public class GestionnaireJoueur : MonoBehaviour
{
    [SerializeField]
    private GameObject joueurPrefab;

    [SerializeField]
    private GrilleVisuel grilleVisuel;

    [SerializeField]
    private JoueurDefinition joueurDefinition;

    private JoueurSysteme joueurSysteme;
    private JoueurVisuel joueurVisuel;
    private SegmentActionJoueur segmentActionActuel;
    private int nombreSegmentsUtilises;

    public int NombreSegmentsAction => joueurDefinition.nombreSegmentsAction;

    public void Initialiser()
    {
        GrillePosition positionInitiale = new GrillePosition(0, 0);

        joueurSysteme = new JoueurSysteme(grilleVisuel.Grille, joueurDefinition, positionInitiale);

        grilleVisuel.Grille.PlacerOccupant(joueurSysteme, positionInitiale);

        CreerJoueurVisuel();
    }

    private void CreerJoueurVisuel()
    {
        GameObject joueurObjet = Instantiate(joueurPrefab);

        joueurVisuel =
            joueurObjet.GetComponent<JoueurVisuel>();

        joueurVisuel.Initialiser(joueurSysteme);
    }

    public void CommencerTour()
    {
        nombreSegmentsUtilises = 0;
        segmentActionActuel = null;
    }

    public void DeplacerVers(GrillePosition position)
    {
        Debug.Log($"Peut déplacer : {PeutFaireAction(TypeActionJoueur.Deplacement)}");

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
        Debug.Log($"Déplacement réussi. PM restants : {joueurSysteme.PointsMouvement}");
    }

    public void RestaurerPointsMouvement()
    {
        joueurSysteme.RestaurerPointsMouvement();

        Debug.Log($"Points de mouvement restaurés : {joueurSysteme.PointsMouvement}");
    }

    public bool PeutCommencerUnSegment()
    {
        if (segmentActionActuel != null)
        {
            return false;
        }

        return nombreSegmentsUtilises < NombreSegmentsAction;
    }

    public bool CommencerSegment(TypeActionJoueur typeAction)
    {
        if (!PeutCommencerUnSegment())
        {
            return false;
        }

        nombreSegmentsUtilises++;
        segmentActionActuel = new SegmentActionJoueur(typeAction);

        Debug.Log($"Segment {nombreSegmentsUtilises} commencé : {typeAction}");

        return true;
    }

    public void TerminerSegment()
    {
        Debug.Log($"Segment {nombreSegmentsUtilises} terminé");

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
        return nombreSegmentsUtilises < NombreSegmentsAction;
    }
}