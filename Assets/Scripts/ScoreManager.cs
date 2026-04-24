/**
 * @file
 *  ScoreManager.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  24/04/2026
 * @brief
 *  Manages the score system also updating the text
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int currentScore = 0;
    /**
    * @brief Called at beginning
    */
    void Start()
    {
        UpdateText();
    }
    /**
    * @brief Resets the score
    */
    public void ResetScore()
    {
        currentScore = 0;
        UpdateText();
    }
    /**
    * @brief Adds to the score
    */
    public void AddToScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateText();
    }
    /**
    * @brief Subtracts to the score
    */
    public void SubToScore(int scoreToSub)
    {
        currentScore -= scoreToSub;
        UpdateText();
    }
    /**
    * @brief Gettor for the score
    */
    public int GetScore()
    {
        return currentScore;
    }
    /**
    * @brief Updates the current text from UI
    */
    private void UpdateText()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}