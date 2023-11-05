using Ink.Runtime;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject nolwaziSprite;
    [SerializeField] private GameObject npcSprite;
    [SerializeField] private TextMeshProUGUI nolwaziDialogue;
    [SerializeField] private TextMeshProUGUI npcDialogue;

    private Story currentStory;
    private bool dialogueIsPlaying;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

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

        choicesText = new TextMeshProUGUI[choices.Length];
        int i = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }
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
        currentStory.variablesState["choiceOne"] = false;
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

    private void displayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
    }
}
