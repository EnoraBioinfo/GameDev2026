using UnityEngine;

public class TestTotems : MonoBehaviour
{
    [SerializeField]
    private GestionnaireTotems gestionnaireTotems;

    [SerializeField]
    private CatalogueTotemsScriptable catalogueTotems;

    private TotemDefinitionScriptable totemDeTroll;
    private TotemDefinitionScriptable vieuxTotemDePaysan;

    private void Start()
    {
        gestionnaireTotems.Initialiser();

        totemDeTroll = catalogueTotems.ObtenirTotem("totem_de_troll");
        vieuxTotemDePaysan = catalogueTotems.ObtenirTotem("vieux_totem_de_paysan");

        TesterAcquisition();
        TesterEnsemble();
        TesterVente();
    }

    private void TesterAcquisition()
    {
        Debug.Log("=== TEST ACQUISITION ===");

        gestionnaireTotems.AjouterTotem(totemDeTroll);
        gestionnaireTotems.AjouterTotem(totemDeTroll);
        gestionnaireTotems.AjouterTotem(totemDeTroll);

        int nombre = gestionnaireTotems.Collection.ObtenirNombreTotems(totemDeTroll);

        Debug.Log($"Nombre de Totem de Troll possédés : {nombre}");
    }

    private void TesterEnsemble()
    {
        Debug.Log("=== TEST ENSEMBLE ===");

        TotemInstance totem = gestionnaireTotems.Collection.ObtenirTotem(totemDeTroll);

        bool ajoute = gestionnaireTotems.AjouterTotemAEnsembleTotem(totem);

        Debug.Log($"Totem ajouté à l'ensemble : {ajoute}");
        Debug.Log($"Nombre de totems dans l'ensemble : {gestionnaireTotems.EnsembleTotemSelectionne.ObtenirNombreTotems()}");
    }

    private void TesterVente()
    {
        Debug.Log("=== TEST VENTE ===");

        TotemInstance totem = gestionnaireTotems.Collection.ObtenirTotem(totemDeTroll);

        Debug.Log($"Avant vente : {totem.NombrePossede}");

        bool vendu = gestionnaireTotems.Vendre1Totem(totem);

        Debug.Log($"Vente réussie : {vendu}");
        Debug.Log($"Après vente : {totem.NombrePossede}");

        int nombreVendu = gestionnaireTotems.VendrePlusieursTotems(totem, 5);

        Debug.Log($"Nombre vendu : {nombreVendu}");
        Debug.Log($"Nombre restant : {totem.NombrePossede}");
    }
}