using System.Collections.Generic;
using System.Linq;

public class EnsembleTotemJoueur
{
   
    private readonly List<TotemInstance> totems;
    private readonly ReglesEnsembleTotemScriptable reglesEnsembleTotem;
    public string Nom { get; private set; }

    public IReadOnlyList<TotemInstance> Totems => totems;

    public EnsembleTotemJoueur(ReglesEnsembleTotemScriptable reglesEnsembleTotem, string nom)
    {
        totems = new List<TotemInstance>();
        this.reglesEnsembleTotem = reglesEnsembleTotem;
        Nom = nom;
    }

    public void Renommer(string nouveauNom)
    {
        if (string.IsNullOrWhiteSpace(nouveauNom))
        {
            return;
        }

        Nom = nouveauNom;
    }

    public bool PeutAjouterTotem(TotemInstance totem)
    {
        if (reglesEnsembleTotem == null || totem == null)
        {
            return false;
        }

        if (totems.Contains(totem))
        {
            return false;
        }

        if (ObtenirNombreTotems() >= reglesEnsembleTotem.nombreMaximumTotems)
        {
            return false;
        }

        return !TotemDejaEquipe(totem.DefinitionScriptable);
    }

    public bool AjouterTotem(TotemInstance totem)
    {
        if (!PeutAjouterTotem(totem))
        {
            return false;
        }

        totems.Add(totem);

        return true;
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

    public bool TotemDejaEquipe(TotemDefinitionScriptable definitionScriptable)
    {
        return totems.Count(totem => totem.DefinitionScriptable == definitionScriptable) > 0;
    }

    public bool EstValide()
    {
        if (reglesEnsembleTotem == null)
        {
            return false;
        }

        return totems.Count <= reglesEnsembleTotem.nombreMaximumTotems;
    }
}