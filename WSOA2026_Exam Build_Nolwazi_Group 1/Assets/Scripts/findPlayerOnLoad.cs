using UnityEngine;

public class findPlayerOnLoad : MonoBehaviour
{
    private void Awake()
    {
           GameObject.Find("Nolwazi").transform.position = transform.position;
    }
}
