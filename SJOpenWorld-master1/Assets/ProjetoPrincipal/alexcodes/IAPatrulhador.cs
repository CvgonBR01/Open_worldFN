using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPatrulhador : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    public Transform[] moveSpots;

    private float waitTime;
    private int randomSpot;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
    }

    /*void OnCollisionStay(Collision col)
    {
        if (col.compareTag("player"))
         {
            Damage;
        }
    }
    */
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}