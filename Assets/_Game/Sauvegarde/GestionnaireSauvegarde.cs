using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GestionnaireSauvegarde : MonoBehaviour
{
    private const string NomFichierSauvegarde = "sauvegarde.json";

    [SerializeField]
    private GestionnaireCartes gestionnaireCartes;

    [SerializeField]
    private CatalogueCartesScriptable catalogueCartesScriptable;

    [SerializeField]
    private GestionnaireTotems gestionnaireTotems;

    [SerializeField]
    private CatalogueTotemsScriptable catalogueTotemsScriptable;

    [SerializeField]
    private GestionnaireProgression gestionnaireProgression;

    private string CheminSauvegarde => Path.Combine(
        Application.persistentDataPath,
        NomFichierSauvegarde);

    public void Sauvegarder()
    {
        if (gestionnaireCartes == null || gestionnaireTotems == null || gestionnaireProgression == null)
        {
            Debug.LogError("Gestionnaires non configurés.");
            return;
        }

        if (catalogueCartesScriptable == null || catalogueTotemsScriptable == null)
        {
            Debug.LogError("Catalogues non configurés.");
            return;
        }

        JoueurSauvegarde sauvegarde = CreerSauvegarde();

        string json = JsonUtility.ToJson(sauvegarde, true);

        File.WriteAllText(CheminSauvegarde, json);

        Debug.Log($"Sauvegarde effectuée : {CheminSauvegarde}");
    }

    public void Charger()
    {
        if (gestionnaireCartes == null || gestionnaireTotems == null || gestionnaireProgression == null)
        {
            Debug.LogError("Gestionnaires non configurés.");
            return;
        }

        if (catalogueCartesScriptable == null || catalogueTotemsScriptable == null)
        {
            Debug.LogError("Catalogues non configurés.");
            return;
        }

        if (!File.Exists(CheminSauvegarde))
        {
            Debug.Log("Aucune sauvegarde trouvée.");
            return;
        }

        string json = File.ReadAllText(CheminSauvegarde);

        JoueurSauvegarde sauvegarde = JsonUtility.FromJson<JoueurSauvegarde>(json);

        if (sauvegarde == null)
        {
            Debug.LogError("Impossible de lire la sauvegarde.");
            return;
        }

        ChargerSauvegarde(sauvegarde);

        Debug.Log("Sauvegarde chargée.");
    }

    private JoueurSauvegarde CreerSauvegarde()
    {
        JoueurSauvegarde sauvegarde = new JoueurSauvegarde();

        SauvegarderCollection(sauvegarde);
        SauvegarderDecks(sauvegarde);
        SauvegarderTotems(sauvegarde);
        SauvegarderEnsemblesTotems(sauvegarde);
        SauvegarderProgression(sauvegarde);

        return sauvegarde;
    }

    private void SauvegarderProgression(JoueurSauvegarde sauvegarde)
    {
        sauvegarde.progression = gestionnaireProgression.CreerSauvegarde();
    }

    private void SauvegarderCollection(JoueurSauvegarde sauvegarde)
    {
        foreach (CarteInstance carte in gestionnaireCartes.Collection.Cartes)
        {
            CarteSauvegarde carteSauvegarde = new CarteSauvegarde();

            carteSauvegarde.identifiant = carte.Identifiant;
            carteSauvegarde.identifiantCarteDefinitionScriptable = carte.Definition.identifiant;
            carteSauvegarde.niveau = carte.Niveau;

            sauvegarde.cartes.Add(carteSauvegarde);
        }
    }

    private void SauvegarderDecks(JoueurSauvegarde sauvegarde)
    {
        sauvegarde.indexDeckSelectionne = gestionnaireCartes.GestionnaireDecks.IndexDeckSelectionne;

        for (int i = 0; i < gestionnaireCartes.GestionnaireDecks.ObtenirNombreDecks(); i++)
        {
            DeckJoueur deck = gestionnaireCartes.GestionnaireDecks.ObtenirDeck(i);

            if (deck == null)
            {
                continue;
            }

            DeckSauvegarde deckSauvegarde = new DeckSauvegarde();

            deckSauvegarde.nom = deck.Nom;

            foreach (CarteInstance carte in deck.Cartes)
            {
                deckSauvegarde.identifiantsCartes.Add(carte.Identifiant);
            }

            sauvegarde.decks.Add(deckSauvegarde);
        }
    }

    private void SauvegarderTotems(JoueurSauvegarde sauvegarde)
    {
        foreach (TotemInstance totem in gestionnaireTotems.Collection.Totems)
        {
            TotemSauvegarde totemSauvegarde = new TotemSauvegarde();

            totemSauvegarde.identifiant = totem.Identifiant;
            totemSauvegarde.identifiantTotemDefinitionScriptable = totem.DefinitionScriptable.identifiant;
            totemSauvegarde.nombrePossede = totem.NombrePossede;

            sauvegarde.totems.Add(totemSauvegarde);
        }
    }

    private void SauvegarderEnsemblesTotems(JoueurSauvegarde sauvegarde)
    {
        sauvegarde.indexEnsembleTotemSelectionne = gestionnaireTotems.GestionnaireEnsemblesTotems.IndexEnsembleTotemSelectionne;

        for (int i = 0; i < gestionnaireTotems.GestionnaireEnsemblesTotems.ObtenirNombreEnsemblesTotems(); i++)
        {
            EnsembleTotemJoueur ensembleTotem = gestionnaireTotems.GestionnaireEnsemblesTotems.ObtenirEnsembleTotem(i);

            if (ensembleTotem == null)
            {
                continue;
            }

            EnsembleTotemSauvegarde ensembleTotemSauvegarde = new EnsembleTotemSauvegarde();

            ensembleTotemSauvegarde.nom = ensembleTotem.Nom;

            foreach (TotemInstance totem in ensembleTotem.Totems)
            {
                ensembleTotemSauvegarde.identifiantsTotems.Add(totem.Identifiant);
            }

            sauvegarde.ensemblesTotems.Add(ensembleTotemSauvegarde);
        }
    }

    private void ChargerSauvegarde(JoueurSauvegarde sauvegarde)
    {
        gestionnaireCartes.Initialiser();
        gestionnaireCartes.GestionnaireDecks.ViderDecks();

        gestionnaireTotems.Initialiser();
        gestionnaireTotems.GestionnaireEnsemblesTotems.ViderEnsemblesTotems();

        gestionnaireProgression.Initialiser();
        gestionnaireProgression.ChargerSauvegarde(sauvegarde.progression);

        Dictionary<string, CarteInstance> cartesChargees = ChargerCollection(sauvegarde);
        ChargerDecks(sauvegarde, cartesChargees);

        Dictionary<string, TotemInstance> totemsCharges = ChargerTotems(sauvegarde);
        ChargerEnsemblesTotems(sauvegarde, totemsCharges);
    }

    private Dictionary<string, CarteInstance> ChargerCollection(JoueurSauvegarde sauvegarde)
    {
        Dictionary<string, CarteInstance> cartesChargees = new Dictionary<string, CarteInstance>();

        foreach (CarteSauvegarde carteSauvegarde in sauvegarde.cartes)
        {
            if (carteSauvegarde == null)
            {
                continue;
            }

            CarteDefinitionScriptable definition = catalogueCartesScriptable.ObtenirCarte(carteSauvegarde.identifiantCarteDefinitionScriptable);

            if (definition == null)
            {
                Debug.LogWarning( $"Carte introuvable dans le catalogue : " + $"{carteSauvegarde.identifiantCarteDefinitionScriptable}");

                continue;
            }

            CarteInstance carte = gestionnaireCartes.AjouterCarteAvecIdentifiant(
                carteSauvegarde.identifiant,
                definition,
                carteSauvegarde.niveau);

            if (carte == null)
            {
                continue;
            }

            cartesChargees.Add(carte.Identifiant, carte);
        }

        return cartesChargees;
    }

    private void ChargerDecks(JoueurSauvegarde sauvegarde, Dictionary<string, CarteInstance> cartesChargees)
    {
        for (int i = 0; i < sauvegarde.decks.Count; i++)
        {
            DeckSauvegarde deckSauvegarde = sauvegarde.decks[i];

            if (deckSauvegarde == null)
            {
                continue;
            }

            DeckJoueur deck = gestionnaireCartes.GestionnaireDecks.CreerDeck(deckSauvegarde.nom);

            if (deck == null)
            {
                continue;
            }

            foreach (string identifiantCarte in deckSauvegarde.identifiantsCartes)
            {
                if (!cartesChargees.TryGetValue(identifiantCarte, out CarteInstance carte))
                {
                    Debug.LogWarning($"Carte du deck introuvable : {identifiantCarte}");

                    continue;
                }

                gestionnaireCartes.GestionnaireDecks.AjouterCarteAuDeck(deck, carte);
            }
        }

        gestionnaireCartes.SelectionnerDeck(sauvegarde.indexDeckSelectionne);
    }


    private Dictionary<string, TotemInstance> ChargerTotems(JoueurSauvegarde sauvegarde)
    {
        Dictionary<string, TotemInstance> totemsCharges = new Dictionary<string, TotemInstance>();

        foreach (TotemSauvegarde totemSauvegarde in sauvegarde.totems)
        {
            if (totemSauvegarde == null)
            {
                continue;
            }

            TotemDefinitionScriptable definitionScriptable = catalogueTotemsScriptable.ObtenirTotem(totemSauvegarde.identifiantTotemDefinitionScriptable);

            if (definitionScriptable == null)
            {
                Debug.LogWarning($"Totem introuvable dans le catalogue : " + $"{totemSauvegarde.identifiantTotemDefinitionScriptable}");

                continue;
            }

            TotemInstance totem = gestionnaireTotems.AjouterTotemAvecIdentifiant(
                totemSauvegarde.identifiant,
                definitionScriptable,
                totemSauvegarde.nombrePossede);

            if (totem == null)
            {
                continue;
            }

            totemsCharges.Add(totem.Identifiant, totem);
        }

        return totemsCharges;
    }

    private void ChargerEnsemblesTotems(JoueurSauvegarde sauvegarde, Dictionary<string, TotemInstance> totemsCharges)
    {
        for (int i = 0; i < sauvegarde.ensemblesTotems.Count; i++)
        {
            EnsembleTotemSauvegarde ensembleTotemSauvegarde = sauvegarde.ensemblesTotems[i];

            if (ensembleTotemSauvegarde == null)
            {
                continue;
            }

            EnsembleTotemJoueur ensembleTotem = gestionnaireTotems.GestionnaireEnsemblesTotems.CreerEnsembleTotem(ensembleTotemSauvegarde.nom);

            if (ensembleTotem == null)
            {
                continue;
            }

            foreach (string identifiantTotem in ensembleTotemSauvegarde.identifiantsTotems)
            {
                if (!totemsCharges.TryGetValue(identifiantTotem, out TotemInstance totem))
                {
                    Debug.LogWarning($"Totem de l'ensemble totem introuvable : {identifiantTotem}");

                    continue;
                }

                gestionnaireTotems.GestionnaireEnsemblesTotems.AjouterTotemAEnsembleTotem(ensembleTotem, totem);
            }
        }

        gestionnaireTotems.SelectionnerEnsembleTotem(sauvegarde.indexEnsembleTotemSelectionne);
    }
}