public interface IGrilleOccupant
{
    GrillePosition Position { get; }

    void DefinirPosition(GrillePosition position);
}