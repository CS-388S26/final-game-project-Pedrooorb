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

    void Start()
    {
        UpdateText();
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateText();
    }

    public void AddToScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateText();
    }

    public void SubToScore(int scoreToSub)
    {
        currentScore -= scoreToSub;
        UpdateText();
    }

    public int GetScore()
    {
        return currentScore;
    }

    private void UpdateText()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}