/**
 * @file
 *  GameManager.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  24/04/2026
 * @brief
 *  Manages the level sequences and UI panels
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Spawner
    public Spawner spawner;
    public SpawnSequence level2Sequence;

    //UI
    public GameObject endLevelPanel;
    public TextMeshProUGUI finalScoreText;
    public GameObject level2Button;

    private int _currentLevel = 1;

    public ScoreManager scoreManager;

    /**
    * @brief Called at beginning
    */
    void Start()
    {
        endLevelPanel.SetActive(false);
    }
    /**
    * @brief Shows the final score and ends the level
    */
    public void EndLevel()
    {
        spawner.StopSequence();
        finalScoreText.text = "Final Score: " + scoreManager.GetScore();
        endLevelPanel.SetActive(true);
        level2Button.SetActive(_currentLevel < 2);
    }
    /**
    * @brief Loads 2 sequence
    */
    public void LoadLevel2()
    {
        _currentLevel = 2;
        endLevelPanel.SetActive(false);
        scoreManager.ResetScore();
        spawner.spawnSequence = level2Sequence;
        spawner.StartSequence();
    }
}