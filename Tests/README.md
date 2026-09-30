# Tests automatisés GameDev2026

Ce dossier est un package Unity local référencé dans `Packages/manifest.json` sous
`com.eega2160.gamedev2026.tests`. Le package permet de garder les tests à la racine
du projet, à côté de `Assets`, tout en les faisant compiler et détecter par Unity.

## Structure

- `package.json` : identité du package local.
- `Tests/EditMode/` : tests rapides des règles métier sans lancer de scène.
- `Tests/EditMode/Game.EditModeTests.asmdef` : assembly de tests, référencée à
  `Game.Runtime`.
- `Assets/_Game/Game.Runtime.asmdef` : assembly des scripts du jeu que les tests
  peuvent référencer.

## Lancer les tests

1. Ouvrir le projet dans Unity et attendre la fin de l’import/recompilation.
2. Ouvrir **Window > General > Test Runner**.
3. Choisir **EditMode**, puis **Run All**.

Les tests actuellement présents couvrent la grille, la progression, les règles de
deck, la fusion de cartes et quelques règles de totems. `EnnemiAPlacer` et la
génération des niveaux ne font pas partie du périmètre.

## Ajouter un test

Ajouter un fichier C# dans `Tests/Tests/EditMode/`, avec une classe de tests NUnit
et des méthodes marquées `[Test]` ou `[TestCase]`. Les définitions Unity temporaires
créées par les tests doivent être détruites en `[TearDown]`.
