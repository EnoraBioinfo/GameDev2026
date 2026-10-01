using System.Collections.Generic;
using UnityEngine;

public class EnnemiStatistiques
{
    private readonly EnnemiDefinitionScriptable ennemiDefinitionScriptable;
    public string Nom => ennemiDefinitionScriptable.nom;
    public int Niveau { get; private set; }
    public int PointsDeVieMaximum { get; private set; }
    public int NombreActions { get; private set; }
    public int RecompenseOr { get; private set; }
    public int Protection { get; private set; }
    public List<DropTotemEnnemi> DropTotemEnnemi { get; private set; }
    public List<EnnemiAttaqueStatistiques> Attaques { get; private set; }

    public EnnemiStatistiques(EnnemiDefinitionScriptable ennemiDefinitionScriptable, int niveau)
    {
        this.ennemiDefinitionScriptable = ennemiDefinitionScriptable;
        Niveau = niveau;
        Recalculer();
    }

    public void Recalculer()
    {
        NombreActions = ennemiDefinitionScriptable.nombreActions;

        PointsDeVieMaximum = CalculSelonNiveau(ennemiDefinitionScriptable.pointsDeVieMaximum);
        RecompenseOr = CalculSelonNiveau(ennemiDefinitionScriptable.recompenseOr);
        Protection = CalculSelonNiveau(ennemiDefinitionScriptable.protection);

        DropTotemEnnemi = new List<DropTotemEnnemi>();
        foreach (DropTotemEnnemi dropTotem in ennemiDefinitionScriptable.dropsTotems)
        {
            int pourcentageDrop = CalculSelonNiveau(dropTotem.pourcentageDrop);
        }

        Attaques = new List<EnnemiAttaqueStatistiques>();
        foreach (AttaqueEnnemiDefinitionScriptable attaque in ennemiDefinitionScriptable.attaques)
        {
            Attaques.Add(new EnnemiAttaqueStatistiques(attaque, Niveau));
        }
    }

    private int CalculSelonNiveau(int montantBase)
    {
        return Mathf.Min(100, Mathf.RoundToInt(montantBase * (1f + (Niveau - 1) * 0.1f)));
    }
}
