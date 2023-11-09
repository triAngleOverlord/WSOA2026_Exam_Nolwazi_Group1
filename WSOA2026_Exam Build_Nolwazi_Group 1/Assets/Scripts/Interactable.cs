using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject EtoInteract;
    private Transform WorldScreen;
    private GameObject instanText;
    private PlayerScript player;

    [SerializeField] public TextAsset inkJSON;

    public interactType interactionType;
    public enum interactType
    {
        collectable, NPC, puzzle
    }

    void Start()
    {
        WorldScreen = GameObject.Find("WorldScreen").transform;
        player = GameObject.Find("Nolwazi").transform.GetComponent<PlayerScript>();

        EtoInteract = GameManager.Instance.interactCue.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.interact == true && Input.GetKey(KeyCode.E))
        {
            DialogueManager.instance.enterDialogueMode(inkJSON);
            Debug.Log("I interacted with this");
            player.interact = false;
            PlayerScript.canMove = false;
        }
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

    public void NPCinteraction()
    {

    }
    public void collectObjectInteraction()
    {

    }
    public void puzzleInteraction()
    {

    }
}
