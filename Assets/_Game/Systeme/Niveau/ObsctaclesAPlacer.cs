using UnityEngine;

[System.Serializable]
public class ObsctaclesAPlacer
{
    public GameObject obstacleGameObject;

    [Min(0)]
    public int nombreAPlacer = 1;
}