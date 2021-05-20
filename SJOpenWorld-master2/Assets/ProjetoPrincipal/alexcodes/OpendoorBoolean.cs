using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpendoorBoolean : MonoBehaviour
{
    public bool Chave0 = false;
    public bool Chave1 = false;
    public bool Chave2 = false;
   
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroi", 1);
        if (PlayerPrefs.HasKey("Chave_0"))
        {
            if (PlayerPrefs.GetInt("Chave_0") == 1)
            {
                Chave0 = true;
            }
            else
            {
                Chave0 = false;
            }

        }
        if (PlayerPrefs.HasKey("Chave_1"))
        {
            if (PlayerPrefs.GetInt("Chave_1") == 1)
            {
                Chave1 = true;
            }
            else
            {
                Chave1 = false;
            }

        }

        if (PlayerPrefs.HasKey("Chave_2"))
        {
            if (PlayerPrefs.GetInt("Chave_2") == 1)
            {
                Chave2 = true;
            }
            else
            {
                Chave2 = false;
            }

        }
    }

    private void Update()
    {
       
    }
    // Update is called once per frame
    public void Destroi()
    {
        if (Chave0 == true && Chave1 == true && Chave2 == true)
        {
            Destroy(gameObject);
        }
    }
}
