using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SystemeFusionCartesTests
{
    private ReglesFusionCartesScriptable regles;
    private CarteDefinitionScriptable definition;
    private CollectionCartes collection;
    private SystemeFusionCartes fusion;

    [SetUp]
    public void SetUp()
    {
        regles = ScriptableObject.CreateInstance<ReglesFusionCartesScriptable>();
        regles.valeursFusion.Add(new ValeurFusionCarte { niveau = 1, points = 1 });
        regles.coutsEvolution.Add(new CoutEvolutionCarte { niveau = 1, pointsNecessaires = 1 });
        regles.coutsEvolution.Add(new CoutEvolutionCarte { niveau = 2, pointsNecessaires = 2 });

        definition = ScriptableObject.CreateInstance<CarteDefinitionScriptable>();
        definition.niveauMaximum = 2;

        collection = new CollectionCartes();
        fusion = new SystemeFusionCartes(regles);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(regles);
        Object.DestroyImmediate(definition);
    }

    [Test]
    public void FusionnerDeuxCartesIdentiques_CreeLeNiveauCorrespondantEtRemplaceLesIngredients()
    {
        var premiere = new CarteInstance("carte-1", definition, 1);
        var seconde = new CarteInstance("carte-2", definition, 1);
        collection.AjouterCarte(premiere);
        collection.AjouterCarte(seconde);

        CarteInstance resultat = fusion.Fusionner(collection, new List<CarteInstance> { premiere, seconde });

        Assert.That(resultat, Is.Not.Null);
        Assert.That(resultat.Niveau, Is.EqualTo(2));
        Assert.That(collection.ObtenirNombreCartes(), Is.EqualTo(1));
        Assert.That(collection.ContientCarte(resultat), Is.True);
        Assert.That(collection.ContientCarte(premiere), Is.False);
        Assert.That(collection.ContientCarte(seconde), Is.False);
    }

    [Test]
    public void FusionnerCartesDeDefinitionsDifferentes_EchoueSansModifierCollection()
    {
        var autreDefinition = ScriptableObject.CreateInstance<CarteDefinitionScriptable>();
        var premiere = new CarteInstance("carte-1", definition, 1);
        var seconde = new CarteInstance("carte-2", autreDefinition, 1);
        collection.AjouterCarte(premiere);
        collection.AjouterCarte(seconde);

        try
        {
            CarteInstance resultat = fusion.Fusionner(collection, new List<CarteInstance> { premiere, seconde });

            Assert.That(resultat, Is.Null);
            Assert.That(collection.ObtenirNombreCartes(), Is.EqualTo(2));
            Assert.That(collection.ContientCarte(premiere), Is.True);
            Assert.That(collection.ContientCarte(seconde), Is.True);
        }
        finally
        {
            Object.DestroyImmediate(autreDefinition);
        }
    }

    [Test]
    public void PeutFusionner_RefuseUneListeVideEtUneCarteNulle()
    {
        Assert.That(fusion.PeutFusionner(new List<CarteInstance>(), out _), Is.False);
        Assert.That(fusion.PeutFusionner(new List<CarteInstance> { null }, out _), Is.False);
    }
}
