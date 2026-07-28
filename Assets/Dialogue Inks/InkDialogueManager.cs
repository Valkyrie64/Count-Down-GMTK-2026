using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
//using Ink.UnityIntegration;
using NUnit.Framework;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    [Header("Count Animations")]
    [SerializeField] private Animator countAnimator;
    private float animTimer;

    [Header("Audio")]
    [SerializeField] private AudioSource typeSource;
    [SerializeField] private AudioSource clickSource;
    [SerializeField] private AudioClip[] audioClip;
    
    [Header("External Objects")]
    [SerializeField] private GameObject[] roomArrows;
    public GameObject clickedRoomArrow;
    private RoomChangeScript roomChangeScript;
    [SerializeField] private TextAsset loadGlobalsJSON;
    private DialogueVariables dialogueVariables;
    public int timeRemaining;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private Canvas playerCanvas;
    public bool endgameStarted;

    private Story currentStory;

    public bool dialogueIsPlaying;
    private Coroutine typeSentenceCoroutine;
    private DefaultInputActions inputActions;
    private InputAction mouseClickAction;
    private GameObject currentItem;
    [SerializeField] private TextAsset initialDialogue;


    void Awake()
    {
        endgameStarted = false;
        inputActions = new DefaultInputActions();
        mouseClickAction = inputActions.UI.Click;
        mouseClickAction.Enable();
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
        timeRemaining = 150;
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
        
        EnterDialogue(initialDialogue, null);
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

        /*if (timeRemaining <= 0)
        {
            StartEndGame();
        }*/
    }

    void FixedUpdate()
    {
        animTimer += Time.deltaTime;
    }

    void LateUpdate()
    {
        if (animTimer > 0.5f)
        {
            countAnimator.SetBool("Happy", false);
            countAnimator.SetBool("Sad", false);
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
        currentStory.BindExternalFunction("countValueChange", (float dialogueCountValue) => {UpdateCountValue(dialogueCountValue); currentItem = GameObject.FindGameObjectWithTag("SavedItem");
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

        if (countAnimator.GetBool("Win"))
        {
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }

        if (countAnimator.GetBool("Lose"))
        {
            SceneManager.LoadScene(sceneBuildIndex: 3);
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
            case "BioBook":
                Instantiate(dialoguePrefabs[0], playerCanvas.transform);
                break;
            case "CMeat":
                Instantiate(dialoguePrefabs[1], playerCanvas.transform);
                break;
            case "Code":
                Instantiate(dialoguePrefabs[2], playerCanvas.transform);
                break;
            case "Cushion":
                Instantiate(dialoguePrefabs[3], playerCanvas.transform);
                break;
            case "Egg":
                Instantiate(dialoguePrefabs[4], playerCanvas.transform);
                break;
            case "FanFiction":
                Instantiate(dialoguePrefabs[5], playerCanvas.transform);
                break;
            case "HFBottle":
                Instantiate(dialoguePrefabs[6], playerCanvas.transform);
                break;
            case "Letter":
                Instantiate(dialoguePrefabs[7], playerCanvas.transform);
                break;
            case "Lettuce":
                Instantiate(dialoguePrefabs[8], playerCanvas.transform);
                break;
            case "Meat":
                Instantiate(dialoguePrefabs[9], playerCanvas.transform);
                break;
            case "Mirror":
                Instantiate(dialoguePrefabs[10], playerCanvas.transform);
                break;
            case "Pasta":
                Instantiate(dialoguePrefabs[11], playerCanvas.transform);
                break;
            case "PhilBook":
                Instantiate(dialoguePrefabs[12], playerCanvas.transform);
                break;
            case "Phone":
                Instantiate(dialoguePrefabs[13], playerCanvas.transform);
                break;
            case "Poster":
                Instantiate(dialoguePrefabs[14], playerCanvas.transform);
                break;
            case "Key":
                Instantiate(dialoguePrefabs[15], playerCanvas.transform);
                break;
            case "Stake":
                Instantiate(dialoguePrefabs[16], playerCanvas.transform);
                break;
            case "Turtle":
                Instantiate(dialoguePrefabs[17], playerCanvas.transform);
                break;
            case "Wine":
                Instantiate(dialoguePrefabs[18], playerCanvas.transform);
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

    private void UpdateCountValue(float value)
    {
        var previousCountValue = countValue;
        countValue += value;
        if (previousCountValue < countValue)
        {
            //Happy Animation
            animTimer = 0;
            countAnimator.SetBool("Happy", true);
            Debug.Log("Happy!!");
        }

        if (previousCountValue > countValue)
        {
            //Sad Animation
            animTimer = 0;
            countAnimator.SetBool("Sad", true);
            Debug.Log("Sad!!");
        }
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
    

    public void StartEndGame()
    {
        var endGameDialogue = gameObject.GetComponent<InkDialogueTrigger>();
        endGameDialogue.ItemInteract();
    }

    private void GameWon(bool win)
    {
        if (win)
        {
            countAnimator.SetBool("Win", true);
        }
        else
        {
            countAnimator.SetBool("Lose", true);
        }
    }
}
