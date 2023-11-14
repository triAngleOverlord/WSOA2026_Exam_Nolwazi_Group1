using UnityEngine;

public class intoHouse : MonoBehaviour
{
    [SerializeField] private GameObject nextPos;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && (collision.CompareTag("Player") || collision.CompareTag("Safiya")))
        {
            collision.transform.position = nextPos.transform.position;
        }

    }
}
