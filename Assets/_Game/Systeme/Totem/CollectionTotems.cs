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

    public int ObtenirNombreTotems()
    {
        return totems.Count;
    }

    public List<TotemInstance> ObtenirTotems(TotemDefinitionScriptable definitionScriptable)
    {
        return totems
            .Where(totem => totem.DefinitionScriptable == definitionScriptable)
            .ToList();
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
        return totems.Count(totem => totem.DefinitionScriptable == definitionScriptable);
    }

    public bool ContientTotem(TotemInstance totem)
    {
        return totems.Contains(totem);
    }
}