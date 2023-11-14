using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    [Header("Load Globals Ink File")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    [Header("Current NPC")]
    public GameObject NPC;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private float typingSpeed;
    [SerializeField] private GameObject givingImage;
    [SerializeField] private TextMeshProUGUI narrativeText;
    [Header("Left")]
    [SerializeField] private GameObject oneSprite;
    [SerializeField] private TextMeshProUGUI oneDialogue;
    [SerializeField] private TextMeshProUGUI oneName;
    [SerializeField] private Animator oneAnimator;
    [Header("Right")]
    [SerializeField] private GameObject twoSprite;
    [SerializeField] private TextMeshProUGUI twoDialogue;
    [SerializeField] private TextMeshProUGUI twoName;
    [SerializeField] private Animator twoAnimator;
    

    private Story currentStory;
    private bool dialogueIsPlaying;
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine= true;
    private Animator currentAnim;
    private DialogueVariables dialogueVariables;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    [SerializeField] private GameObject continueBTN;

    private const string SPEAKER_TAG = "speaker";
    private const string POTRAIT_TAG = "potrait";
    private const string PORTRAIT_TAG = "portrait";
    private const string GIVE_TAG = "give";
    private const string ACTION_TAG = "action";


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
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
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

        dialogueVariables.StartListening(currentStory);
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
                oneDialogue.transform.parent.gameObject.SetActive(false);
                twoDialogue.transform.parent.gameObject.SetActive(false);
                givingImage.gameObject.SetActive(false);
                narrativeText.transform.parent.gameObject.SetActive(false);

                //Debug.Log(currentDialogue.name);
                for (int i = 0; i < choices.Length; i++) 
                {
                    choices[i].gameObject.SetActive(false);
                }
                continueBTN.SetActive(false);
                //displayChoices();
                string placeHolder = currentStory.Continue();
                //Debug.Log(placeHolder);
                if(currentStory.currentTags.Count !=0)
                    handleTags(currentStory.currentTags, placeHolder);
                else
                {
                    oneSprite.gameObject.SetActive(false);
                    twoSprite.gameObject.SetActive(false);
                    narrativeText.transform.parent.gameObject.SetActive(true);
                    if (displayLineCoroutine != null)
                    {
                        StopCoroutine(displayLineCoroutine);
                    }
                    displayLineCoroutine = StartCoroutine(displayLine(narrativeText, placeHolder));
                    displayChoices();
                }

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
            //Debug.Log(tag);
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag is incorrect: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            
            switch(tagKey)
            {
                case SPEAKER_TAG: //Debug.Log("speaker= " + tagValue);
                    string tempValue = tagValue.Substring(0, 1);
                    if (tempValue == "1")
                    {
                        oneDialogue.transform.parent.gameObject.SetActive(true);
                        //nolwaziDialogue.text = tempText;
                        if (displayLineCoroutine != null)
                        {
                            StopCoroutine(displayLineCoroutine);
                        }
                        displayLineCoroutine = StartCoroutine(displayLine(oneDialogue, tempText));
                        oneName.text = tagValue.Substring(1,tagValue.Length-1);
                        currentAnim = oneAnimator;
                        oneSprite.gameObject.SetActive(true);
                    }
                    else
                    {
                        twoDialogue.transform.parent.gameObject.SetActive(true);
                        //npcDialogue.text = tempText;
                        if (displayLineCoroutine != null)
                        {
                            StopCoroutine(displayLineCoroutine);
                        }
                        displayLineCoroutine = StartCoroutine(displayLine(twoDialogue, tempText));
                        twoName.text = tagValue.Substring(1, tagValue.Length-1); 
                        currentAnim = twoAnimator;
                        twoSprite.gameObject.SetActive(true);
                    }
                    break;
                case PORTRAIT_TAG:
                    //oneSprite.gameObject.SetActive(true);
                    //twoSprite.gameObject.SetActive(true);
                    
                        currentAnim.Play(tagValue);
                   
                    break;
                case POTRAIT_TAG: currentAnim.Play(tagValue); break;
                case GIVE_TAG:
                    givingImage.gameObject.SetActive(true);
                    givingImage.transform.GetComponent<Image>().sprite= Resources.Load<Sprite>("GivenObjects/" + tagValue);
                    GameObject player = GameObject.FindWithTag("Player");
                    AddToJournal pCopy = player.AddComponent<AddToJournal>();
                    pCopy.materialName = tagValue + "_J";
                    break;

                case ACTION_TAG:NPC.transform.GetComponent<afterAction>().actionToDo();
                    break;
            }
            
        }
    }

    public void exitDialogueMode()
    {
        dialogueVariables.StopListening(currentStory);
        GameManager.Instance.resumeEnemyMovement();
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        twoDialogue.text = "";
        PlayerScript.canMove = true;
    }

    private void displayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count != 0)
        {
            oneDialogue.transform.parent.gameObject.SetActive(false);
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
        //Debug.Log(canContinueToNextLine);
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
