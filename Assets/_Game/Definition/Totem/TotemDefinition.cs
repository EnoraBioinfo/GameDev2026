[CreateAssetMenu(
    fileName = "TotemDefinition",
    menuName = "Game/Totem/Totem Definition"
)]
public class TotemDefinition : ScriptableObject
{
    [Header("Informations générales")]
    public string Id;
    public string NomAffiche;
    public string Description;
    public TotemRarete Rarete;

    [Header("Visuel")]
    public Sprite Sprite;

    [Header("Liste des effets du totem")]
    public List<TotemEffetDefinition> Effets;
}
