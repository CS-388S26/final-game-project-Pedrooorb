/**
 * @file
 *  SpawnSequence.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  24/04/2026
 * @brief
 *  Serializes level sequences into editor
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
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