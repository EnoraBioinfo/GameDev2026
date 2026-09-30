public class EnnemiSysteme : IGrilleOccupant
{
    private readonly EnnemiEtat ennemiEtat;
    public GrillePosition Position { get; private set; }
    public EnnemiEtat EnnemiEtat => ennemiEtat;

    public EnnemiSysteme(EnnemiEtat ennemiEtat, GrillePosition positionInitiale)
    {
        this.ennemiEtat = ennemiEtat;
        Position = positionInitiale;
    }

    public void DefinirPosition(GrillePosition position)
    {
        Position = position;
    }
}