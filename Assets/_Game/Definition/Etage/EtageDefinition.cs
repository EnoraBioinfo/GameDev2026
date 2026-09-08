[CreateAssetMenu(
    fileName = "EtageDefinition",
    menuName = "Game/Etage/Etage Definition"
)]
public class EtageDefinition : ScriptableObject
{
    public int FloorNumber;
    // public GrilleDefinition Grille; // Pour génerer la bonne taille de la grille et les cellules
    public JoueurZoneDeSpawn JoueurZoneDeSpawn;
    public SortieZoneDeSpawn SortieZoneDeSpawn;

    // public Map<MonstreDefinition, int> Monstres;

    public TableDeLootDefinition TableDeLoot;
}
