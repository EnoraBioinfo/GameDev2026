using UnityEngine;

[CreateAssetMenu(
    fileName = "ReglesEnsembleTotem",
    menuName = "Jeu/Totems/Règles d'ensemble de totem"
)]
public class ReglesEnsembleTotemScriptable : ScriptableObject
{
    [Header("Nombre de totem équipables")]
    public int nombreMaximumTotems = 10;
}