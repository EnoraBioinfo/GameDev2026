using UnityEngine;

public class EnnemiAttaqueStatistiques
{
    public AttaqueEnnemiDefinitionScriptable Definition { get; }
    public int Degats { get; }
    public int Soin { get; }
    public int Protection { get; }
    public int PorteeMinimum { get; }
    public int PorteeMaximum { get; }

    public EnnemiAttaqueStatistiques(AttaqueEnnemiDefinitionScriptable definition, int niveau)
    {
        Definition = definition;
        Degats = CalculSelonNiveau(definition.degats, niveau);
        Soin = CalculSelonNiveau(definition.soin, niveau);
        Protection = CalculSelonNiveau(definition.protection, niveau);
        PorteeMinimum = definition.porteeMinimum;
        PorteeMaximum = definition.porteeMaximum;
    }

    private int CalculSelonNiveau(int montantBase, int niveau)
    {
        return Mathf.RoundToInt(montantBase * (1f + (niveau - 1) * 0.1f));
    }
}
