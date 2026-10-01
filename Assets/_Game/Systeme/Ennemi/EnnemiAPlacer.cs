using UnityEngine;

[System.Serializable]
public class EnnemiAPlacer
{
    public EnnemiDefinitionScriptable ennemiDefinitionScriptable;
    public int niveau = 1;
    
    [Min(1)]
    public int nombreAPlacer = 1;
}