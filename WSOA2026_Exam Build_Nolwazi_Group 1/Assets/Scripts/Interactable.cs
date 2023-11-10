using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject EtoInteract;
    private Transform WorldScreen;
    private GameObject instanText;
    private PlayerScript player;
    
    [SerializeField] private TextAsset inkJSON;
    //[SerializeField] private GameObject panelToOpen;

    public interactType interactionType;
    public enum interactType
    {
        collectable, NPC, congoPuzzle, nigeriaPuzzle
    }

    void Start()
    {
        Debug.Log(interactionType + " for "+name);
        WorldScreen = GameObject.Find("WorldScreen").transform;
        player = GameObject.Find("Nolwazi").transform.GetComponent<PlayerScript>();

        EtoInteract = GameManager.Instance.interactCue.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.interact == true && Input.GetKey(KeyCode.E))
        {
            Debug.Log("I interacted with this");
            
            switch(this.interactionType)
            {
                case interactType.collectable:collectObjectInteraction();
                    break;
                case interactType.NPC: NPCinteraction();
                    break;
                case interactType.congoPuzzle: congoPuzzleInteraction();
                    break;
                case interactType.nigeriaPuzzle: nigeriaPuzzleInteraction();
                    break;
            }
            PlayerScript.interact = false;
            PlayerScript.canMove = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Found");
            instanText= Instantiate(EtoInteract, transform.parent.position, Quaternion.identity, WorldScreen);
            PlayerScript.interact = true;

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(instanText);
        PlayerScript.interact = false;
    }

    public void NPCinteraction()
    {
        Debug.Log("Player made a npcInteraction");
        DialogueManager.instance.enterDialogueMode(inkJSON);
    }
    public void collectObjectInteraction()
    {
        //Debug.Log("Player found something");
        GameObject player = GameObject.FindWithTag("Player");
        //Debug.Log("Player picked up " + transform.name + "_J");
        AddToJournal pCopy = player.AddComponent<AddToJournal>();
        pCopy.materialName = transform.name + "_J";
    }

    public void congoPuzzleInteraction()
    {
        Debug.Log("Player opened the congo puzzle");
        GameManager.Instance.congoPuzzle.SetActive(true);
    }
    public void nigeriaPuzzleInteraction()
    {
        Debug.Log("Player opened nigeria puzzle");
        GameManager.Instance.nigeriaPuzzle.SetActive(true);
    }
}
