using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class afterAction : MonoBehaviour
{
    [SerializeField] npc WhichNPC;
    [SerializeField] GameObject pos;
    public bool SafiyaMove;
    public enum npc
    { 
        egyptChild, SafiyaOne
    }

    public void Start()
    {
        SafiyaMove = false;
        if (WhichNPC==npc.SafiyaOne)
        {
            transform.parent.transform.GetComponent<NavMeshAgent>().updateRotation = false;
            transform.parent.transform.GetComponent<NavMeshAgent>().updateUpAxis = false;
        }
    }

    public void actionToDo()
    {
        DialogueManager.instance.exitDialogueMode();
        switch(WhichNPC)
        {
            case npc.egyptChild:GameObject.Find("Safiya").transform.position = transform.parent.transform.position;
                Destroy(transform.parent.gameObject); 
                break;
                case npc.SafiyaOne: SafiyaMove = true;
                break;
        }
    }

    public void FixedUpdate()
    {
        if(SafiyaMove)
        {
            Debug.Log("is moving");
            

            if(transform.position== pos.transform.position)
                SafiyaMove=false;
        }
        if (WhichNPC == npc.SafiyaOne)
        {
            transform.parent.transform.GetComponent<NavMeshAgent>().SetDestination(pos.transform.position);
        }
    }

}
