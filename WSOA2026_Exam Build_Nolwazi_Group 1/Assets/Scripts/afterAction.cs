using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class afterAction : MonoBehaviour
{
    [SerializeField] npc WhichNPC;
    [SerializeField] GameObject pos;
    public enum npc
    { 
        egyptChild, SafiyaOne
    }

    public void Start()
    {
    }

    public void actionToDo()
    {
        DialogueManager.instance.exitDialogueMode();
        switch(WhichNPC)
        {
            case npc.egyptChild:GameObject.Find("Safiya").transform.position = transform.parent.transform.position;
                Destroy(transform.parent.gameObject); 
                break;
            case npc.SafiyaOne:transform.parent.transform.position = pos.transform.position;
                break;
        }
    }


}
