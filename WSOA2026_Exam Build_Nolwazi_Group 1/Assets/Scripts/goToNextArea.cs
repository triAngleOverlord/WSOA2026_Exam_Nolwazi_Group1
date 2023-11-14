using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToNextArea : MonoBehaviour
{
    public string sceneName;
    //public GameObject player;
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        //Interactable sc = gameObject.AddComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.CompareTag("Player"))
        {
            //player.transform.position = new Vector3(-11, 0, 0);
            SceneManager.LoadScene(sceneName);

        }
        
    }
}
