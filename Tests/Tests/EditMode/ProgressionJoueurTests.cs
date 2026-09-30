using NUnit.Framework;

public class ProgressionJoueurTests
{
    private ProgressionJoueur progression;

    [SetUp]
    public void SetUp()
    {
        progression = new ProgressionJoueur();
    }

    [Test]
    public void NouvelleProgression_CommenceAvecSoldesNulsEtNiveauUn()
    {
        Assert.That(progression.Pieces, Is.Zero);
        Assert.That(progression.Diamants, Is.Zero);
        Assert.That(progression.Experience, Is.Zero);
        Assert.That(progression.Niveau, Is.EqualTo(1));
    }

    [TestCase(0)]
    [TestCase(-5)]
    public void AjouterPieces_IgnoreQuantiteNulleOuNegative(int quantite)
    {
        progression.AjouterPieces(quantite);

        Assert.That(progression.Pieces, Is.Zero);
    }

    [Test]
    public void DepenserPieces_RefuseDepenseInvalideSansModifierLeSolde()
    {
        progression.AjouterPieces(10);

        Assert.That(progression.DepenserPieces(0), Is.False);
        Assert.That(progression.DepenserPieces(-1), Is.False);
        Assert.That(progression.DepenserPieces(11), Is.False);
        Assert.That(progression.Pieces, Is.EqualTo(10));
    }

    [Test]
    public void DepenserPieces_QuantiteExacteEstAcceptee()
    {
        progression.AjouterPieces(10);

        Assert.That(progression.DepenserPieces(10), Is.True);
        Assert.That(progression.Pieces, Is.Zero);
    }

    [Test]
    public void AjouterDiamantsEtExperience_AjouteLesQuantitesPositives()
    {
        progression.AjouterDiamants(3);
        progression.AjouterExperience(25);

        Assert.That(progression.Diamants, Is.EqualTo(3));
        Assert.That(progression.Experience, Is.EqualTo(25));
    }

    [Test]
    public void RestaurerEtat_RestaureToutesLesValeurs()
    {
        progression.RestaurerEtat(50, 4, 125, 3);

        Assert.That(progression.Pieces, Is.EqualTo(50));
        Assert.That(progression.Diamants, Is.EqualTo(4));
        Assert.That(progression.Experience, Is.EqualTo(125));
        Assert.That(progression.Niveau, Is.EqualTo(3));
    }
}
