using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    private GameObject EtoInteract;
    private Transform WorldScreen;
    private GameObject instanText;
    private bool objectI;
    [SerializeField] private string objectName;
    public bool important;

    public GameObject collectedPanel;
    private void Start()
    {
        WorldScreen = GameObject.Find("WorldScreen").transform;
        EtoInteract = GameManager.Instance.interactCue.gameObject;
        collectedPanel = GameManager.Instance.collectedPanel.gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (objectI == true && Input.GetKey(KeyCode.E))
        {
            //Debug.Log("I interacted with " + transform.parent.name);
            //Debug.Log("Player found something");
            GameObject player = GameObject.FindWithTag("Player");
            //Debug.Log("Player picked up " + transform.name + "_J");
            AddToJournal pCopy = player.AddComponent<AddToJournal>();
            pCopy.materialName = transform.name + "_J";
            objectI = false;
            PlayerScript.canMove = false;
            Destroy(instanText);

            collectedPanel.SetActive(true);
            GameObject.Find("ObjectImage").transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("GivenObjects/" + name);
            GameObject.Find("collectedTXT").transform.GetComponent<TextMeshProUGUI>().text = new string("You found a " + objectName + "! Be sure to check your journal");
            if (important==false) 
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Found");
            instanText = Instantiate(EtoInteract, new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z), Quaternion.identity, WorldScreen);
            objectI = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(instanText);
        objectI = false;
    }

}
