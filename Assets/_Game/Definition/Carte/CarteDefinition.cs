using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "CarteDefinition",
    menuName = "Jeu/Cartes/Définition de carte"
)]
public class CarteDefinition : ScriptableObject
{
    [Header("Informations")]
    public string nom;

    [TextArea]
    public string description;

    public RareteCarte rarete;

    [Header("Evolution")]
    [Min(1)]
    public int niveauMaximum = 3;

    [Header("Effets")]
    public List<EffetCarteDefinition> effets = new List<EffetCarteDefinition>();
}