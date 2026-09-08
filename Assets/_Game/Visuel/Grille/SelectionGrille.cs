using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionGrille : MonoBehaviour
{
    [SerializeField]
    private Camera cameraPrincipale;

    [SerializeField]
    private GestionnaireJoueur gestionnaireJoueur;

    private GrilleCelluleVisuel celluleSelectionnee;

    private void Update()
    {
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            DetecterCellule(Mouse.current.position.ReadValue());
        }
    }

    private void DetecterCellule(Vector2 positionEcran)
    {
        Ray rayon =
            cameraPrincipale.ScreenPointToRay(positionEcran);

        if (Physics.Raycast(rayon, out RaycastHit touche))
        {
            GrilleCelluleVisuel cellule =
                touche.collider.GetComponent<GrilleCelluleVisuel>();

            if (cellule != null)
            {
                SelectionnerCellule(cellule);
            }
        }
    }

    private void SelectionnerCellule(GrilleCelluleVisuel cellule)
    {
        if (celluleSelectionnee != null)
        {
            celluleSelectionnee.Deselectionner();
        }

        celluleSelectionnee = cellule;

        celluleSelectionnee.Selectionner();

        gestionnaireJoueur.DeplacerVers(celluleSelectionnee.Position);

        Debug.Log(
            $"Cellule sélectionnée : {celluleSelectionnee.Position}"
        );
    }
}