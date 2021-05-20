using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShrinePortal : MonoBehaviour
{
    public int levelToLoad;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {

            PlayerPrefs.DeleteAll();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

           SceneManager.LoadScene(levelToLoad);
        
        //StartCoroutine(MyLoadScene());
        }
    }

    private IEnumerator MyLoadScene()
    {
        Camera.main.SendMessage("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelToLoad);
    }
}
