using UnityEngine;

[CreateAssetMenu(
    fileName = "AttaqueEnnemi",
    menuName = "Jeu/Ennemi/Attaque"
)]
public class AttaqueEnnemiDefinitionScriptable : ScriptableObject
{
    [Header("Informations")]
    public string nom;

    [TextArea(2, 5)]
    public string description;

    [Header("Combat")]
    [Min(0)]
    public int degats = 1;

    [Min(0)]
    public int soin = 0;

    [Min(0)]
    public int protection = 0;

    [Min(0)]
    public int porteeMinimum = 1;

    [Min(0)]
    public int porteeMaximum = 1;
}
