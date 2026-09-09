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
        CommencerTourJoueur();
    }

    private void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TerminerTourJoueur();
        }
    }

    private void CommencerTourJoueur()
    {
        TourActuel = TypeTour.Joueur;

        gestionnaireJoueur.RestaurerPointsMouvement();
        gestionnaireJoueur.CommencerSegment(TypeActionJoueur.Deplacement);

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
}