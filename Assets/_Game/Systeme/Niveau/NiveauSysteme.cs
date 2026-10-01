using System.Collections.Generic;
using UnityEngine;

public class NiveauSysteme
{
    public int Seed { get; private set; }

    private readonly NiveauDefinitionScriptable niveauDefinitionScriptable;
    private readonly System.Random random;
    private readonly int prevalenceDesDecorations = 9;

    public int NumeroNiveau => niveauDefinitionScriptable.numeroNiveau;
    public int Hauteur => niveauDefinitionScriptable.grilleDefinition.hauteur;
    public int Largeur => niveauDefinitionScriptable.grilleDefinition.largeur;
    public List<EnnemiAPlacer> EnnemisAPlacer => niveauDefinitionScriptable.ennemiAPlacer;
    public List<ObsctaclesAPlacer> ObsctaclesAPlacer => niveauDefinitionScriptable.obstaclesAPlacer;
    public RectInt ZoneDepartJoueur => niveauDefinitionScriptable.zoneDepartJoueur;
    public GrilleDefinition GrilleDefinition => niveauDefinitionScriptable.grilleDefinition;

    public NiveauSysteme(NiveauDefinitionScriptable niveauDefinitionScriptable)
    {
        this.niveauDefinitionScriptable = niveauDefinitionScriptable;

        Seed = Random.Range(int.MinValue, int.MaxValue);
        random = new System.Random(Seed);
    }

    public NiveauSysteme(NiveauDefinitionScriptable niveauDefinitionScriptable, int seed)
    {
        this.niveauDefinitionScriptable = niveauDefinitionScriptable;
        Seed = seed;
        random = new System.Random(Seed);
    }

    public GrillePosition ObtenirPositionAleatoire(RectInt zone)
    {
        // Ajouter plus tard le fait d'éviter les obstacles et autres choses exitantes
        int x = random.Next(zone.xMin, zone.xMax);
        int y = random.Next(zone.yMin, zone.yMax);

        return new GrillePosition(x, y);
    }

    public GrillePosition ObtenirPositionDepartJoueur()
    {
        return ObtenirPositionAleatoire(niveauDefinitionScriptable.zoneDepartJoueur);
    }

    public GrillePosition ObtenirPositionSortie()
    {
        return ObtenirPositionAleatoire(niveauDefinitionScriptable.zoneSortie);
    }

    public GrillePosition ObtenirPositionDepartEnnemi()
    {
        return ObtenirPositionAleatoire(new RectInt(0,0,niveauDefinitionScriptable.grilleDefinition.hauteur, niveauDefinitionScriptable.grilleDefinition.largeur));
    }

    public GameObject ObtenirDecorationPourCellule()
    {
        if (niveauDefinitionScriptable.decorations.Count == 0)
        {
            return null;
        }

        if (random.Next(prevalenceDesDecorations) != 0)
        {
            return null;
        }

        int numeroDecorationAleatoire = random.Next(niveauDefinitionScriptable.decorations.Count);
        return niveauDefinitionScriptable.decorations[numeroDecorationAleatoire];
    }

    public Vector3 ObtenirVariationDecoration(float amplitude)
    {
        float x = (float)(random.NextDouble() * 2f - 1f) * amplitude;
        float z = (float)(random.NextDouble() * 2f - 1f) * amplitude;

        return new Vector3(x, 0f, z);
    }

    public float ObtenirRotationY()
    {
        return (float)(random.NextDouble() * 360f);
    }

    public bool EssayerObtenirPositionLibre(GrilleSysteme grille, out GrillePosition position)
    {
        List<GrillePosition> positionsDisponibles = new();

        foreach (GrilleCellule cellule in grille.ObtenirToutesLesCellules())
        {
            if (cellule.PeutEtreOccupee())
            {
                positionsDisponibles.Add(cellule.Position);
            }
        }

        if (positionsDisponibles.Count == 0)
        {
            position = default;
            return false;
        }

        position = positionsDisponibles[random.Next(positionsDisponibles.Count)];
        return true;
    }

    public bool EssayerObtenirPositionLibre(GrilleSysteme grille, RectInt zone, out GrillePosition position)
    {
        List<GrillePosition> positionsDisponibles = new();

        foreach (GrilleCellule cellule in grille.ObtenirToutesLesCellules())
        {
            if (!zone.Contains(new Vector2Int(cellule.Position.x, cellule.Position.y)))
            {
                continue;
            }

            if (cellule.PeutEtreOccupee())
            {
                positionsDisponibles.Add(cellule.Position);
            }
        }

        if (positionsDisponibles.Count == 0)
        {
            position = default;
            return false;
        }

        position = positionsDisponibles[random.Next(positionsDisponibles.Count)];
        return true;
    }
}
