public class CarteInstance
{
    public CarteDefinition Definition { get; }
    public int Niveau { get; private set; }

    public CarteInstance(CarteDefinition definition, int niveau)
    {
        Definition = definition;
        Niveau = niveau;
    }

    public int ObtenirValeurFusion()
    {
        return Niveau * (Niveau + 1) / 2;
    }
}