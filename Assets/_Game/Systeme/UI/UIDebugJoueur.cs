using System.Text;
using TMPro;
using UnityEngine;

public class UIDebugJoueur : MonoBehaviour
{
    [Header("Gestionnaires")]
    [SerializeField]
    private GestionnaireProgression gestionnaireProgression;

    [SerializeField]
    private GestionnaireCartes gestionnaireCartes;

    [SerializeField]
    private GestionnaireTotems gestionnaireTotems;

    [SerializeField]
    private GestionnaireJoueur gestionnaireJoueur;

    [Header("Textes")]
    [SerializeField]
    private TMP_Text texteProgression;

    [SerializeField]
    private TMP_Text texteCartes;

    [SerializeField]
    private TMP_Text texteTotems;

    [SerializeField]
    private TMP_Text texteEnsemblesTotems;

    private void Start()
    {
        Actualiser();
    }

    public void Actualiser()
    {
        ActualiserProgression();
        ActualiserCartes();
        ActualiserTotems();
        ActualiserEnsemblesTotems();
    }

    private void ActualiserProgression()
    {
        if (gestionnaireProgression == null || texteProgression == null || gestionnaireJoueur == null)
        {
            return;
        }

        ProgressionJoueur progression = gestionnaireProgression.Progression;
        JoueurEtat joueurEtat = gestionnaireJoueur.JoueurEtat;

        StringBuilder texte = new StringBuilder();

        texte.AppendLine("=== PROGRESSION ===");
        texte.AppendLine($"Niveau : {progression.Niveau}");
        texte.AppendLine($"Experience : {progression.Experience}");
        texte.AppendLine($"Pieces : {progression.Pieces}");
        texte.AppendLine($"Diamants : {progression.Diamants}");

        texte.AppendLine("=== JOUEUR ===");
        texte.AppendLine($"Mouvement : {joueurEtat.PointsMouvementsRestants}");
        texte.AppendLine($"Segment : {joueurEtat.SegmentsActionsRestants}");
        texte.AppendLine($"Vie : {joueurEtat.PointsDeVieActuels}");


        texteProgression.text = texte.ToString();
    }

    private void ActualiserCartes()
    {
        if (gestionnaireCartes == null || gestionnaireCartes.Collection == null || texteCartes == null)
        {
            return;
        }

        StringBuilder texte = new StringBuilder();

        texte.AppendLine("=== CARTES ===");

        foreach (CarteInstance carte in gestionnaireCartes.Collection.Cartes)
        {
            texte.AppendLine($"{carte.Definition.identifiant} - Niveau {carte.Niveau}");
        }

        texte.AppendLine();
        texte.AppendLine($"Nombre de cartes : {gestionnaireCartes.Collection.ObtenirNombreCartes()}");

        texteCartes.text = texte.ToString();
    }

    private void ActualiserTotems()
    {
        if (gestionnaireTotems == null || gestionnaireTotems.Collection == null || texteTotems == null)
        {
            return;
        }

        StringBuilder texte = new StringBuilder();

        texte.AppendLine("=== TOTEMS ===");

        foreach (TotemInstance totem in gestionnaireTotems.Collection.Totems)
        {
            texte.AppendLine($"{totem.DefinitionScriptable.identifiant} x{totem.NombrePossede}");
        }

        texte.AppendLine();
        texte.AppendLine($"Nombre de types de totems : {gestionnaireTotems.Collection.ObtenirNombreTotemsTotal()}");

        texteTotems.text = texte.ToString();
    }

    private void ActualiserEnsemblesTotems()
    {
        if (gestionnaireTotems == null || texteEnsemblesTotems == null)
        {
            return;
        }

        StringBuilder texte = new StringBuilder();

        texte.AppendLine("=== ENSEMBLES DE TOTEMS ===");

        for (int i = 0; i < gestionnaireTotems.GestionnaireEnsemblesTotems.ObtenirNombreEnsemblesTotems(); i++)
        {
            EnsembleTotemJoueur ensembleTotem = gestionnaireTotems.GestionnaireEnsemblesTotems.ObtenirEnsembleTotem(i);

            if (ensembleTotem == null)
            {
                continue;
            }

            texte.AppendLine();
            texte.AppendLine($"{ensembleTotem.Nom}");

            foreach (TotemInstance totem in ensembleTotem.Totems)
            {
                texte.AppendLine($"- {totem.DefinitionScriptable.identifiant}");
            }
        }

        texte.AppendLine();
        texte.AppendLine($"Ensemble selectionne : {gestionnaireTotems.GestionnaireEnsemblesTotems.IndexEnsembleTotemSelectionne}");

        texteEnsemblesTotems.text = texte.ToString();
    }
}