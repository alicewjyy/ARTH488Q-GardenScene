using UnityEngine;

public class DialogueProgress : MonoBehaviour
{
    public static DialogueProgress Instance;

    public bool birdDialogueFinished = false;

    private void Awake()
    {
        Instance = this;
    }

    public void FinishBirdDialogue()
    {
        birdDialogueFinished = true;
    }
}