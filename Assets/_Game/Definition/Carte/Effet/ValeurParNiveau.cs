using System;
using UnityEngine;

[Serializable]
public class ValeurParNiveau
{
    [Min(1)]
    public int niveau = 1;

    [Min(0)]
    public int valeur;
}