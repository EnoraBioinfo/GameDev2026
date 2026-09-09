using UnityEngine;

public class JoueurSysteme : IGrilleOccupant
{
    private readonly GrilleSysteme grille;
    public GrillePosition Position { get; private set; }

    public JoueurSysteme(GrilleSysteme grille, GrillePosition positionInitiale)
    {
        this.grille = grille;
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

        return true;
    }

    public bool SeDeplacerVers(GrillePosition nouvellePosition)
    {
        if (!PeutSeDeplacerVers(nouvellePosition))
        {
            return false;
        }

        return grille.DeplacerOccupant(this, nouvellePosition );
    }
}