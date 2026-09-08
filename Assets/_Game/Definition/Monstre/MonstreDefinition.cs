public class MonstreDefinition : ScriptableObject
{
    public string Id;
    public string NomAffiche;
    public int VieBase;
    public int AttaqueBase;
    public int DefenseBase;
    public int PointsMouvement;
    public int Portee;
    public MonstreTypeMouvement TypeMouvement;
    public MonstreTypeAttaque TypeAttaque;
    public List<MonstreCapaciteDefinition> Capacites;
    public GameObject Prefab;
}
