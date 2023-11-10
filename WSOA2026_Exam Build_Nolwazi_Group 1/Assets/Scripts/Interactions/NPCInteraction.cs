using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject EtoInteract;
    private Transform WorldScreen;
    private GameObject instanText;
    [SerializeField] private TextAsset inkJSON;
    private void Start()
    {
        Debug.Log(transform.parent.name);
        EtoInteract = GameManager.Instance.interactCue.gameObject;
        WorldScreen = GameObject.Find("WorldScreen").transform;
        
    }
    // Update is called once per frame
    private void Update()
    {
        if (PlayerScript.interact == true && Input.GetKey(KeyCode.E))
        {
            Debug.Log("I interacted with " + transform.parent.name);
            NPCinteraction();
            PlayerScript.interact = false;
            PlayerScript.canMove = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Found " + transform.parent.name);
            instanText = Instantiate(EtoInteract, transform.parent.position, Quaternion.identity, WorldScreen);
            PlayerScript.interact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(instanText);
        PlayerScript.interact = false;
    }
    private void NPCinteraction()
    {
        Debug.Log("Player made a npcInteraction");
        DialogueManager.instance.enterDialogueMode(inkJSON);
    }

}
