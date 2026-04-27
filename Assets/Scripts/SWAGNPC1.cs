using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Rendering;

//Code taken from https://youtu.be/eSH9mzcMRqw?si=2HETwK3n_VBdYruZ
public class SWAGNPC1 : MonoBehaviour, IInteractable
{
    public NPCDL dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;


    private int[] peacock_exp_1 = { 0, 1, 2, 2 };
    private int[] peacock_exp_2 = { 0, 0, 0, 2, 2, 0 };
    private int route = 1;

    private bool isProcessing = false;


    private int image_index = 0;
    private int exp_index = 0;


    private int dialogueIndex;
    private bool isTyping, isDialogueActive;


    void Start()
    {
        StartDialogue();
    }

    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
        // If no dialogue data or the game is paused and no dialogue is active
        if (dialogueData == null || (PauseController.IsGamePaused && !isDialogueActive))
        {
            return;
        }

        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        
        nameText.SetText(dialogueData.npcName[0]);
        portraitImage.sprite = dialogueData.npcPortrait2[0];

        dialoguePanel.SetActive(true);
        PauseController.SetPause(true);

        StartCoroutine(TypeLine());
    }



    void NextLine()
    {
       
         if (isProcessing) return;
        isProcessing = true;

        try
        {

            if (isTyping)
            {
                StopAllCoroutines();

                if (dialogueIndex >= 0 &&
                    dialogueIndex < dialogueData.dialogueLines.Length)
                {
                    dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
                }

                isTyping = false;
                isProcessing = false;
                return;
            }

            dialogueIndex++;

            if (dialogueIndex < 0 ||
                dialogueIndex >= dialogueData.dialogueLines.Length ||
                dialogueIndex >= dialogueData.order1.Length)
            {
                EndDialogue();
                isProcessing = false;
                return;
            }

            Debug.Log($"Dialogue Index: {dialogueIndex}");

            if (dialogueData.order1[dialogueIndex] == 1)
            {
                if (dialogueData.spriteExpOrder1.Length > 0)
                {
                    int spriteIndex = dialogueData.spriteExpOrder1[exp_index];

                    if (spriteIndex >= 0 &&
                        spriteIndex < dialogueData.npcPortrait1.Length)
                    {
                        portraitImage.sprite = dialogueData.npcPortrait1[spriteIndex];
                    }

                    exp_index++;
                }

                nameText.SetText(dialogueData.npcName[1]);
            }
            else
            {

                portraitImage.sprite = dialogueData.npcPortrait2[0];


                nameText.SetText(dialogueData.npcName[0]);
            }

            StartCoroutine(TypeLine());
        }
        finally
            {
                isProcessing = false;
            }
    }


    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseController.SetPause(false);
    }
}