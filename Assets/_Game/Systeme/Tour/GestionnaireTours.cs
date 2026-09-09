using UnityEngine;
using UnityEngine.InputSystem;

public class GestionnaireTours : MonoBehaviour
{

    public enum TypeTour
    {
        Joueur,
        Ennemis
    }

    public TypeTour TourActuel { get; private set; }

    [SerializeField]
    private GestionnaireJoueur gestionnaireJoueur;

    private void Start()
    {
        gestionnaireJoueur.Initialiser();
        CommencerTourJoueur();
    }

    private void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TerminerSegmentJoueur();
        }

        if (Keyboard.current != null &&
            Keyboard.current.dKey.wasPressedThisFrame)
        {
            ChoisirActionJoueur(TypeActionJoueur.Deplacement);
        }

        if (Keyboard.current != null &&
            Keyboard.current.cKey.wasPressedThisFrame)
        {
            ChoisirActionJoueur(TypeActionJoueur.Cartes);
        }
    }

    private void CommencerTourJoueur()
    {
        TourActuel = TypeTour.Joueur;

        gestionnaireJoueur.CommencerTour();
        gestionnaireJoueur.RestaurerPointsMouvement();

        Debug.Log("Tour du joueur");
    }

    private void CommencerTourEnnemis()
    {
        TourActuel = TypeTour.Ennemis;
        Debug.Log("Tour des ennemis");

        TerminerTourEnnemis();
    }

    private void TerminerTourEnnemis()
    {
        Debug.Log("Fin du tour des ennemis");

        CommencerTourJoueur();
    }

    public void TerminerTourJoueur()
    {
        if (TourActuel != TypeTour.Joueur)
        {
            return;
        }

        Debug.Log("Fin du tour du joueur");

        CommencerTourEnnemis();
    }

    public void ChoisirActionJoueur(TypeActionJoueur typeAction)
    {
        if (TourActuel != TypeTour.Joueur)
        {
            return;
        }

        bool segmentCommence = gestionnaireJoueur.CommencerSegment(typeAction);

        if (!segmentCommence)
        {
            Debug.Log("Aucun segment supplémentaire disponible.");
        }
    }

    public void TerminerSegmentJoueur()
    {
        if (TourActuel != TypeTour.Joueur)
        {
            return;
        }

        gestionnaireJoueur.TerminerSegment();

        if (!gestionnaireJoueur.PossedeEncoreUnSegment())
        {
            TerminerTourJoueur();
        }
    }
}