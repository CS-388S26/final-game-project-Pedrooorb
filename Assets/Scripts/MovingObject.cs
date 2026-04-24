/**
 * @file
 *  MovingObject.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  24/04/2026
 * @brief
 *  Moves objects at a desired speed in a direction
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 20f;
    /**
    * @brief Called every frame to move object
    */
    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
    }
}
