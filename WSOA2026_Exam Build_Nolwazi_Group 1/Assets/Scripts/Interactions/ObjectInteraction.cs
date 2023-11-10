using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private GameObject EtoInteract;
    private Transform WorldScreen;
    private GameObject instanText;
    private bool objectI;
    private void Start()
    {
        //Debug.Log(interactionType + " for "+transform.parent.name);
        WorldScreen = GameObject.Find("WorldScreen").transform;
        EtoInteract = GameManager.Instance.interactCue.gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (objectI == true && Input.GetKey(KeyCode.E))
        {
            Debug.Log("I interacted with " + transform.parent.name);
            //Debug.Log("Player found something");
            GameObject player = GameObject.FindWithTag("Player");
            //Debug.Log("Player picked up " + transform.name + "_J");
            AddToJournal pCopy = player.AddComponent<AddToJournal>();
            pCopy.materialName = transform.name + "_J";
            objectI = false;
            PlayerScript.canMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Found");
            instanText = Instantiate(EtoInteract, transform.parent.position, Quaternion.identity, WorldScreen);
            objectI = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(instanText);
        objectI = false;
    }

}
