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

/// ScriptableObject asset that defines a full level spawn sequence.
[CreateAssetMenu(fileName = "NewSpawnSequence", menuName = "Levels/Spawn Sequence")]
public class SpawnSequence : ScriptableObject
{
    public string levelName = "Level 1";

    public List<SpawnEntry> entries = new List<SpawnEntry>();
}

/// Represents a single spawn event: which prefab to spawn,
/// how long to wait before spawning it, and an optional position offset.
[System.Serializable]
public class SpawnEntry
{
    public GameObject prefab;

    public float delayBefore = 1f;

    public Vector3 positionOffset = Vector3.zero;
}