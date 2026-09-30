using UnityEngine;

[System.Serializable]
public class DropTotemEnnemi
{
    public TotemDefinitionScriptable totem;

    [Range(0, 100)]
    public int pourcentageDrop;
}
