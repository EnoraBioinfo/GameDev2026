using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "TotemDefinition",
    menuName = "Jeu/Totems/Définition d'un totem"
)]
public class TotemDefinitionScriptable : ScriptableObject
{
    [Header("Identification")]
    public string identifiant;

    [Header("Informations")]
    public string nom;
    public int prixDeVentePiece;
    public int prixDeVenteDiamant;

    [TextArea]
    public string texteDeDescription;

    [Header("Rareté")]
    public RareteTotem rarete;

    [Header("Effets")]
    public List<EffetTotemDefinition> effets = new List<EffetTotemDefinition>();
}
