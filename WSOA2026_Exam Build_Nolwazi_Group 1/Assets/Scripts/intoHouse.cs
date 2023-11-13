using UnityEngine;

public class intoHouse : MonoBehaviour
{
    [SerializeField] private GameObject nextPos;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").transform.position = nextPos.transform.position;
        }

    }
}
