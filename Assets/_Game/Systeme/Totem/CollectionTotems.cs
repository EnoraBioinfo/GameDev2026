using System.Collections.Generic;
using System.Linq;

public class CollectionTotems
{
    private readonly List<TotemInstance> totems;

    public IReadOnlyList<TotemInstance> Totems => totems;

    public CollectionTotems()
    {
        totems = new List<TotemInstance>();
    }

    public void AjouterTotem(TotemInstance totem)
    {
        if (totem == null)
        {
            return;
        }

        totems.Add(totem);
    }

    public bool RetirerTotem(TotemInstance totem)
    {
        if (totem == null)
        {
            return false;
        }

        return totems.Remove(totem);
    }

    public int ObtenirNombreTotemsTotal()
    {
        return totems.Count;
    }

    public TotemInstance ObtenirTotem(TotemDefinitionScriptable definitionScriptable)
    {
        if (definitionScriptable == null)
        {
            return null;
        }

        return totems.FirstOrDefault(totem => totem.DefinitionScriptable == definitionScriptable);
    }

    public TotemInstance ObtenirTotem(string identifiant)
    {
        if (string.IsNullOrEmpty(identifiant))
        {
            return null;
        }

        return totems.FirstOrDefault(totem => totem.Identifiant == identifiant);
    }

    public int ObtenirNombreTotems(TotemDefinitionScriptable definitionScriptable)
    {
        TotemInstance totem = totems.FirstOrDefault(totem => totem.DefinitionScriptable == definitionScriptable);

        if (totem == null)
        {
            return 0;
        }

        return totem.NombrePossede;
    }

    public int ObtenirNombreTotems(TotemInstance totem)
    {
        if (totem == null || !totems.Contains(totem))
        {
            return 0;
        }

        return totem.NombrePossede;
    }

    public bool ContientTotem(TotemInstance totem)
    {
        return totems.Contains(totem);
    }
}