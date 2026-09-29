using System.Collections.Generic;
using UnityEngine;

public class GestionnaireTotems : MonoBehaviour
{
    [SerializeField]
    private ReglesEnsembleTotemScriptable reglesEnsembleTotem;

    [SerializeField]
    private GestionnaireProgression gestionnaireProgression;

    [SerializeField]
    private int nombreEnsemblesTotems = 2;

    private CollectionTotems collection;
    private GestionnaireEnsemblesTotems gestionnaireEnsemblesTotems;

    public CollectionTotems Collection => collection;
    public GestionnaireEnsemblesTotems GestionnaireEnsemblesTotems => gestionnaireEnsemblesTotems;
    public EnsembleTotemJoueur EnsembleTotemSelectionne => gestionnaireEnsemblesTotems?.EnsembleTotemSelectionne;

    public void Initialiser()
    {
        collection = new CollectionTotems();
        gestionnaireEnsemblesTotems = new GestionnaireEnsemblesTotems(reglesEnsembleTotem, nombreEnsemblesTotems);
    }

    public TotemInstance AjouterTotemAvecIdentifiant(string identifiant, TotemDefinitionScriptable definitionScriptable, int nombrePossede)
    {
        if (definitionScriptable == null)
        {
            return null;
        }

        if (string.IsNullOrEmpty(identifiant))
        {
            return null;
        }

        TotemInstance totem = new TotemInstance(identifiant, definitionScriptable, nombrePossede);

        collection.AjouterTotem(totem);

        return totem;
    }

    public bool AjouterTotem(TotemDefinitionScriptable definitionScriptable)
    {
        if (definitionScriptable == null)
        {
            return false;
        }

        TotemInstance totem = collection.ObtenirTotem(definitionScriptable);

        if (totem != null)
        {
            totem.AjouterExemplaires(1);
            return true;
        }

        totem = new TotemInstance(definitionScriptable);

        collection.AjouterTotem(totem);

        return true;
    }

    public bool AjouterTotemAEnsembleTotem(TotemInstance totem)
    {
        if (gestionnaireEnsemblesTotems == null || totem == null)
        {
            return false;
        }

        if (!collection.ContientTotem(totem))
        {
            return false;
        }

        EnsembleTotemJoueur ensembleTotem = gestionnaireEnsemblesTotems.EnsembleTotemSelectionne;

        if (ensembleTotem == null)
        {
            return false;
        }

        return ensembleTotem.AjouterTotem(totem);
    }

    public bool RetirerTotemAEnsembleTotem(TotemInstance totem)
    {
        if (gestionnaireEnsemblesTotems == null)
        {
            return false;
        }

        EnsembleTotemJoueur ensembleTotem = gestionnaireEnsemblesTotems.EnsembleTotemSelectionne;

        if (ensembleTotem == null)
        {
            return false;
        }

        return ensembleTotem.RetirerTotem(totem);
    }

    public bool SelectionnerEnsembleTotem(int index)
    {
        if (gestionnaireEnsemblesTotems == null)
        {
            return false;
        }

        return gestionnaireEnsemblesTotems.SelectionnerEnsembleTotem(index);
    }

    public bool Vendre1Totem(TotemInstance totem)
    {
        if (totem == null || collection == null || gestionnaireProgression == null)
        {
            return false;
        }

        if (totem.NombrePossede <= 1)
        {
            return false;
        }

        if (!totem.RetirerExemplaires(1))
        {
            return false;
        }

        int prixEnPieces = totem.DefinitionScriptable.prixDeVentePiece;
        gestionnaireProgression.AjouterPieces(prixEnPieces);
        
        int prixEnDimants = totem.DefinitionScriptable.prixDeVenteDiamant;
        gestionnaireProgression.AjouterDiamants(prixEnDimants);

        return true;
    }

    public int VendrePlusieursTotems(TotemInstance totem, int nombreAVendre)
    {
        if(totem == null || nombreAVendre == null)
        {
            return 0;
        }

        int nombreVendu = 0;

        while (nombreVendu < nombreAVendre && totem.NombrePossede > 1)
        {
            if (!Vendre1Totem(totem)) { break; }
            nombreVendu++;
        }

        return nombreVendu;
    }
}