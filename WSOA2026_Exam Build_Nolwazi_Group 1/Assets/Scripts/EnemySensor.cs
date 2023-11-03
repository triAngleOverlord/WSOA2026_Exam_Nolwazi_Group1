using UnityEngine;

public class EnemySensor : MonoBehaviour
{

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("PlayerBody"))
        {
            //Debug.Log("Nolwazi spotted");
            transform.parent.transform.GetComponent<EnemyAI>().playerSpotted = true;
            transform.parent.transform.GetComponent<EnemyAI>().eTarget = collision.gameObject.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBody"))
        {
            //Debug.Log("Nolwazi is not spotted anymore");
            transform.parent.transform.GetComponent<EnemyAI>().eTarget = transform.parent.transform.GetComponent<EnemyAI>().patrolPoints[transform.parent.transform.GetComponent<EnemyAI>().targetPoint];
            //collision.gameObject.transform.position;
        }
    }
}
