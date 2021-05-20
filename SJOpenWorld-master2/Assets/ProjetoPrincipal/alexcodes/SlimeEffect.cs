using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEffect : MonoBehaviour
{
    public GameObject BoneAtaque;
    public GameObject Jogador;
    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 6);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Jogador.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            Jogador.GetComponent<TrdControl>().forcemove = 500;
            Jogador.GetComponent<TrdControl>().Lento = true;
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
