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

    private void Start()
    {
        GrillePosition positionInitiale = new GrillePosition(0, 0);

        joueurSysteme = new JoueurSysteme(grilleVisuel.Grille, joueurDefinition, positionInitiale);

        grilleVisuel.Grille.PlacerOccupant(joueurSysteme, positionInitiale);

        CreerJoueurVisuel();
    }

    private void CreerJoueurVisuel()
    {
        GameObject joueurObjet = Instantiate(
            joueurPrefab
        );

        joueurVisuel =
            joueurObjet.GetComponent<JoueurVisuel>();

        joueurVisuel.Initialiser(joueurSysteme);
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
        Debug.Log($"Déplacement réussi. PM restants : {joueurSysteme.PointsMouvement}");
    }

    public void RestaurerPointsMouvement()
    {
        joueurSysteme.RestaurerPointsMouvement();

        Debug.Log($"Points de mouvement restaurés : {joueurSysteme.PointsMouvement}");
    }

    public void CommencerSegment(TypeActionJoueur typeAction)
    {
        segmentActionActuel = new SegmentActionJoueur(typeAction);

        Debug.Log($"Segment joueur commencé : {typeAction}");
    }

    public bool PeutFaireAction(TypeActionJoueur typeAction)
    {
        if (segmentActionActuel == null)
        {
            return false;
        }

        return segmentActionActuel.Type == typeAction;
    }
}