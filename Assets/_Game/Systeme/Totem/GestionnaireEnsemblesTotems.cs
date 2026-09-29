using System.Collections.Generic;

public class GestionnaireEnsemblesTotems
{
    private readonly List<EnsembleTotemJoueur> ensemblesTotems;
    private readonly ReglesEnsembleTotemScriptable reglesEnsembleTotem;

    private int indexEnsembleTotemSelectionne;
    public int IndexEnsembleTotemSelectionne => indexEnsembleTotemSelectionne;

    public IReadOnlyList<EnsembleTotemJoueur> EnsemblesTotems => ensemblesTotems;
    public EnsembleTotemJoueur EnsembleTotemSelectionne => ObtenirEnsembleTotemSelectionne();

    public GestionnaireEnsemblesTotems(ReglesEnsembleTotemScriptable reglesEnsembleTotem, int nombreEnsemblesTotems)
    {
        this.reglesEnsembleTotem = reglesEnsembleTotem;
        ensemblesTotems = new List<EnsembleTotemJoueur>();
        indexEnsembleTotemSelectionne = 0;

        for (int i = 0; i < nombreEnsemblesTotems; i++)
        {
            CreerEnsembleTotem($"EnsembleTotem {i + 1}");
        }
    }

    public EnsembleTotemJoueur CreerEnsembleTotem(string nom)
    {
        if (reglesEnsembleTotem == null)
        {
            return null;
        }

        if (string.IsNullOrWhiteSpace(nom))
        {
            return null;
        }

        EnsembleTotemJoueur ensembleTotem = new EnsembleTotemJoueur(reglesEnsembleTotem, nom);

        ensemblesTotems.Add(ensembleTotem);

        return ensembleTotem;
    }

    public bool SupprimerEnsembleTotem(EnsembleTotemJoueur ensembleTotem)
    {
        if (ensembleTotem == null)
        {
            return false;
        }

        if (!ensemblesTotems.Contains(ensembleTotem))
        {
            return false;
        }

        if (ensemblesTotems.Count <= 1)
        {
            return false;
        }

        int indexEnsembleTotem = ensemblesTotems.IndexOf(ensembleTotem);

        ensemblesTotems.Remove(ensembleTotem);

        if (indexEnsembleTotemSelectionne > indexEnsembleTotem)
        {
            indexEnsembleTotemSelectionne--;
        }
        else if (indexEnsembleTotemSelectionne == indexEnsembleTotem && indexEnsembleTotemSelectionne >= ensemblesTotems.Count)
        {
            indexEnsembleTotemSelectionne = ensemblesTotems.Count - 1;
        }

        return true;
    }

    public bool RenommerEnsembleTotem(EnsembleTotemJoueur ensembleTotem, string nouveauNom)
    {
        if (ensembleTotem == null)
        {
            return false;
        }

        if (!ensemblesTotems.Contains(ensembleTotem))
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(nouveauNom))
        {
            return false;
        }

        ensembleTotem.Renommer(nouveauNom);

        return true;
    }

    public EnsembleTotemJoueur ObtenirEnsembleTotem(int index)
    {
        if (index < 0 || index >= ensemblesTotems.Count)
        {
            return null;
        }

        return ensemblesTotems[index];
    }

    public EnsembleTotemJoueur ObtenirEnsembleTotemSelectionne()
    {
        return ObtenirEnsembleTotem(indexEnsembleTotemSelectionne);
    }

    public bool SelectionnerEnsembleTotem(int index)
    {
        if (index < 0 || index >= ensemblesTotems.Count)
        {
            return false;
        }

        indexEnsembleTotemSelectionne = index;

        return true;
    }

    public int ObtenirNombreEnsemblesTotems()
    {
        return ensemblesTotems.Count;
    }

    public bool AjouterTotemAEnsembleTotem(EnsembleTotemJoueur ensembleTotem, TotemInstance totem)
    {
        if (ensembleTotem == null || totem == null)
        {
            return false;
        }

        if (!ensemblesTotems.Contains(ensembleTotem))
        {
            return false;
        }

        return ensembleTotem.AjouterTotem(totem);
    }

    public void ViderEnsemblesTotems()
    {
        ensemblesTotems.Clear();
        indexEnsembleTotemSelectionne = 0;
    }
}