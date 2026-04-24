/**
 * @file
 *  ExitButton.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  24/04/2026
 * @brief
 *  Exits the application when touched
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButton : MonoBehaviour, IPointerClickHandler
{
    /**
    * @brief Called when touching or clicking the UI button
    */
    public void OnPointerClick(PointerEventData eventData)
    {
        UnityEngine.Application.Quit();
    }
}