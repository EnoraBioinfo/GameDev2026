public class JoueurEtat : PersonnageEtat
{
    public JoueurDefinition JoueurDefinition;
    public string NomAffiche;

    public int Niveau;

    public int EnergieMax;
    public int EnergieActuelle;
    public int Attaque;
    public int Defense;
    public int Mouvement;

    public DeckEtat Deck;
    public TotemsEquippes TotemsEquippes;
}
