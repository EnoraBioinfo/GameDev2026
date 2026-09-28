using System;

public class TotemInstance
{
    public string Identifiant { get; }
    public TotemDefinitionScriptable DefinitionScriptable { get; }

    public TotemInstance(TotemDefinitionScriptable definitionScriptable)
    {
        Identifiant = Guid.NewGuid().ToString();
        DefinitionScriptable = definitionScriptable;
    }

    public TotemInstance(string identifiant, TotemDefinitionScriptable definitionScriptable)
    {
        Identifiant = identifiant;
        DefinitionScriptable = definitionScriptable;
    }
}