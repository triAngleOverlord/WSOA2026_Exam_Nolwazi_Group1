using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemOK : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void playerPickedThisUp()
    {
        Debug.Log("Player picked up " + transform.name + "_J");
        AddToJournal pCopy= player.AddComponent<AddToJournal>();
        pCopy.materialName = transform.name+ "_J";
    }

    
}
