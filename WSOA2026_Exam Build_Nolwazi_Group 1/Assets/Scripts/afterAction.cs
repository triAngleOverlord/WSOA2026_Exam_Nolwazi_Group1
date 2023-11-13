using UnityEngine;

public class afterAction : MonoBehaviour
{
    [SerializeField] npc WhichNPC;
    public enum npc
    { 
        egyptChild, SafiyaOne
    }

    public void actionToDo()
    {
        DialogueManager.instance.exitDialogueMode();
        switch(WhichNPC)
        {
            case npc.egyptChild:GameObject.Find("Safiya").transform.position = transform.position;
                Destroy(transform.parent.gameObject); 
                break;
                case npc.SafiyaOne:
                break;
        }
    }

}
