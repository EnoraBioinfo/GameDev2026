[CreateAssetMenu(
    fileName = "CarteDefinition",
    menuName = "Game/Carte/Carte Definition"
)]

public class CarteDefinition : ScriptableObject
{
    [Header("Informations générales")]
    public string Id;
    public string NomAffiche;
    public string Description;
    public TypeCarte TypeCarte;
    public RareteCarte Rarete;
    public CarteTypeCible TypeCible;

    [Header("Visuel")]
    public Sprite Sprite;

    [Header("Liste des effets de la carte")]
    public List<CarteEffetDefinition> Effets;
}
