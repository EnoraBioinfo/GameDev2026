using UnityEngine;

public class NiveauGizmo : MonoBehaviour
{
    [SerializeField]
    private NiveauDefinitionScriptable niveauDefinitionScriptable;

    private void OnDrawGizmos()
    {
        if (niveauDefinitionScriptable == null || niveauDefinitionScriptable.grilleDefinition == null)
        {
            Debug.LogError($"Probleme de truc mal attachés dans le gizmo niveau");
            return;
        }

        float tailleCellule = niveauDefinitionScriptable.grilleDefinition.tailleCelluleGrille;
        int largeur = niveauDefinitionScriptable.grilleDefinition.largeur;
        int hauteur = niveauDefinitionScriptable.grilleDefinition.hauteur;

        for (int x = 0; x <= largeur; x++)
        {
            float positionX = (x - 0.5f) * tailleCellule;

            Vector3 debut = new Vector3(positionX * tailleCellule, 0f, -0.5f * tailleCellule);
            Vector3 fin = new Vector3(positionX * tailleCellule, 0f, (largeur - 0.5f) * tailleCellule);

            Gizmos.DrawLine(debut, fin);
        }

        for (int y = 0; y <= hauteur; y++)
        {
            float positionY = (y - 0.5f) * tailleCellule;

            Vector3 debut = new Vector3(-0.5f * tailleCellule, 0f, positionY);
            Vector3 fin = new Vector3((hauteur - 0.5f) * tailleCellule, 0f, positionY);

            Gizmos.DrawLine(debut, fin);
        }
    }
}
