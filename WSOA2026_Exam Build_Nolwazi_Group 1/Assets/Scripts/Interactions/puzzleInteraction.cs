using UnityEngine;

public class puzzleInteraction : MonoBehaviour
{
    private GameObject EtoInteract;
    private Transform WorldScreen;
    private GameObject instanText;
    private bool puzzleI;
    [SerializeField] private puzzleType type;
    [SerializeField] private GameObject worldpuzzlePanel;
    private enum puzzleType
    {
        congo, nigeria, tanzania, worldPuzzle
    }
    private void Start()
    {
        if (type == puzzleType.worldPuzzle)
            worldpuzzlePanel.SetActive(false);
        //Debug.Log(transform.parent.name);
        WorldScreen = GameObject.Find("WorldScreen").transform;
        EtoInteract = GameManager.Instance.interactCue.gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (puzzleI == true && Input.GetKey(KeyCode.E))
        {
            //Debug.Log("I interacted with " + name);
            switch(type)
            {
                case puzzleType.congo: congoPuzzleInteraction();
                    break;
                case puzzleType.nigeria: nigeriaPuzzleInteraction();
                    break;
                case puzzleType.tanzania: tanzaniaPuzzleInteraction();
                    break;
                case puzzleType.worldPuzzle: worldpuzzlePanel.SetActive(true);
                    break;
            }
            puzzleI = false;
            PlayerScript.canMove = false;
            Destroy(instanText);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            instanText = Instantiate(EtoInteract, transform.parent.position, Quaternion.identity, WorldScreen);
            puzzleI = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(instanText);
        puzzleI = false;
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
    private void tanzaniaPuzzleInteraction()
    {
        Debug.Log("Player opened tanzania puzzle");
    }

}
