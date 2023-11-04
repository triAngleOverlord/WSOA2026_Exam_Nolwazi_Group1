using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("PlayerBody"))
        {
            Debug.Log("Nolwazi spotted");
            transform.parent.transform.GetComponent<EnemyAI>().playerSpotted = true;
            transform.parent.transform.GetComponent<EnemyAI>().eTarget = collision.gameObject.transform.position;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBody"))
        {
            Debug.Log("Nolwazi is not spotted anymore");
            transform.parent.transform.GetComponent<EnemyAI>().eTarget = collision.gameObject.transform.position;
        }
    }
}
