using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Dano : MonoBehaviour
{
    public GameObject BoneAtaque;
    public GameObject Jogador;
    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Jogador.GetComponent<Health>().vidapublica -= 1;
        }
    }

    void Ataque()
    {
        BoneAtaque.GetComponent<Collider>().enabled = true;
        StartCoroutine(VoltaNormal());

    }
    IEnumerator VoltaNormal()
    {

        yield return new WaitForSeconds(1);

        BoneAtaque.GetComponent<Collider>().enabled = false;
    }
}
