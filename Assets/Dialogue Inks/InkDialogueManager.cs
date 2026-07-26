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


    void Awake()
    {
        inputActions = new DefaultInputActions();
        mouseClickAction = inputActions.UI.Click;
        mouseClickAction.Enable();
        dialogueVariables = new DialogueVariables(globalsInkFile.filePath);
        timeRemaining = 100;
        countValue = 0.1f;
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
        switch (countValue)
        {
            case < 0.25f:
                countRenderer.sprite = countSprites[0];
                break;
            case < 0.50f:
                countRenderer.sprite = countSprites[1];
                break;
            case < 0.75f:
                countRenderer.sprite = countSprites[2];
                break;
            case <= 1f:
                countRenderer.sprite = countSprites[3];
                break;
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
        currentStory.BindExternalFunction("roomChange", () => {roomChangeScript.ChangeRoom(); });

        foreach (GameObject roomArrow in roomArrows)
        {
            roomArrow.SetActive(false);
        }

        ContinueStory();
    }

    public void ContinueStory()
    {
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
        var currentItem = GameObject.FindGameObjectWithTag("SavedItem");
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
            yield return new WaitForSeconds(0.04f);
        }
        continueButton.gameObject.SetActive(true);
        DisplayChoices();
    }
}
