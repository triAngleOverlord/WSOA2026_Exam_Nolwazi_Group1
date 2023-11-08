using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject nolwaziSprite;
    [SerializeField] private GameObject npcSprite;
    [SerializeField] private TextMeshProUGUI nolwaziDialogue;
    [SerializeField] private TextMeshProUGUI npcDialogue;
    private TextMeshProUGUI currentDialogue= null;
    [SerializeField] private TextMeshProUGUI nolwaziName;
    [SerializeField] private TextMeshProUGUI npcName;

    private Story currentStory;
    private bool dialogueIsPlaying;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    [SerializeField] private GameObject continueBTN;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";


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
    }

    public void enterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        //currentStory.variablesState["choiceOne"] = false;
        dialogueIsPlaying=true;
        dialoguePanel.SetActive(true);
        GameManager.Instance.pauseEnemyMovement();
        continueStory();
    }

    public void continueStory()
    {
        
        if (currentStory.canContinue)
        {
            npcDialogue.text = currentStory.Continue();
            handleTags(currentStory.currentTags);
            Debug.Log(currentDialogue.name);
            
            
            
            displayChoices();
            
        }
        else
        {
            exitDialogueMode();
        }
    }

    private void handleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            Debug.Log(splitTag.Length);
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag is incorrect: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            switch(tagKey)
            {
                case SPEAKER_TAG: Debug.Log("speaker= " + tagValue);
                    if(tagValue == "Nolwazi")
                        currentDialogue = nolwaziDialogue;
                    else
                        currentDialogue = npcDialogue;
                    break;
                case PORTRAIT_TAG:Debug.Log("portrait= " + tagValue); 
                    break;
            }
            
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

        if (currentChoices.Count != 0)
        {
            continueBTN.SetActive(false);
            if (currentChoices.Count > choices.Length)//makes sure there is enough UI support
            {
                Debug.LogError("More choices were given then the UI can support. Number of choices given: " + currentChoices.Count);
            }

            int i = 0;
            foreach (Choice choice in currentChoices)
            {
                choices[i].gameObject.SetActive(true);
                choicesText[i].text = choice.text;
                //Debug.Log(choice.text);
                i++;
            }

            for (int j = i; j < choices.Length; j++)//hide unused UI support
            {
                choices[j].gameObject.SetActive(false);
            }

            StartCoroutine(SelectFirstChoice());
        }
        else 
        { 
            foreach (GameObject btnChoices in choices)
            {
                btnChoices.SetActive(false);
            }
            continueBTN.SetActive(true);
        }
        
    }

    private IEnumerator SelectFirstChoice()
    {
        //event system handles disributing the action of the buttons after waiting 1 frame
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void makeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        continueStory();
    }
}
