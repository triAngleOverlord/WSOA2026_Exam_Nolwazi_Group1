using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public GameObject player;
    public GameObject playerScreen;
    public GameObject playerCamera;
    [SerializeField] public GameObject interactCue;
    [SerializeField] public GameObject congoPuzzle;
    [SerializeField] public GameObject nigeriaPuzzle;
    [SerializeField] public GameObject collectedPanel;

    public List<string> congoSequence = new List<string>(); 

    public string[] congoFamilyTreeSequence;
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(playerScreen);
        DontDestroyOnLoad(playerCamera);

        interactCue = Resources.Load<GameObject>("PressToInteract");
        congoPuzzle.gameObject.SetActive(false);
        nigeriaPuzzle.gameObject.SetActive(false);
        collectedPanel.gameObject.SetActive(false);

        congoSequence.Add("Grandma"); congoSequence.Add("Motema"); congoSequence.Add("Bondeko"); congoSequence.Add("Boboto"); congoSequence.Add("Elombe"); 
        congoSequence.Add("Lisanga"); congoSequence.Add("Kitoko"); congoSequence.Add("Ntuni"); congoSequence.Add("Nazebi");
    }


    // Update is called once per frame
    void Update()
    {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.sortingOrder = (int)(renderer.transform.position.y * -100) +10;
        }
        
    }

    public void checkCongoSequence(List<string> maskSubmitted, TextAsset inkJSON)
    {
        if (congoSequence.Count != 0)
        {
            //bool correct = true;

            for (int i = 0; i < congoSequence.Count; i++)
            {
                if (congoSequence[i] != maskSubmitted[i])
                {
                    Debug.Log(i.ToString() + congoSequence[i] + "," + maskSubmitted[i]);
                    return;
                }
            }
            
            Debug.Log("You are correct!");

            DialogueManager.instance.NPC = gameObject;
            DialogueManager.instance.enterDialogueMode(inkJSON);
            congoPuzzle.SetActive(false);
        }
    }

    public void pauseEnemyMovement()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in allEnemies)
        {
            enemy.transform.GetComponent<EnemyAI>().pause();
        }
    }
    public void resumeEnemyMovement()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in allEnemies)
        {
            enemy.transform.GetComponent<EnemyAI>().resume();
        }
    }

    public void escapePanel(GameObject thing)
    {
        thing.SetActive(false);
        PlayerScript.canMove = true;
        // PlayerScript.player.interact = true;
    }
}
