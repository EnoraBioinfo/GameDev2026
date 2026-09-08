using UnityEngine;

public class JoueurVisuel : MonoBehaviour
{
    private JoueurSysteme joueurSysteme;

    public void Initialiser(JoueurSysteme joueur)
    {
        joueurSysteme = joueur;

        ActualiserPosition();
    }

    public void ActualiserPosition()
    {
        transform.position = new Vector3(
            joueurSysteme.Position.x,
            1f,
            joueurSysteme.Position.y
        );
    }
}