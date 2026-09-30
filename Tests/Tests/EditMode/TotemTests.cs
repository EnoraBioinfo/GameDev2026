using System.Reflection;
using NUnit.Framework;
using UnityEngine;

public class TotemTests
{
    private ReglesEnsembleTotemScriptable regles;
    private TotemDefinitionScriptable definition;

    [SetUp]
    public void SetUp()
    {
        regles = ScriptableObject.CreateInstance<ReglesEnsembleTotemScriptable>();
        regles.nombreMaximumTotems = 2;

        definition = ScriptableObject.CreateInstance<TotemDefinitionScriptable>();
        definition.prixDeVentePiece = 5;
        definition.prixDeVenteDiamant = 1;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(regles);
        Object.DestroyImmediate(definition);
    }

    [Test]
    public void Ensemble_RefuseDeuxExemplairesDuMemeType()
    {
        var ensemble = new EnsembleTotemJoueur(regles, "Ensemble test");
        var premier = new TotemInstance("totem-1", definition, 1);
        var second = new TotemInstance("totem-2", definition, 1);

        Assert.That(ensemble.AjouterTotem(premier), Is.True);
        Assert.That(ensemble.AjouterTotem(second), Is.False);
        Assert.That(ensemble.ObtenirNombreTotems(), Is.EqualTo(1));
    }

    [Test]
    public void Ensemble_RespecteLeNombreMaximumDeTotems()
    {
        var ensemble = new EnsembleTotemJoueur(regles, "Ensemble test");
        var autreDefinition = ScriptableObject.CreateInstance<TotemDefinitionScriptable>();

        try
        {
            Assert.That(ensemble.AjouterTotem(new TotemInstance("totem-1", definition, 1)), Is.True);
            Assert.That(ensemble.AjouterTotem(new TotemInstance("totem-2", autreDefinition, 1)), Is.True);
            Assert.That(ensemble.AjouterTotem(new TotemInstance("totem-3", definition, 1)), Is.False);
        }
        finally
        {
            Object.DestroyImmediate(autreDefinition);
        }
    }

    [Test]
    public void VenteConserveUnExemplaireEtCrediteLesMonnaies()
    {
        var progressionObject = new GameObject("Progression de test");
        var totemsObject = new GameObject("Gestionnaire de totems de test");

        try
        {
            var progression = progressionObject.AddComponent<GestionnaireProgression>();
            progression.Initialiser();

            var gestionnaire = totemsObject.AddComponent<GestionnaireTotems>();
            SetPrivateField(gestionnaire, "reglesEnsembleTotem", regles);
            SetPrivateField(gestionnaire, "gestionnaireProgression", progression);
            SetPrivateField(gestionnaire, "nombreEnsemblesTotems", 1);
            gestionnaire.Initialiser();

            gestionnaire.AjouterTotem(definition);
            gestionnaire.AjouterTotem(definition);
            gestionnaire.AjouterTotem(definition);
            TotemInstance totem = gestionnaire.Collection.ObtenirTotem(definition);

            Assert.That(gestionnaire.VendrePlusieursTotems(totem, 5), Is.EqualTo(2));
            Assert.That(totem.NombrePossede, Is.EqualTo(1));
            Assert.That(progression.Pieces, Is.EqualTo(10));
            Assert.That(progression.Diamants, Is.EqualTo(2));
            Assert.That(gestionnaire.Vendre1Totem(totem), Is.False);
        }
        finally
        {
            Object.DestroyImmediate(progressionObject);
            Object.DestroyImmediate(totemsObject);
        }
    }

    private static void SetPrivateField(object target, string fieldName, object value)
    {
        FieldInfo field = target.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        Assert.That(field, Is.Not.Null, $"Champ privé introuvable : {fieldName}");
        field.SetValue(target, value);
    }
}
