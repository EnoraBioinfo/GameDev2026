using System.Collections.Generic;

public class GrilleSysteme
{
    private readonly int hauteur;
    private readonly int largeur;

    private readonly Dictionary<GrillePosition, GrilleCellule> cellules;

    public int hauteur => hauteur;
    public int largeur => largeur;

    public GrilleSysteme(GrilleDefinition definition)
    {
        hauteur = definition.hauteur;
        largeur = definition.largeur;

        cellules = new Dictionary<GrillePosition, GrilleCellule>();

        GenererCellules();
    }

    private void GenererCellules()
    {
        for (int x = 0; x < hauteur; x++)
        {
            for (int y = 0; y < largeur; y++)
            {
                var position = new GrillePosition(x, y);

                cellules.Add(
                    position,
                    new GrilleCellule(position)
                );
            }
        }
    }

    public bool Contains(GrillePosition position)
    {
        return cellules.ContainsKey(position);
    }

    public GrilleCellule GetCell(GrillePosition position)
    {
        if (!cellules.TryGetValue(position, out var cell))
        {
            return null;
        }

        return cell;
    }
}