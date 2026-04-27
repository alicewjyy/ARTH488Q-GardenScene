using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using static UnityEditor.ArrayUtility;

//Code taken from https://youtu.be/eSH9mzcMRqw?si=2HETwK3n_VBdYruZ
public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;
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
    }

    public void Interact()
    {
        // If no dialogue data or the game is paused and no dialogue is active
        if (dialogueData == null || (PauseController.IsGamePaused && !isDialogueActive))
        {
            Debug.Log($"Dialogue Index: {dialogueIndex}");

            return;
        }

        if (isDialogueActive)
        {
            Debug.Log($"Dialogue Index: {dialogueIndex}");
            NextLine();
        }
        else
        {
            Debug.Log($"Dialogue Index: {dialogueIndex}");
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        foreach (DialogueDisplay dialogueDisplay in dialogueData.displayInfos)
        {
            Debug.Log(dialogueDisplay.dialogueIndex);

            if (dialogueDisplay.dialogueIndex == dialogueIndex)
            {
                dialogueUI.SetNPCInfo(dialogueDisplay.displayName, dialogueDisplay.displayPortrait);
            }
        }

        dialogueUI.ShowDialogueUI(true);

        PauseController.SetPause(true);
        interactionIcon.SetActive(false);

        DisplayCurrentLine();
    }

    void NextLine()
    {
        //Clear Choices
        dialogueUI.ClearChoices();

        if (isTyping)
        {
            // Skip typing animation and show the full line
            StopAllCoroutines();
            dialogueUI.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }

        //Check endDialogueLines
        else if (dialogueData.endDialogueLines.Length > dialogueIndex && dialogueData.endDialogueLines[dialogueIndex])
        {
            EndDialogue();
            return;
        }

        else if (!isTyping && ++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            foreach (DialogueChoice dialogueChoice in dialogueData.choices)
            {
                
                    DisplayChoices(dialogueChoice);
                    return;
                }
            

            // If another line, type next line
            DisplayCurrentLine();
        }
        else if (!isTyping)
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueUI.SetDialogueText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueUI.SetDialogueText(dialogueUI.dialogueText.text += letter);
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }

    void DisplayChoices(DialogueChoice choice)
    {
        for (int i = 0; i < choice.choices.Length; i++)
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
        foreach (DialogueDisplay dialogueDisplay in dialogueData.displayInfos)
        {
            if (dialogueDisplay.dialogueIndex == dialogueIndex)
            {
                dialogueUI.SetNPCInfo(dialogueDisplay.displayName, dialogueDisplay.displayPortrait);
            }
        }

        StartCoroutine(TypeLine());
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
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

    }
}
