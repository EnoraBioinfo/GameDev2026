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
            0f,
            ennemiSysteme.Position.y
        );
    }

    public void OrienterVers(GrillePosition position)
    {
        int differenceX = position.x - ennemiSysteme.Position.x;
        int differenceY = position.y - ennemiSysteme.Position.y;

        Vector3 direction;

        if (System.Math.Abs(differenceX) >= System.Math.Abs(differenceY))
        {
            direction = new Vector3(System.Math.Sign(differenceX), 0f, 0f);
        }
        else
        {
            direction = new Vector3(0f, 0f, System.Math.Sign(differenceY));
        }

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}