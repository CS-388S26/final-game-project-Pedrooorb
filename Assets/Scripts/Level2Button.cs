/**
 * @file
 *  Level2Button.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  24/04/2026
 * @brief
 *  Starts level 2 when touched
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class Level2Button : MonoBehaviour, IPointerClickHandler
{
    public GameManager gameManager;
    /**
    * @brief Called on touch
    */
    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.LoadLevel2();
    }
}