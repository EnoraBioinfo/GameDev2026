public class JoueurEtat
{
    public int PointsDeVieActuels { get; private set; }

    public int PointsMouvementsRestants { get; private set; }

    public int SegmentsActionsRestants { get; private set; }

    private readonly JoueurStatistiques statistiques;

    public JoueurEtat(JoueurStatistiques statistiques)
    {
        this.statistiques = statistiques;

        PointsDeVieActuels = statistiques.PointsDeVieMaximum;
        PointsMouvementsRestants = statistiques.PointsDeMouvementsMaximum;
        SegmentsActionsRestants = statistiques.NombreSegmentsActionsMaximum;
    }

    public void ModifierPointsDeVie(int montant)
    {
        PointsDeVieActuels += montant;
    }

    public void DefinirPointsDeVie(int pointsDeVie)
    {
        PointsDeVieActuels = pointsDeVie;
    }

    public void RestaurerPointsDeMouvements()
    {
        PointsMouvementsRestants = statistiques.PointsDeMouvementsMaximum;
    }

    public void RestaurerSegmentsActions()
    {
        SegmentsActionsRestants = statistiques.NombreSegmentsActionsMaximum;
    }

    public void UtiliserPointMouvement()
    {
        if(PointsMouvementsRestants <= 0)
        {
            return;
        }

        PointsMouvementsRestants--;
    }

    public void UtiliserSegmentAction()
    {
        if (SegmentsActionsRestants <= 0)
        {
            return;
        }

        SegmentsActionsRestants--;
    }

    public void AdapterAuxStatistiquesMaximum()
    {
        if (PointsDeVieActuels > statistiques.PointsDeVieMaximum)
        {
            PointsDeVieActuels = statistiques.PointsDeVieMaximum;
        }

        if (PointsMouvementsRestants > statistiques.PointsDeMouvementsMaximum)
        {
            PointsMouvementsRestants = statistiques.PointsDeMouvementsMaximum;
        }

        if (SegmentsActionsRestants > statistiques.NombreSegmentsActionsMaximum)
        {
            SegmentsActionsRestants = statistiques.NombreSegmentsActionsMaximum;
        }
    }
}