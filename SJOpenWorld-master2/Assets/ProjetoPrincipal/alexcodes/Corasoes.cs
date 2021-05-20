using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corasoes : MonoBehaviour
{
    public GameObject[] Corasao;
    public Queue<GameObject> Corasaocopia = new Queue<GameObject>();
    public static Corasoes corasao;
    //public Renderer g;

    // Start is called before the first frame update
    void Start()
    {
        //g = GetComponent<Renderer>();
        corasao = this;
        foreach(GameObject S in Corasao)
        {
            Corasaocopia.Enqueue(S);
            //gameObject.GetComponent<Renderer>().enabled = true;
            S.gameObject.SetActive(true); 
            //Eu tentei fazer isso funcionar por Sprite mas n consegui
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reduzircorasao()
    {
        GameObject S = Corasaocopia.Dequeue();
        S.gameObject.SetActive(false);
        Corasaocopia.Enqueue(S);
    }
}
