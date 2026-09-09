using UnityEngine;

public class GestionnaireJoueur : MonoBehaviour
{
    [SerializeField]
    private GameObject joueurPrefab;

    [SerializeField]
    private GrilleVisuel grilleVisuel;

    private JoueurSysteme joueurSysteme;
    private JoueurVisuel joueurVisuel;

    private void Start()
    {
        GrillePosition positionInitiale = new GrillePosition(0, 0);

        joueurSysteme = new JoueurSysteme(grilleVisuel.Grille, positionInitiale);

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
        bool deplacementReussi = joueurSysteme.SeDeplacerVers(position);

        if(!deplacementReussi)
        {
            return;
        }

        joueurVisuel.ActualiserPosition();
    }
}