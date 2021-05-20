using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 3, 0 * Time.deltaTime);
    }

     void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
