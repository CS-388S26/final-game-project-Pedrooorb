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

    /**
    * @brief Called at the beginning
    */
    private void Start()
    {
        if (autoStart)
            StartSequence();
    }
    /**
    * @brief Starts or restarts the spawn sequence coroutine.
    */
    public void StartSequence()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);

        _spawnCoroutine = StartCoroutine(RunSequence());
    }
    /**
    * @brief Stops the spawn sequence mid-way if it is running.
    */
    public void StopSequence()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
    /**
    * @brief Coroutine that iterates through all entries in the SpawnSequence,
    *        waiting the specified delay before spawning each prefab.
    */
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
    /**
    * @brief Instantiates the prefab defined in the entry at the spawner's
    *        position plus any offset, preserving the prefab's original rotation.
    */
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