using UnityEngine;

public class JoueurSysteme : IGrilleOccupant
{
    private readonly GrilleSysteme grille;
    public GrillePosition Position { get; private set; }

    private readonly JoueurDefinition joueurDefinition;

    public int PointsMouvement { get; private set; }

    public JoueurSysteme(GrilleSysteme grille, JoueurDefinition joueurDefinition, GrillePosition positionInitiale)
    {
        this.grille = grille;
        this.joueurDefinition = joueurDefinition;
        Position = positionInitiale;
        PointsMouvement = joueurDefinition.pointsMouvementMaximum;
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

        return true;
    }

    public bool SeDeplacerVers(GrillePosition nouvellePosition)
    {
        if (!PeutSeDeplacerVers(nouvellePosition))
        {
            return false;
        }

        if (PointsMouvement <= 0)
        {
            return false;
        }

        bool deplacementReussi = grille.DeplacerOccupant(this, nouvellePosition);

        if (!deplacementReussi)
        {
            return false;
        }

        PointsMouvement--;

        return true;
    }

    public void RestaurerPointsMouvement()
    {
        PointsMouvement = joueurDefinition.pointsMouvementMaximum;
    }
}