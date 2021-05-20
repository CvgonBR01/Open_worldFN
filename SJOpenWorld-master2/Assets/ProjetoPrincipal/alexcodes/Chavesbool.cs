using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chavesbool : MonoBehaviour
{
    public int Chave;
    public GameObject Porta;
    

    // Start is called before the first frame update
    void Start()
    {

            if (PlayerPrefs.GetInt("Chave_0") == 1)
            {
                if(gameObject.GetComponent<Chavesbool>().Chave == 0)
            {
                Destroy(gameObject);
            } 
            }
        if (PlayerPrefs.GetInt("Chave_1") == 1)
        {
            if (gameObject.GetComponent<Chavesbool>().Chave == 1)
            {
                Destroy(gameObject);
            }
        }
        if (PlayerPrefs.GetInt("Chave_2") == 1)
        {
            if (gameObject.GetComponent<Chavesbool>().Chave == 2)
            {
                Destroy(gameObject);
            }
        }

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider Key)
    {
        if (Key.gameObject.tag == "Player")
        {
            if (Chave == 0)
            {
                Porta.GetComponent<OpendoorBoolean>().Chave0 = true;
                Porta.GetComponent<OpendoorBoolean>().Destroi();
                PlayerPrefs.SetInt("Chave_0", 1);
                Debug.Log("" + PlayerPrefs.GetInt("Chave_0"));
                
                Destruir();
            }
            if (Chave == 1)
            {

                Porta.GetComponent<OpendoorBoolean>().Chave1 = true;
                Porta.GetComponent<OpendoorBoolean>().Destroi();
                PlayerPrefs.SetInt("Chave_1", 1);
                Destruir();
            }
            if (Chave == 2)
            {
                Porta.GetComponent<OpendoorBoolean>().Chave2 = true;
                Porta.GetComponent<OpendoorBoolean>().Destroi();
                PlayerPrefs.SetInt("Chave_2", 1);
                Destruir();
            }
            }
        }

        void Destruir()
        {
            Destroy(gameObject,0.1f);

        }
            /*if (Key.gameObject.tag == "chave0")
            {
                Chave0 = true;
                Destroy(GameObject.FindWithTag("chave0"));
                Debug.Log("0Adquirido");
            }  
            else if (Key.gameObject.tag == "chave1")
            {
                Chave1 = true;
                Destroy(GameObject.FindWithTag("chave1"));
                Debug.Log("1Adquirido");
            }
            else if (Key.gameObject.tag == "chave2")
            {
                Chave2 = true;
                Destroy(GameObject.FindWithTag("chave2"));
                Debug.Log("2Adquirido");
            }*/

        }

