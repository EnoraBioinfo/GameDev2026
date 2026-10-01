using System.Collections.Generic;
using UnityEngine;

public class GestionnaireNiveau : MonoBehaviour
{
    [SerializeField]
    private List<NiveauDefinitionScriptable> niveauDefinitionScriptable = new();

    [Header("Seed")]
    [SerializeField]
    private bool utiliserSeedFournie;

    [SerializeField]
    private int seedFournie = 12345;

    private NiveauSysteme niveauSysteme;
    public NiveauSysteme NiveauSysteme => niveauSysteme;

    public void Initialiser()
    {
        if (utiliserSeedFournie)
        {
            niveauSysteme = new NiveauSysteme(ObtenirDefinitionNiveau(2), seedFournie);
            return;
        }

        niveauSysteme = new NiveauSysteme(ObtenirDefinitionNiveau(2));
    }

    private NiveauDefinitionScriptable ObtenirDefinitionNiveau(int numeroNiveau)
    {
        foreach (NiveauDefinitionScriptable definition in niveauDefinitionScriptable)
        {
            if (definition.numeroNiveau == numeroNiveau)
            {
                return definition;
            }
        }

        return null;
    }
}
