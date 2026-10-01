using System.Collections.Generic;
using UnityEngine;

public class NiveauSysteme
{
    public int Seed { get; private set; }

    private readonly NiveauDefinitionScriptable niveauDefinitionScriptable;
    private readonly System.Random random;

    public int NumeroNiveau => niveauDefinitionScriptable.numeroNiveau;
    public int Hauteur => niveauDefinitionScriptable.grilleDefinition.hauteur;
    public int Largeur => niveauDefinitionScriptable.grilleDefinition.largeur;
    public List<EnnemiAPlacer> EnnemisAPlacer => niveauDefinitionScriptable.ennemiAPlacer;
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
}
