using UnityEngine;

public class EnnemiEtat
{
    private readonly EnnemiStatistiques ennemiStatistiques;
    public EnnemiStatistiques EnnemiStatistiques => ennemiStatistiques;

    public int PointsDeVieActuels { get; private set; }

    public EnnemiEtat(EnnemiStatistiques ennemiStatistiques)
    {
        this.ennemiStatistiques = ennemiStatistiques;

        PointsDeVieActuels = ennemiStatistiques.PointsDeVieMaximum;
    }

    public void AdapterAuxStatistiquesMaximum()
    {
        if(PointsDeVieActuels > ennemiStatistiques.PointsDeVieMaximum)
        {
            PointsDeVieActuels = ennemiStatistiques.PointsDeVieMaximum;
        }
    }
}
