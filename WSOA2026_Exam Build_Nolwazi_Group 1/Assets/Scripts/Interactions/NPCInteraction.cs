using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private GameObject EtoInteract;
    private Transform WorldScreen;
    private GameObject instanText;
    [SerializeField] private TextAsset inkJSON;
    private bool yesI;
    private void Start()
    {
        //Debug.Log(name);
        EtoInteract = GameManager.Instance.interactCue.gameObject;
        WorldScreen = GameObject.Find("WorldScreen").transform;
    }
    // Update is called once per frame
    private void Update()
    {
        if (yesI == true && Input.GetKey(KeyCode.E))
        {
            //Debug.Log("I interacted with " + name);
            NPCinteraction();
            yesI = false;
            PlayerScript.canMove = false;
            Destroy(instanText);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Found " + name);
            instanText = Instantiate(EtoInteract, new Vector3(transform.parent.position.x, transform.parent.position.y+0.4f, transform.parent.position.z), Quaternion.identity, WorldScreen);
            yesI = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(instanText);
        yesI = false;
    }
    private void NPCinteraction()
    {
        //Debug.Log("Player made a npcInteraction");
        DialogueManager.instance.NPC = gameObject;
        DialogueManager.instance.enterDialogueMode(inkJSON);
       
    }

}
