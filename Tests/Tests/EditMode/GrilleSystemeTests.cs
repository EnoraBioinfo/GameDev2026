using NUnit.Framework;
using UnityEngine;

public class GrilleSystemeTests
{
    private GrilleDefinition definition;
    private GrilleSysteme grille;

    [SetUp]
    public void SetUp()
    {
        definition = ScriptableObject.CreateInstance<GrilleDefinition>();
        definition.hauteur = 2;
        definition.largeur = 3;
        grille = new GrilleSysteme(definition);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(definition);
    }

    [Test]
    public void Grille_CreeToutesLesCellulesDansLesDimensions()
    {
        Assert.That(grille.Contains(new GrillePosition(0, 0)), Is.True);
        Assert.That(grille.Contains(new GrillePosition(1, 2)), Is.True);
        Assert.That(grille.Contains(new GrillePosition(2, 0)), Is.False);
    }

    [Test]
    public void Grille_CelluleBloqueeNestPasTraversable()
    {
        var position = new GrillePosition(1, 1);

        grille.DefinirCelluleTraversable(position, false);

        Assert.That(grille.EstTraversable(position), Is.False);
        Assert.That(grille.EstTraversable(new GrillePosition(-1, 0)), Is.False);
    }

    [Test]
    public void Grille_RefuseUnOccupantSurUneCelluleOccupee()
    {
        var position = new GrillePosition(0, 0);
        var premier = new FauxOccupant(position);
        var second = new FauxOccupant(position);

        Assert.That(grille.PlacerOccupant(premier, position), Is.True);
        Assert.That(grille.PlacerOccupant(second, position), Is.False);
        Assert.That(grille.ObtenirCellule(position).Occupant, Is.SameAs(premier));
        Assert.That(grille.PlacerOccupant(second, new GrillePosition(9, 9)), Is.False);
    }

    [Test]
    public void Grille_DeplacementReussiLibereAncienneCelluleEtMetAJourPosition()
    {
        var depart = new GrillePosition(0, 0);
        var arrivee = new GrillePosition(0, 1);
        var occupant = new FauxOccupant(depart);
        grille.PlacerOccupant(occupant, depart);

        bool deplace = grille.DeplacerOccupant(occupant, arrivee);

        Assert.That(deplace, Is.True);
        Assert.That(grille.ObtenirCellule(depart).Occupant, Is.Null);
        Assert.That(grille.ObtenirCellule(arrivee).Occupant, Is.SameAs(occupant));
        Assert.That(occupant.Position, Is.EqualTo(arrivee));
    }

    [Test]
    public void Grille_DeplacementSurCelluleOccupeeEchoueSansDeplacerLOrigine()
    {
        var depart = new GrillePosition(0, 0);
        var arrivee = new GrillePosition(0, 1);
        var occupant = new FauxOccupant(depart);
        var bloqueur = new FauxOccupant(arrivee);
        grille.PlacerOccupant(occupant, depart);
        grille.PlacerOccupant(bloqueur, arrivee);

        bool deplace = grille.DeplacerOccupant(occupant, arrivee);

        Assert.That(deplace, Is.False);
        Assert.That(grille.ObtenirCellule(depart).Occupant, Is.SameAs(occupant));
        Assert.That(occupant.Position, Is.EqualTo(depart));
    }

    private sealed class FauxOccupant : IGrilleOccupant
    {
        public GrillePosition Position { get; private set; }

        public FauxOccupant(GrillePosition position)
        {
            Position = position;
        }

        public void DefinirPosition(GrillePosition position)
        {
            Position = position;
        }
    }
}
