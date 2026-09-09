public class EnnemiSysteme : IGrilleOccupant
{
    public GrillePosition Position { get; private set; }

    public EnnemiSysteme(GrillePosition positionInitiale)
    {
        Position = positionInitiale;
    }

    public void DefinirPosition(GrillePosition position)
    {
        Position = position;
    }
}