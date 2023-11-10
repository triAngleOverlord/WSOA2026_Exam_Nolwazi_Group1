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
    //[SerializeField] private TextMeshProUGUI nolwaziName;
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private Animator nolwaziSpriteAnim;
    [SerializeField] private Animator npcSpriteAnim;
    [SerializeField] private float typingSpeed= 0.004f;

    private Story currentStory;
    private bool dialogueIsPlaying;
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine= true;

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
        if (canContinueToNextLine==true) //&& currentStory.currentChoices.Count==0)
        {
            if (currentStory.canContinue)
            {
                //currentStory.Continue();
                nolwaziDialogue.transform.parent.gameObject.SetActive(false);
                npcDialogue.transform.parent.gameObject.SetActive(true);
                string placeHolder = currentStory.Continue();
                handleTags(currentStory.currentTags, placeHolder);
                //Debug.Log(currentDialogue.name);
                for (int i = 0; i < choices.Length; i++) 
                {
                    choices[i].gameObject.SetActive(false);
                }
                continueBTN.SetActive(false);
                //displayChoices();
            }
            else
            {
                exitDialogueMode();
            }
        }
            
    }

    private void handleTags(List<string> currentTags, string tempText)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            //Debug.Log(splitTag.Length);
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag is incorrect: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            
            switch(tagKey)
            {
                case SPEAKER_TAG: //Debug.Log("speaker= " + tagValue);
                    if (tagValue == "Nolwazi")
                    {
                        nolwaziDialogue.transform.parent.gameObject.SetActive(true);
                        //nolwaziDialogue.text = tempText;
                        if (displayLineCoroutine != null)
                        {
                            StopCoroutine(displayLineCoroutine);
                        }
                        displayLineCoroutine = StartCoroutine(displayLine(nolwaziDialogue, tempText));
                    }
                    else
                    {
                        npcDialogue.transform.parent.gameObject.SetActive(true);
                        //npcDialogue.text = tempText;
                        if (displayLineCoroutine != null)
                        {
                            StopCoroutine(displayLineCoroutine);
                        }
                        displayLineCoroutine = StartCoroutine(displayLine(npcDialogue, tempText));
                        npcName.text = tagValue;
                    }
                    break;
                case PORTRAIT_TAG://Debug.Log("portrait= " + tagValue); 
                    string tempTag= tagValue;
                    tempTag= tempTag.Substring(0, 7);
                    Debug.Log(tempTag);
                    if(tempTag == "nolwazi")
                    {
                        nolwaziSpriteAnim.Play(tagValue);
                    }
                    else
                    {
                        npcSpriteAnim.Play(tagValue);
                    }
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
            nolwaziDialogue.transform.parent.gameObject.SetActive(false);
            //npcDialogue.transform.parent.gameObject.SetActive(true);
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

    private IEnumerator displayLine(TextMeshProUGUI dialogueCurry, string line)
    {
        dialogueCurry.text = "";
        canContinueToNextLine = false;
        foreach (char letter in line)
        {
            dialogueCurry.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        canContinueToNextLine = true;
        Debug.Log(canContinueToNextLine);
        displayChoices();
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
