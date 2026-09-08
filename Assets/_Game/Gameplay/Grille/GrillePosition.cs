using UnityEngine;
using System;
using UnityEngine;

[Serializable]
public struct GrillePosition : IEquatable<GrillePosition>
{
    public int x;
    public int y;

    public GrillePosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool Equals(GrillePosition other)
    {
        return x == other.x && y == other.y;
    }

    public override bool Equals(object obj)
    {
        return obj is GrillePosition other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }

    public static bool operator ==(
        GrillePosition a,
        GrillePosition b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(
        GrillePosition a,
        GrillePosition b)
    {
        return !a.Equals(b);
    }

    public override string ToString()
    {
        return $"({x}, {y})";
    }
}