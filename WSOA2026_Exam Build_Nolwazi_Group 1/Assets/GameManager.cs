using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public GameObject player;
    public GameObject playerScreen;
    public GameObject playerCamera;
    [SerializeField] public GameObject interactCue;

    public List<string> congoSequence = new List<string>(); 

    public string[] congoFamilyTreeSequence;
    void Awake()
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

        congoSequence.Add("Mask"); congoSequence.Add("Mask (1)");
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

    public void checkCongoSequence(List<string> maskSubmitted)
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
}
