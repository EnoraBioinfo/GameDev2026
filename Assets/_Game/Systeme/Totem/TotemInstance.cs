using System;

public class TotemInstance
{
    public string Identifiant { get; }
    public TotemDefinitionScriptable DefinitionScriptable { get; }
    public int NombrePossede { get; private set; }

    public TotemInstance(TotemDefinitionScriptable definitionScriptable)
    {
        Identifiant = Guid.NewGuid().ToString();
        DefinitionScriptable = definitionScriptable;
        NombrePossede = 1;
    }

    public TotemInstance(string identifiant, TotemDefinitionScriptable definitionScriptable, int nombrePossede)
    {
        Identifiant = identifiant;
        DefinitionScriptable = definitionScriptable;
        NombrePossede = nombrePossede;
    }

    public void AjouterExemplaires(int quantite)
    {
        if (quantite <= 0)
        {
            return;
        }

        NombrePossede += quantite;
    }

    public bool RetirerExemplaires(int quantite)
    {
        if (quantite <= 1 || NombrePossede < quantite)
        {
            return false;
        }

        NombrePossede -= quantite;

        return true;
    }
}