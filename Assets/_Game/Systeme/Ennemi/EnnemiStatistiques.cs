using System.Collections.Generic;
using UnityEngine;

public class EnnemiStatistiques
{
    private readonly EnnemiDefinitionScriptable ennemiDefinitionScriptable;

    public int Niveau { get; private set; }
    public int PointsDeVieMaximum { get; private set; }
    public int RecompenseOr { get; private set; }
    public int Protection { get; private set; }
    public List<EnnemiAttaqueStatistiques> Attaques { get; private set; }

    public EnnemiStatistiques(EnnemiDefinitionScriptable ennemiDefinitionScriptable, int niveau)
    {
        this.ennemiDefinitionScriptable = ennemiDefinitionScriptable;
        Niveau = niveau;
        Recalculer();
    }

    public void Recalculer()
    {
        PointsDeVieMaximum = CalculSelonNiveau(ennemiDefinitionScriptable.pointsDeVieMaximum);
        RecompenseOr = CalculSelonNiveau(ennemiDefinitionScriptable.recompenseOr);
        Protection = CalculSelonNiveau(ennemiDefinitionScriptable.protection);

        Attaques = new List<EnnemiAttaqueStatistiques>();
        foreach (AttaqueEnnemiDefinitionScriptable attaque in ennemiDefinitionScriptable.attaques)
        {
            Attaques.Add(new EnnemiAttaqueStatistiques(attaque, Niveau));
        }
    }

    private int CalculSelonNiveau(int montantBase)
    {
        return Mathf.RoundToInt(montantBase * (1f + (Niveau - 1) * 0.1f));
    }
}
