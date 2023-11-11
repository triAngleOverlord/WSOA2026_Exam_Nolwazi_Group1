using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerScript player;

    public GameObject playerCamera;
    public GameObject pCameraPOS;
    //public bool interact;
    public bool openJournal;
    public GameObject journal;

    public float speed;
    public static bool canMove;
    
    void Start()
    {
        journal.SetActive(false);
        openJournal = true;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerCamera.transform.position = pCameraPOS.transform.position;

        if (openJournal == true && Input.GetKeyDown(KeyCode.J))
        {
            if (journal.activeSelf == false)
            {
                Debug.Log("I opened the journal");
                journal.SetActive(true);
            }
            else if (journal.activeSelf == true)
            {
                Debug.Log("I closed the journal");
                journal.SetActive(false);
            }

        }

    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }
        }
        
    }

}
