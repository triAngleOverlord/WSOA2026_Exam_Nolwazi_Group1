using UnityEngine;
using UnityEngine.SceneManagement;

public class goToNextArea : MonoBehaviour
{
    public string sceneName;
    public bool canEnter;
    //public GameObject player;
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        //Interactable sc = gameObject.AddComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(canEnter==true)
            if(collision != null && collision.CompareTag("Player"))
            {
                //player.transform.position = new Vector3(-11, 0, 0);
                SceneManager.LoadScene(sceneName);

            }
        
    }
}
