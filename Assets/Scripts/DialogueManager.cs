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
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, ItemData itemData)
    {
        itemName = itemData.itemName;
        itemCost = itemData.itemTimeCost;
        animator.SetBool("IsOpen", true);
        
        nameText.text = dialogue.name;
        sentences.Clear();

        if (nameText.text == "The Down Count")
        {
            var currentItem = GameObject.FindGameObjectWithTag("Item");
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
        var currentItem = GameObject.FindGameObjectWithTag("Item");
        Destroy(currentItem);
        switch (itemName)
        {
            case "Book":
                Instantiate(dialogueItems[0], canvas.transform);
                break;
            case "Meal":
                Instantiate(dialogueItems[1], canvas.transform);
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
        var currentItem = GameObject.FindGameObjectWithTag("Item");
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
