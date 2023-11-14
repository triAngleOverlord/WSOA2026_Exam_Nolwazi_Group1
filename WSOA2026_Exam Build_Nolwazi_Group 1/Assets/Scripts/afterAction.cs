using UnityEngine;

public class afterAction : MonoBehaviour
{
    [SerializeField] npc WhichNPC;
    [SerializeField] GameObject pos;
    public enum npc
    { 
        egyptChild, SafiyaOne, endDoor, endFemi, nigeriaPuzzle, endCongo
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
            case npc.endDoor: GameObject.Find("anotherArea").GetComponent<goToNextArea>().canEnter = true;
                    break;
            case npc.endFemi: GameObject.Find("ENDEGYPT").transform.position = pos.transform.position;
                GameObject.FindWithTag("Player").transform.position = pos.transform.position;
                Destroy(GameObject.Find("Safiya")); Destroy(GameObject.Find("Edrice")); Destroy(gameObject);
                break;
                case npc.nigeriaPuzzle:GameManager.Instance.nigeriaPuzzle.SetActive(true); Debug.Log("Yes");
                break;
            case npc.endCongo: GameObject[] npcs = GameObject.FindGameObjectsWithTag("Safiya");
                foreach (GameObject n in  npcs)
                {
                    Destroy(n);
                }
                GameObject.Find("CongoEnd").transform.position= pos.transform.position;
                break;
        }
    }


}
