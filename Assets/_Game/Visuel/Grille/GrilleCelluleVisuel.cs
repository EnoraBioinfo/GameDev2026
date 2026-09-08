using UnityEngine;

public class GrilleCelluleVisuel : MonoBehaviour
{
    public GrillePosition Position { get; private set; }

    public void Initialiser(GrillePosition position)
    {
        Position = position;
    }
}
