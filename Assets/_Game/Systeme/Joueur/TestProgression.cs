using UnityEngine;

public class TestProgression : MonoBehaviour
{
    [SerializeField]
    private GestionnaireProgression gestionnaireProgression;

    private void Start()
    {
        gestionnaireProgression.Initialiser();

        gestionnaireProgression.AjouterPieces(10);
        gestionnaireProgression.DepenserPieces(1);
        gestionnaireProgression.DepenserPieces(10);

        gestionnaireProgression.AjouterExperience(150);

        Debug.Log($"Pièces : {gestionnaireProgression.Pieces}");
        Debug.Log($"Diamants : {gestionnaireProgression.Diamants}");
        Debug.Log($"Expérience : {gestionnaireProgression.Experience}");
    }
}
