using System.Collections.Generic;

public class GrilleSysteme
{
    private readonly int hauteur;
    private readonly int largeur;

    private readonly Dictionary<GrillePosition, GrilleCellule> cellules;

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

    public GrilleCellule ObtenirCellule(GrillePosition position)
    {
        if (!cellules.TryGetValue(position, out var cellule))
        {
            return null;
        }

        return cellule;
    }

    public bool EstTraversable(GrillePosition position)
    {
        GrilleCellule cellule = ObtenirCellule(position);

        if(cellule == null)
        {
            return false;
        }

        return cellule.EstTraversable;
    }

    public void DefinirCelluleTraversable(GrillePosition position, bool estTraversable)
    {
        GrilleCellule cellule = ObtenirCellule(position);

        if (cellule == null)
        {
            return;
        }

        cellule.DefinirSiTraversable(estTraversable);
    }

    public IEnumerable<GrilleCellule> ObtenirToutesLesCellules()
    {
        return cellules.Values;
    }

    public bool PlacerOccupant(IGrilleOccupant occupant, GrillePosition position)
    {
        GrilleCellule cellule = ObtenirCellule(position);

        if (cellule == null)
        {
            return false;
        }

        if (!cellule.PlacerOccupant(occupant))
        {
            return false;
        }

        occupant.DefinirPosition(position);

        return true;
    }

    public void RetirerOccupant(GrillePosition position)
    {
        GrilleCellule cellule = ObtenirCellule(position);

        if (cellule == null)
        {
            return;
        }

        cellule.RetirerOccupant();
    }

    public bool DeplacerOccupant(IGrilleOccupant occupant, GrillePosition nouvellePosition)
    {
        GrilleCellule nouvelleCellule = ObtenirCellule(nouvellePosition);

        if (nouvelleCellule == null)
        {
            return false;
        }

        if (!nouvelleCellule.PeutEtreOccupee())
        {
            return false;
        }

        GrilleCellule ancienneCellule = ObtenirCellule(occupant.Position);

        if (ancienneCellule == null)
        {
            return false;
        }

        ancienneCellule.RetirerOccupant();

        nouvelleCellule.PlacerOccupant(occupant);

        occupant.DefinirPosition(nouvellePosition);

        return true;
    }
}