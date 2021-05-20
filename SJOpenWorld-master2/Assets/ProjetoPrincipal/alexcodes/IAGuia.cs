using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAGuia : MonoBehaviour
{

    public Transform objective;//set objective to look
    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public float distancetotrigger = 5;


    void Start()
    {

    }

    void Update()
    {
        //gira para o objetivo
        if (Vector3.Distance(transform.position, target.transform.position) < distancetotrigger)
        {
            transform.LookAt(objective.position);
        }

    }
}
