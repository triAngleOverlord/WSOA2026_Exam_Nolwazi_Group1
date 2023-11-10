using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testThings : MonoBehaviour
{
    // Start is called before the first frame update
    private bool testI;
    private void Start()
    {
        Debug.Log(name + " I am opening the nigerian puzzle");
    }

    // Update is called once per frame
    private void Update()
    {
        if (testI == true && Input.GetKey(KeyCode.E))
        {
            Debug.Log("I did a thing");
            GameManager.Instance.nigeriaPuzzle.gameObject.SetActive(true);
            testI = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision !=null && collision.CompareTag("Player"))
        {
            Debug.Log(name + " have found the player");
            GetComponent<SpriteRenderer>().color = Color.red;
            testI = true;
        }
    }
}
