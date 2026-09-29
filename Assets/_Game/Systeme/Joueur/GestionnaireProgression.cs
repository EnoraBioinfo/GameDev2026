using UnityEngine;

public class GestionnaireProgression : MonoBehaviour
{
    private ProgressionJoueur progressionJoueur;
    public ProgressionJoueur Progression => progressionJoueur;
    public int Pieces => progressionJoueur.Pieces;
    public int Diamants => progressionJoueur.Diamants;
    public int Experience => progressionJoueur.Experience;
    public int NIveau => progressionJoueur.Niveau;

    public void Initialiser()
    {
        progressionJoueur = new ProgressionJoueur();
    }

    public ProgressionJoueurSauvegarde CreerSauvegarde ()
    {
        ProgressionJoueurSauvegarde sauvegarde = new ProgressionJoueurSauvegarde();

        sauvegarde.pieces = Pieces;
        sauvegarde.diamants = Diamants;
        sauvegarde.experience = Experience;
        sauvegarde.niveau = NIveau;

        return sauvegarde;

    }

    public void ChargerSauvegarde(ProgressionJoueurSauvegarde sauvegarde)
    {
        if (sauvegarde == null)
        {
            return;
        }

        if (progressionJoueur == null)
        {
            Initialiser();
        }

        progressionJoueur.RestaurerEtat(sauvegarde.pieces, sauvegarde.diamants, sauvegarde.experience, sauvegarde.niveau);
    }

    public void AjouterPieces(int quantite)
    {
        progressionJoueur.AjouterPieces(quantite);
    }

    public bool DepenserPieces(int quantite)
    {
        return progressionJoueur.DepenserPieces(quantite);
    }

    public void AjouterDiamants(int quantite)
    {
        progressionJoueur.AjouterDiamants(quantite);
    }

    public bool DepenserDiamants(int quantite)
    {
        return progressionJoueur.DepenserDiamants(quantite);
    }

    public void AjouterExperience(int quantite)
    {
        progressionJoueur.AjouterExperience(quantite);
    }

}
