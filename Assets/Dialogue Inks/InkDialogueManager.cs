using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using Ink.UnityIntegration;
using NUnit.Framework;
using UnityEngine.InputSystem;

public class InkDialogueManager : MonoBehaviour
{
    [Header("Dialogue Panel")]
    //[SerializeField] private TextMeshProUGUI dialogueName;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Animator dialogueAnimator;
    [SerializeField] private Button continueButton;
    
    [Header("Choices")]
    [SerializeField] private GameObject[] choices;
    [SerializeField] private TextMeshProUGUI[] choicesText;

    [Header("Dialogue Item")]
    public string dialogueItemName;
    public int dialogueItemCost;
    [SerializeField] private GameObject clickedItem;
    [SerializeField] private GameObject lastClickedItem;
    [SerializeField] private GameObject[] dialoguePrefabs;
    
    [Header("Count Objects")]
    [SerializeField] private Slider countSlider;
    [SerializeField] private Image countRenderer;
    [SerializeField] private Sprite[] countSprites;
    public float countValue;
    
    [Header("Audio")]
    [SerializeField] private AudioSource typeSource;
    [SerializeField] private AudioSource clickSource;
    [SerializeField] private AudioClip[] audioClip;
    
    [Header("External Objects")]
    [SerializeField] private GameObject[] roomArrows;
    public GameObject clickedRoomArrow;
    private RoomChangeScript roomChangeScript;
    [SerializeField] private InkFile globalsInkFile;
    private DialogueVariables dialogueVariables;
    public int timeRemaining;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private Canvas playerCanvas;

    private Story currentStory;

    public bool dialogueIsPlaying;
    private Coroutine typeSentenceCoroutine;
    private DefaultInputActions inputActions;
    private InputAction mouseClickAction;
    private GameObject currentItem;


    void Awake()
    {
        inputActions = new DefaultInputActions();
        mouseClickAction = inputActions.UI.Click;
        mouseClickAction.Enable();
        dialogueVariables = new DialogueVariables(globalsInkFile.filePath);
        timeRemaining = 100;
        countValue = 20f;
    }

    void OnEnable()
    {
        mouseClickAction = inputActions.UI.Click;
        mouseClickAction.Enable();
    }
    void Start()
    {
        dialogueIsPlaying = false;
        dialogueAnimator.SetBool("IsOpen", false);
        
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    void Update()
    {
        timer.text = timeRemaining.ToString();
        countSlider.value = countValue;
        if (countValue > 100)
        {
            countValue = 100;
        }

        if (countValue < 0)
        {
            countValue = 0;
        }
        switch (countValue)
        {
            case < 25f:
                countRenderer.sprite = countSprites[0];
                break;
            case < 50f:
                countRenderer.sprite = countSprites[1];
                break;
            case < 75f:
                countRenderer.sprite = countSprites[2];
                break;
            case <= 100f:
                countRenderer.sprite = countSprites[3];
                break;
        }

        if (timeRemaining <= 0)
        {
            StartEndGame();
        }
    }

    public void EnterDialogue(TextAsset inkJSON, GameObject itemGO)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueAnimator.SetBool("IsOpen", true);
        clickedItem = itemGO;
        

        if (clickedRoomArrow != null)
        {
            
            roomChangeScript = clickedRoomArrow.GetComponent<RoomChangeScript>();
        }
        
        dialogueVariables.StartListening(currentStory);
        
        currentStory.BindExternalFunction("gainItem", (string itemName, int itemCost) => {dialogueItemName = itemName; dialogueItemCost = itemCost;
            SetItems(); });
        currentStory.BindExternalFunction("roomChange", () => {roomChangeScript.ChangeRoom();});
        currentStory.BindExternalFunction("countValueChange", (float dialogueCountValue) => {countValue += dialogueCountValue; currentItem = GameObject.FindGameObjectWithTag("SavedItem");
            Destroy(currentItem); Destroy(lastClickedItem); dialogueItemName = ""; dialogueItemCost = 0;});
        currentStory.BindExternalFunction("moodCheck", (bool win) => { GameWon(win);});

        foreach (GameObject roomArrow in roomArrows)
        {
            roomArrow.SetActive(false);
        }

        ContinueStory();
    }

    public void ContinueStory()
    {
        clickSource.clip = audioClip[1];
        clickSource.Play();
        if (currentStory.canContinue)
        {
            if (typeSentenceCoroutine != null)
            {
                StopCoroutine(typeSentenceCoroutine);
            }
            typeSentenceCoroutine = StartCoroutine(TypeSentence(currentStory.Continue()));
        }
        else
        {
            ExitDialogueMode();
        }
    }

    public void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialogueAnimator.SetBool("IsOpen", false);
        dialogueText.text = "";
        
        dialogueVariables.StopListening(currentStory);
        
        currentStory.UnbindExternalFunction("gainItem");
        currentStory.UnbindExternalFunction("roomChange");
        currentStory.UnbindExternalFunction("countValueChange");
        
        foreach (GameObject roomArrow in roomArrows)
        {
            roomArrow.SetActive(true);
        }
    }

    private void SetItems()
    {
        if (lastClickedItem != null)
        {
            lastClickedItem.SetActive(true);
        }
        lastClickedItem = clickedItem;
        clickedItem.SetActive(false);
        currentItem = GameObject.FindGameObjectWithTag("SavedItem");
        Destroy(currentItem);
        switch (dialogueItemName)
        {
            case "CMeat":
                Instantiate(dialoguePrefabs[0], playerCanvas.transform);
                break;
            case "Cushion":
                Instantiate(dialoguePrefabs[1], playerCanvas.transform);
                break;
            case "Egg":
                Instantiate(dialoguePrefabs[2], playerCanvas.transform);
                break;
            case "Letter":
                Instantiate(dialoguePrefabs[3], playerCanvas.transform);
                break;
            case "Lettuce":
                Instantiate(dialoguePrefabs[4], playerCanvas.transform);
                break;
            case "Meat":
                Instantiate(dialoguePrefabs[5], playerCanvas.transform);
                break;
            case "Mirror":
                Instantiate(dialoguePrefabs[6], playerCanvas.transform);
                break;
            case "Pasta":
                Instantiate(dialoguePrefabs[7], playerCanvas.transform);
                break;
            case "Stake":
                Instantiate(dialoguePrefabs[8], playerCanvas.transform);
                break;
            case "Poster":
                Instantiate(dialoguePrefabs[9], playerCanvas.transform);
                break;
            case "Turtle":
                Instantiate(dialoguePrefabs[10], playerCanvas.transform);
                break;
        }
    }

    public void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.Log("Too many choices");
        }

        if (currentChoices.Count > 0)
        {
            continueButton.gameObject.SetActive(false);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        continueButton.gameObject.SetActive(true);
        ContinueStory();
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        typeSource.clip = audioClip[0];
        HideChoices();
        continueButton.gameObject.SetActive(false);
        foreach (char letter in sentence.ToCharArray())
        {
            if (mouseClickAction.IsPressed())
            {
                dialogueText.text = sentence;
                break;
            }
            
            dialogueText.text += letter;
            typeSource.Play();
            yield return new WaitForSeconds(0.04f);
        }
        continueButton.gameObject.SetActive(true);
        DisplayChoices();
    }

    private void StartEndGame()
    {
        var endGameDialogue = gameObject.GetComponent<InkDialogueTrigger>();
        endGameDialogue.ItemInteract();
    }

    private void GameWon(bool win)
    {
        if (win)
        {
            Application.Quit();
        }
        else
        {
            Application.Quit();
        }
    }
}
