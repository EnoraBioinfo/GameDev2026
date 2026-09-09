using UnityEngine;

public class EnnemiVisuel : MonoBehaviour
{
    private EnnemiSysteme ennemiSysteme;

    public void Initialiser(EnnemiSysteme ennemi)
    {
        ennemiSysteme = ennemi;

        ActualiserPosition();
    }

    public void ActualiserPosition()
    {
        transform.position = new Vector3(
            ennemiSysteme.Position.x,
            1f,
            ennemiSysteme.Position.y
        );
    }
}