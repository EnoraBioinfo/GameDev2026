using UnityEngine;

public class EnnemiStatistiques
{
    private readonly EnnemiDefinitionScriptable ennemiDefinitionScriptable;

    public int Niveau { get; private set; }
    public int PointsDeVieMaximum { get; private set; }

    public EnnemiStatistiques(EnnemiDefinitionScriptable ennemiDefinitionScriptable, int niveau)
    {
        this.ennemiDefinitionScriptable = ennemiDefinitionScriptable;
        Niveau = niveau;
        Recalculer();
    }

    public void Recalculer()
    {
        PointsDeVieMaximum = Mathf.RoundToInt(ennemiDefinitionScriptable.pointsDeVieMaximum * (1f + (Niveau -1) * 0.1f));
    }
}
