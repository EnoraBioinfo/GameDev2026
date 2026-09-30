using UnityEngine;

public class JoueurSysteme : IGrilleOccupant
{
    private readonly GrilleSysteme grille;
    private readonly JoueurEtat joueurEtat;
    public GrillePosition Position { get; private set; }
    public JoueurEtat JoueurEtat => joueurEtat;

    public JoueurSysteme(GrilleSysteme grille, JoueurEtat joueurEtat, GrillePosition positionInitiale)
    {
        this.grille = grille;
        this.joueurEtat = joueurEtat;
        Position = positionInitiale;
    }

    public void DefinirPosition(GrillePosition position)
    {
        Position = position;
    }

    public bool PeutSeDeplacerVers(GrillePosition nouvellePosition)
    {
        int distanceX = nouvellePosition.x - Position.x;
        int distanceY = nouvellePosition.y - Position.y;

        int distance = System.Math.Abs(distanceX) + System.Math.Abs(distanceY);

        if (distance != 1)
        {
            return false;
        }

        if (!grille.EstTraversable(nouvellePosition))
        {
            return false;
        }

        if(joueurEtat.PointsMouvementsRestants <= 0)
        {
            return false;
        }

        return true;
    }

    public bool SeDeplacerVers(GrillePosition nouvellePosition)
    {
        if (!PeutSeDeplacerVers(nouvellePosition))
        {
            return false;
        }

        bool deplacementReussi = grille.DeplacerOccupant(this, nouvellePosition);

        if (!deplacementReussi)
        {
            return false;
        }

        joueurEtat.UtiliserPointMouvement();

        return true;
    }

    public void RestaurerPointsMouvement()
    {
        joueurEtat.RestaurerPointsDeMouvements();
    }
}