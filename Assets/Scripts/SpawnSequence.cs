using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnSequence", menuName = "Levels/Spawn Sequence")]
public class SpawnSequence : ScriptableObject
{
    public string levelName = "Level 1";

    public List<SpawnEntry> entries = new List<SpawnEntry>();
}

[System.Serializable]
public class SpawnEntry
{
    public GameObject prefab;

    public float delayBefore = 1f;

    public Vector3 positionOffset = Vector3.zero;
}