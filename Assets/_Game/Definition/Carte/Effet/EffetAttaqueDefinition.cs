using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "EffetAttaque",
    menuName = "Jeu/Cartes/Effets/Attaque"
)]
public class EffetAttaqueDefinition : EffetCarteDefinition
{
    [Header("Dégâts par niveau")]
    public List<ValeurParNiveau> degatsParNiveau = new List<ValeurParNiveau>();

    [Header("Portée")]
    [Min(1)]
    public int portee = 1;

    [Header("Zone")]
    [Min(1)]
    public int tailleZone = 1;
}