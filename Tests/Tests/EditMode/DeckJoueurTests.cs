using NUnit.Framework;
using UnityEngine;

public class DeckJoueurTests
{
    private ReglesDeckScriptable regles;
    private CarteDefinitionScriptable definition;
    private DeckJoueur deck;

    [SetUp]
    public void SetUp()
    {
        regles = ScriptableObject.CreateInstance<ReglesDeckScriptable>();
        regles.nombreMinimumCartes = 2;
        regles.nombreMaximumCartes = 3;
        regles.nombreMaximumMemeCarte = 2;

        definition = ScriptableObject.CreateInstance<CarteDefinitionScriptable>();
        definition.niveauMaximum = 3;

        deck = new DeckJoueur(regles, "Deck de test");
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(regles);
        Object.DestroyImmediate(definition);
    }

    [Test]
    public void Deck_RefuseLaMemeInstanceDeuxFois()
    {
        var carte = new CarteInstance(definition, 1);

        Assert.That(deck.AjouterCarte(carte), Is.True);
        Assert.That(deck.AjouterCarte(carte), Is.False);
        Assert.That(deck.ObtenirNombreCartes(), Is.EqualTo(1));
    }

    [Test]
    public void Deck_RespecteLaLimiteDeCopiesDUneDefinition()
    {
        Assert.That(deck.AjouterCarte(new CarteInstance(definition, 1)), Is.True);
        Assert.That(deck.AjouterCarte(new CarteInstance(definition, 2)), Is.True);
        Assert.That(deck.AjouterCarte(new CarteInstance(definition, 3)), Is.False);
    }

    [Test]
    public void Deck_RespecteLaTailleMaximum()
    {
        var autreDefinition = ScriptableObject.CreateInstance<CarteDefinitionScriptable>();
        autreDefinition.niveauMaximum = 3;

        try
        {
            Assert.That(deck.AjouterCarte(new CarteInstance(definition, 1)), Is.True);
            Assert.That(deck.AjouterCarte(new CarteInstance(definition, 2)), Is.True);
            Assert.That(deck.AjouterCarte(new CarteInstance(autreDefinition, 1)), Is.True);
            Assert.That(deck.AjouterCarte(new CarteInstance(autreDefinition, 2)), Is.False);
            Assert.That(deck.ObtenirNombreCartes(), Is.EqualTo(3));
        }
        finally
        {
            Object.DestroyImmediate(autreDefinition);
        }
    }

    [Test]
    public void Deck_EstValideSeulementDansLesBornesDefinies()
    {
        Assert.That(deck.EstValide(), Is.False);

        deck.AjouterCarte(new CarteInstance(definition, 1));
        deck.AjouterCarte(new CarteInstance(definition, 2));

        Assert.That(deck.EstValide(), Is.True);
    }

    [Test]
    public void Deck_RefuseCarteNulleEtRenommageVide()
    {
        Assert.That(deck.AjouterCarte(null), Is.False);

        deck.Renommer("   ");

        Assert.That(deck.Nom, Is.EqualTo("Deck de test"));
    }
}
