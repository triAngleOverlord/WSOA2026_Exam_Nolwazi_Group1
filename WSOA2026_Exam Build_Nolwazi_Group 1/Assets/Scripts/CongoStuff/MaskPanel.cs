using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MaskPanel : MonoBehaviour, IDropHandler
{
    public Canvas playerScreen;
    public GameObject occupying;

    public void Awake()
    {
        playerScreen = GameObject.Find("PlayerScreen").GetComponent<Canvas>(); ;
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedMask = eventData.pointerDrag;

        if (occupying == null)
        {
            occupying = droppedMask;
            checkFamilyTree();
        }
        else if(occupying != droppedMask)
        {
            occupying.transform.SetParent(playerScreen.transform, true);
            occupying.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            occupying = droppedMask;
        }
        occupying.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        occupying.transform.SetParent(transform, true);
        occupying.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }

    public void checkFamilyTree()
    {
        GameObject[] allMaskSlots = GameObject.FindGameObjectsWithTag("MaskSlot"); 
        List<string> masksSubmitted = new List<string>();
        foreach (GameObject slot in allMaskSlots) 
        {
            if (slot.transform.GetComponent<MaskPanel>().occupying == null)
            {
                Debug.Log("There is nothing in a maskSlot");
                return;
            }
            else
            {
                masksSubmitted.Add(slot.transform.GetComponent<MaskPanel>().occupying.transform.name);
            }
            
        }
        GameManager.Instance.checkCongoSequence(masksSubmitted);
    }
}
