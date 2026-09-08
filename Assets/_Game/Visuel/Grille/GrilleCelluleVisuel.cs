using UnityEngine;

public class GrilleCelluleVisuel : MonoBehaviour
{
    public GrillePosition Position { get; private set; }

    [SerializeField]
    private Renderer rendu;

    [SerializeField]
    private Material materiauNormal;

    [SerializeField]
    private Material materiauSelectionne;

    public void Initialiser(GrillePosition position)
    {
        Position = position;

        Deselectionner();
    }

    public void Selectionner()
    {
        if (rendu != null && materiauSelectionne != null)
        {
            rendu.material = materiauSelectionne;
        }
    }

    public void Deselectionner()
    {
        if (rendu != null && materiauNormal != null)
        {
            rendu.material = materiauNormal;
        }
    }
}