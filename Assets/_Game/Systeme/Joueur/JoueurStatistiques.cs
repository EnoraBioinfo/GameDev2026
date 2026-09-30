using UnityEngine;

public class JoueurStatistiques : MonoBehaviour
{
    private readonly JoueurDefinitionScriptable joueurDefinition;
    public int PointsDeVieMaximum { get; private set; }
    public int PointsDeMouvementsMaximum { get; private set; }
    public int NombreSegmentsActionsMaximum { get; private set; }

    public JoueurStatistiques(JoueurDefinitionScriptable joueurDefinition)
    {
        this.joueurDefinition = joueurDefinition;

        Recalculer();
    }

    public void Recalculer()
    {
        PointsDeVieMaximum = joueurDefinition.pointDeVieMaximum;
        PointsDeMouvementsMaximum = joueurDefinition.pointsMouvementMaximum;
        NombreSegmentsActionsMaximum = joueurDefinition.nombreSegmentsAction;
    }
}
