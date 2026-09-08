using UnityEngine;
using System;
using UnityEngine;

public class GrilleCellule
{
    public GrillePosition Position { get; }

    public bool estDisponible { get; set; }

    public GrilleCellule(GrillePosition position)
    {
        Position = position;
        estDisponible = true;
    }
}