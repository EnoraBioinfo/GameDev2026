using System;

public class CarteInstance
{
    public string Identifiant { get; }
    public CarteDefinition Definition { get; }
    public int Niveau { get; private set; }

    public CarteInstance(CarteDefinition definition, int niveau)
    {
        Identifiant = Guid.NewGuid().ToString();
        Definition = definition;
        Niveau = niveau;
    }

    public CarteInstance(string identifiant, CarteDefinition definition, int niveau)
    {
        Identifiant = identifiant;
        Definition = definition;
        Niveau = niveau;
    }
}