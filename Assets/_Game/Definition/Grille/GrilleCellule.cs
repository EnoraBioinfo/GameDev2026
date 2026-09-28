using UnityEngine;
using System;

public class GrilleCellule
{
    public GrillePosition Position { get; }

    public bool EstTraversable { get; private set; }

    public IGrilleOccupant Occupant { get; private set; }

    public GrilleCellule(GrillePosition position)
    {
        Position = position;
        EstTraversable = true;
        Occupant = null;
    }

    public void DefinirSiTraversable(bool estTraversable)
    {
        EstTraversable = estTraversable;
    }

    public bool EstOccupee()
    {
        return Occupant != null;
    }

    public bool PeutEtreOccupee()
    {
        return EstTraversable && !EstOccupee();
    }

    public bool PlacerOccupant(IGrilleOccupant occupant)
    {
        if (!PeutEtreOccupee())
        {
            return false;
        }

        Occupant = occupant;

        return true;
    }

    public void RetirerOccupant()
    {
        Occupant = null;
    }
}