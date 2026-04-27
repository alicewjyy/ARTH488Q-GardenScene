using TMPro;
using UnityEngine;
using System.Collections;
<<<<<<< Updated upstream
using UnityEngine.UI;
=======
using System.Collections.Generic;
using UnityEngine.UI;
using static UnityEditor.ArrayUtility;
>>>>>>> Stashed changes

//Code taken from https://youtu.be/eSH9mzcMRqw?si=2HETwK3n_VBdYruZ
public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;
<<<<<<< Updated upstream
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    public GameObject interactionIcon;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    public bool CanInteract()
    {
        return !isDialogueActive;
=======
    private DialogueController dialogueUI;
    public GameObject interactionIcon;
    public Transform npcOverworld;

    public Collider2D dialogueBarrier;
    
    private int dialogueIndex;
    private bool isTyping;
    public bool isDialogueActive;

    private bool hasTalked = false;


    private void Start()
    {
        dialogueUI = DialogueController.Instance;
    }


 
    public bool CanInteract()
    {
        return !isDialogueActive && !hasTalked;
>>>>>>> Stashed changes
    }

    public void Interact()
    {
        // If no dialogue data or the game is paused and no dialogue is active
        if(dialogueData == null || (PauseController.IsGamePaused && !isDialogueActive))
        {
<<<<<<< Updated upstream
=======
            Debug.Log($"Dialogue Index: {dialogueIndex}");

>>>>>>> Stashed changes
            return;
        }

        if (isDialogueActive)
        {
<<<<<<< Updated upstream
=======
            Debug.Log($"Dialogue Index: {dialogueIndex}");
>>>>>>> Stashed changes
            NextLine();
        }
        else
        {
<<<<<<< Updated upstream
=======
            Debug.Log($"Dialogue Index: {dialogueIndex}");
>>>>>>> Stashed changes
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

<<<<<<< Updated upstream
        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;

        dialoguePanel.SetActive(true);
        PauseController.SetPause(true);
        interactionIcon.SetActive(false);

        StartCoroutine(TypeLine());
=======
        foreach(DialogueDisplay dialogueDisplay in dialogueData.displayInfos)
        {
            Debug.Log(dialogueDisplay.dialogueIndex);

            if(dialogueDisplay.dialogueIndex == dialogueIndex)
            {
                dialogueUI.SetNPCInfo(dialogueDisplay.displayName, dialogueDisplay.displayPortrait);
            }
        }

        dialogueUI.ShowDialogueUI(true);

        PauseController.SetPause(true);
        interactionIcon.SetActive(false);

        DisplayCurrentLine();
>>>>>>> Stashed changes
    }

    void NextLine()
    {
<<<<<<< Updated upstream
=======
        //Clear Choices
        dialogueUI.ClearChoices();

>>>>>>> Stashed changes
        if (isTyping)
        {
            // Skip typing animation and show the full line
            StopAllCoroutines();
<<<<<<< Updated upstream
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else if (++dialogueIndex < dialogueData.dialogueLines.Length)
        {
           // If another line, type next line
           StartCoroutine(TypeLine()); 
        }
        else
=======
            dialogueUI.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }

        //Check endDialogueLines
        else if(dialogueData.endDialogueLines.Length > dialogueIndex && dialogueData.endDialogueLines[dialogueIndex])
        {
            EndDialogue();
            return;
        }

        else if (!isTyping && ++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            foreach(DialogueChoice dialogueChoice in dialogueData.choices)
            {
               if(dialogueChoice.dialogueIndex == dialogueIndex)
               {
                   DisplayChoices(dialogueChoice);
                   return;
               }
            }

           // If another line, type next line
           DisplayCurrentLine();
        }
        else if(!isTyping)
>>>>>>> Stashed changes
        {
            EndDialogue();
        }
    }
    
    IEnumerator TypeLine()
    {
        isTyping = true;
<<<<<<< Updated upstream
        dialogueText.SetText("");

        foreach(char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
=======
        dialogueUI.SetDialogueText("");

        foreach(char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueUI.SetDialogueText(dialogueUI.dialogueText.text += letter);
>>>>>>> Stashed changes
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        if(dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }

<<<<<<< Updated upstream
=======
    void DisplayChoices(DialogueChoice choice)
    {
        for(int i = 0; i < choice.choices.Length; i++)
        {
           int nextIndex = choice.nextDialogueIndexes[i];
           dialogueUI.CreateChoiceButton(choice.choices[i], () => ChooseOption(nextIndex));
        }
    }

    void ChooseOption(int nextIndex)
    {
        dialogueIndex = nextIndex;
        dialogueUI.ClearChoices();
        DisplayCurrentLine();
    }

    void DisplayCurrentLine()
    {
        StopAllCoroutines();

        //Updates UI to current character name and portrait
        foreach(DialogueDisplay dialogueDisplay in dialogueData.displayInfos)
        {
            if(dialogueDisplay.dialogueIndex == dialogueIndex)
            {
                dialogueUI.SetNPCInfo(dialogueDisplay.displayName, dialogueDisplay.displayPortrait);
            }
        }

        StartCoroutine(TypeLine());
    }

>>>>>>> Stashed changes
    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
<<<<<<< Updated upstream
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseController.SetPause(false);
=======
        dialogueUI.SetDialogueText("");
        dialogueUI.ShowDialogueUI(false);
        PauseController.SetPause(false);

        //Checks if player ended dialogue on the last line in the array, which is the end of the "correct" route
        if (dialogueIndex == (dialogueData.dialogueLines.Length - 1))
        {
            //Player has completed interaction
            hasTalked = true;

            //Allows player walk past the NPC
            if (dialogueBarrier != null)
            {
              dialogueBarrier.enabled = false;
            }
        }
        
>>>>>>> Stashed changes
    }
}
