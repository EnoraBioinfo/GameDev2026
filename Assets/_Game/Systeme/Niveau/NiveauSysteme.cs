using UnityEngine;

public class NiveauSysteme
{
    private readonly NiveauDefinitionScriptable niveauDefinitionScriptable;
    private readonly System.Random random;

    public int NumeroNiveau => niveauDefinitionScriptable.numeroNiveau;
    public int Hauteur => niveauDefinitionScriptable.grilleDefinition.hauteur;
    public int Largeur => niveauDefinitionScriptable.grilleDefinition.largeur;

    public NiveauSysteme(NiveauDefinitionScriptable niveauDefinitionScriptable)
    {
        this.niveauDefinitionScriptable = niveauDefinitionScriptable;

        random = new System.Random(niveauDefinitionScriptable.seed);
    }

    public GrillePosition ObtenirPositionAleatoire()
    {
        // Ajouter plus tard le fait d'éviter les obstacles et autres choses exitantes
        int x = random.Next(Largeur);
        int y = random.Next(Hauteur);

        return new GrillePosition(x, y);
    }
}
