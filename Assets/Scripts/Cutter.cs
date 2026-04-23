using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    Vector3 RandomAngle;
    public GameObject Knife;
    public GameObject explosionPrefab;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Slice")
        {
            if (Knife.GetComponent<KnifeController>().IsCutting)
            {
                col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                col.gameObject.GetComponent<Rigidbody>().AddTorque(-Vector3.up * 120f, ForceMode.Impulse);
                RandomAngle = new Vector3(UnityEngine.Random.Range(-0.5f, -0.7f), UnityEngine.Random.Range(0.1f, 0.2f), UnityEngine.Random.Range(-1.2f, 1.2f));

                col.gameObject.GetComponent<Rigidbody>().AddForce(RandomAngle * UnityEngine.Random.Range(50, 70), ForceMode.Impulse);
            }
            Destroy(col.gameObject, 4f);
            Destroy(col.gameObject.transform.parent.gameObject, 4f);
        }
        else if (col.gameObject.tag == "Bomb")
        {
            if (Knife.GetComponent<KnifeController>().IsCutting)
            {
                GameObject explosion = Instantiate(explosionPrefab, col.gameObject.transform.position, Quaternion.identity);
                Knife.GetComponent<KnifeController>().IsStunned = true;
                Destroy(col.gameObject);
                Destroy(explosion, 1f);
            }
            else
            {
                Destroy(col.gameObject, 4f);
            }
        }
    }
}
