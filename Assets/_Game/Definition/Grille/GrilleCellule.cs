using UnityEngine;
using System;
using UnityEngine;

public class GrilleCellule
{
    public GrillePosition Position { get; }

    public bool EstTraversable { get; private set; }

    public GrilleCellule(GrillePosition position)
    {
        Position = position;
        EstTraversable = true;
    }

    public void DefinirSiTraversable(bool estTraversable)
    {
        EstTraversable = estTraversable;
    }
}