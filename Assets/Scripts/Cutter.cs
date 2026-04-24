using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    Vector3 RandomAngle;
    public GameObject Knife;
    public GameObject explosionPrefab;
    public GameObject ScoreManager;
    public GameManager gameManager;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Slice")
        {
            if (Knife.GetComponent<KnifeController>().IsCutting)
            {
                //handle rigidbody physics 
                col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                col.gameObject.GetComponent<Rigidbody>().AddTorque(-Vector3.up * 120f, ForceMode.Impulse);
                RandomAngle = new Vector3(UnityEngine.Random.Range(-0.5f, -0.7f), UnityEngine.Random.Range(0.1f, 0.2f), UnityEngine.Random.Range(-1.2f, 1.2f));

                col.gameObject.GetComponent<Rigidbody>().AddForce(RandomAngle * UnityEngine.Random.Range(50, 70), ForceMode.Impulse);

                //handle score
                ScoreManager.GetComponent<ScoreManager>().AddToScore(1);
            }
            Destroy(col.gameObject, 4f);
            Destroy(col.gameObject.transform.parent.gameObject, 4f);
        }
        else if (col.gameObject.tag == "Bomb")
        {
            if (Knife.GetComponent<KnifeController>().IsCutting)
            {
                //handle bomb behaviour
                GameObject explosion = Instantiate(explosionPrefab, col.gameObject.transform.position, Quaternion.identity);
                Knife.GetComponent<KnifeController>().IsStunned = true;
                Knife.GetComponent<KnifeController>()._currentShakeAmount = 0f;
                Destroy(col.gameObject);
                Destroy(explosion, 1f);

                //subtract pts
                ScoreManager.GetComponent<ScoreManager>().SubToScore(5);
            }
            else
            {
                Destroy(col.gameObject, 4f);
            }
        }
        else if (col.gameObject.tag == "Trophy")
        {
            //go to next level or end
            gameManager.EndLevel();

            Destroy(col.gameObject, 4f);
        }
    }
}
