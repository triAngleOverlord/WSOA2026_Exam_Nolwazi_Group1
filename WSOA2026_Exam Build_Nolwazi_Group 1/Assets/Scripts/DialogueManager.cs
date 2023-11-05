using Ink.Runtime;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] public GameObject nolwaziSprite;
    [SerializeField] public GameObject npcSprite;
    [SerializeField] public TextMeshProUGUI nolwaziDialogue;
    [SerializeField] public TextMeshProUGUI npcDialogue;

    private Story currentStory;
    private bool dialogueIsPlaying;
    private PlayerScript player;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            continueStory();
        }
    }

    public void enterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying=true;
        dialoguePanel.SetActive(true);
        GameManager.Instance.pauseEnemyMovement();
        continueStory();
    }

    private void continueStory()
    {
        
        if (currentStory.canContinue)
        {
            npcDialogue.text = currentStory.Continue();
        }
        else
        {
            exitDialogueMode();
        }
    }

    private void exitDialogueMode()
    {
        GameManager.Instance.resumeEnemyMovement();
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        npcDialogue.text = "";
        PlayerScript.canMove = true;
    }
}
