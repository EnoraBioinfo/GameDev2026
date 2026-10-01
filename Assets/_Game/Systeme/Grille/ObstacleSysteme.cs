using UnityEngine;

public class ObstacleSysteme : IGrilleOccupant
{
    public GrillePosition Position { get; private set; }

    public void DefinirPosition(GrillePosition position)
    {
        Position = position;
    }
}
