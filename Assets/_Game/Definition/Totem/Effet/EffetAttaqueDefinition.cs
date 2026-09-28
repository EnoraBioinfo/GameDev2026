using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "EffetAttaque",
    menuName = "Jeu/Totems/Effets/Attaque"
)]
public class EffetTotemAttaqueDefinition : EffetTotemDefinition
{
    [Header("Dégât")]
    [Min(1)]
    public int degat = 1;

    [TextArea]
    public string texteDeDescription = "Augmente tous vos dégats de 1 point";
}