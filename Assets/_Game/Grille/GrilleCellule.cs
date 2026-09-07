using UnityEngine;
using System;
using UnityEngine;

public class GrilleCellule
{
    public GrillePosition Position { get; }

    public bool IsWalkable { get; set; }

    public GrilleCellule(GrillePosition position)
    {
        Position = position;
        IsWalkable = true;
    }
}