/**
 * @file
 *  StartButton.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  24/04/2026
 * @brief
 *  Starts the game when touched
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Game");
    }
}