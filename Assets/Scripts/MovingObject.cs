using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
    }
}
