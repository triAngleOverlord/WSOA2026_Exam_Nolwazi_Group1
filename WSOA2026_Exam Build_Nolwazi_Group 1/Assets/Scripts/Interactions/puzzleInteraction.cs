using UnityEngine;

public class puzzleInteraction : MonoBehaviour
{
    private GameObject EtoInteract;
    private Transform WorldScreen;
    private GameObject instanText;
    private void Start()
    {
        Debug.Log(transform.parent.name);
        //Debug.Log(interactionType + " for "+transform.parent.name);
        WorldScreen = GameObject.Find("WorldScreen").transform;
        EtoInteract = GameManager.Instance.interactCue.gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (PlayerScript.interact == true && Input.GetKey(KeyCode.E))
        {
            Debug.Log("I interacted with " + transform.parent.name);
            congoPuzzleInteraction();
            PlayerScript.interact = false;
            PlayerScript.canMove = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Found" + transform.parent.name);
            instanText = Instantiate(EtoInteract, transform.parent.position, Quaternion.identity, WorldScreen);
            PlayerScript.interact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(instanText);
        PlayerScript.interact = false;
    }

    private void congoPuzzleInteraction()
    {
        Debug.Log("Player opened the congo puzzle");
        GameManager.Instance.congoPuzzle.SetActive(true);
    }
    private void nigeriaPuzzleInteraction()
    {
        Debug.Log("Player opened nigeria puzzle");
        GameManager.Instance.nigeriaPuzzle.SetActive(true);
    }
}
