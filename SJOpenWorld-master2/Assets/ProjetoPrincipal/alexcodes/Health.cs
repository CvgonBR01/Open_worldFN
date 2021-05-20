using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static int vidas = 0;
    public int vidapublica;
    public bool PodeTomarDano = true; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidapublica = vidas;

        if (Input.GetKeyUp(KeyCode.P))
        {
            Corasoes.corasao.reduzircorasao();
        }
    }
    //att=attack
    public void OnTriggerEnter(Collider att)
    {
        if (!PodeTomarDano)
                    return;
        
        // vc já deve saber, mas o q está nas aspas é uma tag aleatória para o inimigo mude para o q quiser.
        if (att.CompareTag("Minion")) 
        {
            PodeTomarDano = false;
            Invoke("AtivarDano", 1);
            vidas -= 1;

            if(Corasoes.corasao != null)
            {
                Corasoes.corasao.reduzircorasao();
            }

            if (vidas <= 0)
            {// se o personagem tiver uma animação de morte acho q é para insiri-la aqui.
                Destroy(gameObject); 
            }

        }
    }
    void AtivarDano()
    {
        PodeTomarDano = true;
    }
}
