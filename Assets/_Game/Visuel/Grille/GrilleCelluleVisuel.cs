using UnityEngine;

public class GrilleCelluleVisuel : MonoBehaviour
{
    public GrillePosition Position { get; private set; }

    [SerializeField]
    private Renderer rendu;

    [SerializeField]
    private float facteurEclaircissement = 1.25f;

    private Material[] materiaux;
    private Color[] couleursOriginales;

    public void Initialiser(GrillePosition position)
    {
        Position = position;

        if (rendu != null)
        {
            materiaux = rendu.materials;
            couleursOriginales = new Color[materiaux.Length];

            for (int i = 0; i < materiaux.Length; i++)
            {
                couleursOriginales[i] = materiaux[i].color;
            }
        }

        Deselectionner();
    }

    public void Selectionner()
    {
        if (materiaux == null)
        {
            return;
        }

        for (int i = 0; i < materiaux.Length; i++)
        {
            materiaux[i].color = couleursOriginales[i] * facteurEclaircissement;
        }
    }

    public void Deselectionner()
    {
        if (materiaux == null)
        {
            return;
        }

        for (int i = 0; i < materiaux.Length; i++)
        {
            materiaux[i].color = couleursOriginales[i];
        }
    }

    public void DefinirBloquee()
    {
        if (materiaux == null)
        {
            return;
        }

        for (int i = 0; i < materiaux.Length; i++)
        {
            materiaux[i].color = couleursOriginales[i] * 0.5f;
        }
    }
}