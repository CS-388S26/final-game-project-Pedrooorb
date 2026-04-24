/**
 * @file
 *  MainMenu.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  24/04/2026
 * @brief
 *  Controls the buttons for main menu
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour, IPointerClickHandler
{
    public GameObject startButton;
    public GameObject exitButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerClick == startButton)
            SceneManager.LoadScene("Game");
        else if (eventData.pointerClick == exitButton)
            Application.Quit();
    }
}