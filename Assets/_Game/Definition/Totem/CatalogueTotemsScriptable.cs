using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "CatalogueTotems",
    menuName = "Jeu/Totems/Catalogue des totems"
)]
public class CatalogueTotemsScriptable : ScriptableObject
{
    [Header("Totems disponibles")]
    public List<TotemDefinitionScriptable> totems = new List<TotemDefinitionScriptable>();

    public TotemDefinitionScriptable ObtenirTotem(string identifiant)
    {
        if (string.IsNullOrEmpty(identifiant))
        {
            return null;
        }

        foreach (TotemDefinitionScriptable totem in totems)
        {
            if (totem == null)
            {
                continue;
            }

            if (totem.identifiant == identifiant)
            {
                return totem;
            }
        }

        return null;
    }
}