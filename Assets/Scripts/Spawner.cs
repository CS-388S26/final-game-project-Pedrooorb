/**
 * @file
 *  Spanwer.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  24/04/2026
 * @brief
 *  Spawns Movable Object in the desired position following the level sequence
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SpawnSequence spawnSequence;

    public bool autoStart = true;

    public bool loop = false;

    public event System.Action OnSequenceComplete;

    private Coroutine _spawnCoroutine;

    // ---------------------------------------------------------------

    private void Start()
    {
        if (autoStart)
            StartSequence();
    }

    public void StartSequence()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);

        _spawnCoroutine = StartCoroutine(RunSequence());
    }

    public void StopSequence()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }

    // ---------------------------------------------------------------

    private IEnumerator RunSequence()
    {
        if (spawnSequence == null)
        {
            yield break;
        }

        do
        {
            foreach (SpawnEntry entry in spawnSequence.entries)
            {
                // Wait the requested delay before spawning
                if (entry.delayBefore > 0f)
                    yield return new WaitForSeconds(entry.delayBefore);

                SpawnEntry(entry);
            }
        } while (loop);

        OnSequenceComplete?.Invoke();
        _spawnCoroutine = null;
    }

    private void SpawnEntry(SpawnEntry entry)
    {
        if (entry.prefab == null)
        {
            return;
        }

        Vector3 spawnPos = transform.position + entry.positionOffset;
        Quaternion spawnRot = entry.prefab.transform.rotation;

        Instantiate(entry.prefab, spawnPos, spawnRot);
    }
}