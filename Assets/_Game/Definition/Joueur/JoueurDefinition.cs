[CreateAssetMenu(
    fileName = "JoueurDefinition",
    menuName = "Game/Joueur/Joueur Definition"
)]
public class JoueurDefinition : ScriptableObject
{
    [Header("Informations générales")]
    public string Id;
    public string TypeDeJoueur;

    [Header("Stats Base")]
    public int VieBase;
    public int EnergieBase;
    public int AttaqueBase;
    public int DefenseBase;
    public int PointsMouvement;

    [Header("Deck Base")]
    public DeckEtat Deck;

    [Header("Visuel")]
    public GameObject Prefab;
}