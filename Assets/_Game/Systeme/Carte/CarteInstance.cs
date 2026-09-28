using System;

public class CarteInstance
{
    public string Identifiant { get; }
    public CarteDefinitionScriptable Definition { get; }
    public int Niveau { get; private set; }

    public CarteInstance(CarteDefinitionScriptable definition, int niveau)
    {
        Identifiant = Guid.NewGuid().ToString();
        Definition = definition;
        Niveau = niveau;
    }

    public CarteInstance(string identifiant, CarteDefinitionScriptable definition, int niveau)
    {
        Identifiant = identifiant;
        Definition = definition;
        Niveau = niveau;
    }
}