using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public GameObject takeButton;
    public GameObject leaveButton;
    public GameObject nextButton;
    public GameObject[] dialogueItems;
    public Canvas canvas;
    private bool coroutineRunning;
    private Queue<string> sentences;
    private string currentSentence;
    private string itemName;
    private int itemCost;
    private GameObject clickedItem;
    private GameObject lastClickedItem;
    [SerializeField] private GameObject[] roomArrows;
    
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, ItemData itemData)
    {

        foreach (GameObject roomArrow in roomArrows)
        {
            roomArrow.SetActive(false);
        }
        itemName = itemData.itemName;
        itemCost = itemData.itemTimeCost;
        clickedItem = itemData.itemGO;
        animator.SetBool("IsOpen", true);
        
        nameText.text = dialogue.name;
        sentences.Clear();
        
        var currentItem = GameObject.FindGameObjectWithTag("SavedItem");
        if (nameText.text == "The Down Count")
        {
            if (currentItem != null)
            {
                currentItem.GetComponent<Button>().interactable = true;
            }
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        currentSentence = sentences.Peek();
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (!nextButton)
        {
            nextButton.SetActive(true);
        }
        
        if (sentences.Count == 2 && itemName != "" && !coroutineRunning)
        {
            takeButton.SetActive(true);
            leaveButton.SetActive(true);
            nextButton.SetActive(false);
        }

        if (sentences.Count == 1 && itemName != "")
        {
            takeButton.SetActive(false);
            leaveButton.SetActive(false);
            nextButton.SetActive(true);
        }
        
        if (sentences.Count == 0 && !coroutineRunning)
        {
            EndDialogue();
            return;
        }
        
        if (coroutineRunning)
        {
            StopAllCoroutines();
            coroutineRunning = false;
            dialogueText.text = currentSentence;
            return;
        }
        
        if (coroutineRunning == false)
        {
            currentSentence = sentences.Peek();
            string sentence = sentences.Dequeue();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    public void TakeItem()
    {
        if (lastClickedItem != null)
        {
            lastClickedItem.SetActive(true);
        }
        lastClickedItem = clickedItem;
        clickedItem.SetActive(false);
        var currentItem = GameObject.FindGameObjectWithTag("SavedItem");
        Destroy(currentItem);
        switch (itemName)
        {
            case "Turtle":
                Instantiate(dialogueItems[0], canvas.transform);
                break;
            case "Cloth":
                Instantiate(dialogueItems[1], canvas.transform);
                break;
            case "Photo":
                Instantiate(dialogueItems[2], canvas.transform);
                break;
        }
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        coroutineRunning = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
        coroutineRunning = false;
    }

    

    public void EndDialogue()
    {
        foreach (GameObject roomArrow in roomArrows)
        {
            roomArrow.SetActive(true);
        }
        var currentItem = GameObject.FindGameObjectWithTag("SavedItem");
        if (currentItem != null)
        {
            currentItem.GetComponent<Button>().interactable = false;
        }
        animator.SetBool("IsOpen", false);
        takeButton.SetActive(false);
        leaveButton.SetActive(false);
        nextButton.SetActive(true);
    }
}
