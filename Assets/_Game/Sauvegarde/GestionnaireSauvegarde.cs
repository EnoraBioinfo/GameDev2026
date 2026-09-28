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

    private string CheminSauvegarde => Path.Combine(
        Application.persistentDataPath,
        NomFichierSauvegarde);

    public void Sauvegarder()
    {
        if (gestionnaireCartes == null)
        {
            Debug.LogError("GestionnaireCartes non configuré.");
            return;
        }

        JoueurSauvegarde sauvegarde = CreerSauvegarde();

        string json = JsonUtility.ToJson(sauvegarde, true);

        File.WriteAllText(CheminSauvegarde, json);

        Debug.Log($"Sauvegarde effectuée : {CheminSauvegarde}");
    }

    public void Charger()
    {
        if (gestionnaireCartes == null)
        {
            Debug.LogError("GestionnaireCartes non configuré.");
            return;
        }

        if (catalogueCartesScriptable == null)
        {
            Debug.LogError("CatalogueCartesScriptable non configuré.");
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

        return sauvegarde;
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
        sauvegarde.indexDeckSelectionne =
            gestionnaireCartes.GestionnaireDecks.IndexDeckSelectionne;

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

    private void ChargerSauvegarde(JoueurSauvegarde sauvegarde)
    {
        gestionnaireCartes.Initialiser();
        gestionnaireCartes.GestionnaireDecks.ViderDecks();

        Dictionary<string, CarteInstance> cartesChargees = ChargerCollection(sauvegarde);

        ChargerDecks(sauvegarde, cartesChargees);
    }

    private Dictionary<string, CarteInstance> ChargerCollection(
        JoueurSauvegarde sauvegarde)
    {
        Dictionary<string, CarteInstance> cartesChargees =
            new Dictionary<string, CarteInstance>();

        foreach (CarteSauvegarde carteSauvegarde in sauvegarde.cartes)
        {
            if (carteSauvegarde == null)
            {
                continue;
            }

            CarteDefinitionScriptable definition =
                catalogueCartesScriptable.ObtenirCarte(
                    carteSauvegarde.identifiantCarteDefinitionScriptable);

            if (definition == null)
            {
                Debug.LogWarning(
                    $"Carte introuvable dans le catalogue : " +
                    $"{carteSauvegarde.identifiantCarteDefinitionScriptable}");

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

    private void ChargerDecks(
    JoueurSauvegarde sauvegarde,
    Dictionary<string, CarteInstance> cartesChargees)
    {
        for (int i = 0; i < sauvegarde.decks.Count; i++)
        {
            DeckSauvegarde deckSauvegarde = sauvegarde.decks[i];

            if (deckSauvegarde == null)
            {
                continue;
            }

            DeckJoueur deck =
                gestionnaireCartes.GestionnaireDecks.CreerDeck(
                    deckSauvegarde.nom);

            if (deck == null)
            {
                continue;
            }

            foreach (string identifiantCarte in deckSauvegarde.identifiantsCartes)
            {
                if (!cartesChargees.TryGetValue(
                    identifiantCarte,
                    out CarteInstance carte))
                {
                    Debug.LogWarning(
                        $"Carte du deck introuvable : {identifiantCarte}");

                    continue;
                }

                gestionnaireCartes.GestionnaireDecks.AjouterCarteAuDeck(
                    deck,
                    carte);
            }
        }

        gestionnaireCartes.SelectionnerDeck(
            sauvegarde.indexDeckSelectionne);
    }
}