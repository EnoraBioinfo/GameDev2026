using UnityEngine;

public static class ValidationReferencesUnity
{
    public static bool Verifier(
        Object proprietaire,
        params (string nom, Object valeur)[] references)
    {
        if (proprietaire == null)
        {
            return false;
        }

        bool referencesValides = true;

        foreach ((string nom, Object valeur) reference in references)
        {
            if (reference.valeur != null)
            {
                continue;
            }

            Debug.LogError(
                $"{proprietaire.GetType().Name} '{proprietaire.name}' : " +
                $"la référence SerializeField '{reference.nom}' n'est pas assignée dans l'Inspector.",
                proprietaire);

            referencesValides = false;
        }

        return referencesValides;
    }
}
