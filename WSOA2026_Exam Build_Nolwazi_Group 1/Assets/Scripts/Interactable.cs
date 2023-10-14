using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EtoInteract;
    public Transform WorldScreen;
    public GameObject instanText;
    public PlayerScript player;
    void Start()
    {
        player = GameObject.Find("Nolwazi").transform.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Found");
            instanText= Instantiate(EtoInteract, transform.parent.position, Quaternion.identity, WorldScreen);
            player.interact = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(instanText);
        player.interact = false;
    }
}
