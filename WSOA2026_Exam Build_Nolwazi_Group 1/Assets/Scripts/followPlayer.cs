using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private GameObject thePlayer;
    public void Awake()
    {
        thePlayer = GameObject.Find("Nolwazi");
    }
    public void Update()
    {
        transform.position = thePlayer.transform.position;
    }
}
