using UnityEngine;

<<<<<<< Updated upstream
//Code taken from https://youtu.be/eSH9mzcMRqw?si=EpW8_CilTtFi_I89
[CreateAssetMenu(fileName = "NPCDialogue", menuName = "Scriptable Objects/NPCDialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;
=======
//Code adapted from https://youtu.be/eSH9mzcMRqw?si=EpW8_CilTtFi_I89
[CreateAssetMenu(fileName = "NPCDialogue", menuName = "Scriptable Objects/NPCDialogue")]
public class NPCDialogue : ScriptableObject
{
    [TextAreaAttribute]
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public bool[] endDialogueLines; //Mark where dialogue ends

    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
    //public AudioClip voiceSound;
    //public float voicePitch = 1f;

    public DialogueDisplay[] displayInfos;

    public DialogueChoice[] choices;
}

[System.Serializable]
public class DialogueDisplay
{
    public int dialogueIndex; //Dialogue line that the name and portrait are assigned to
    public string displayName; //Which character name is being displayed
    public Sprite displayPortrait; //Which portrait is being displayed
}

[System.Serializable]
public class DialogueChoice
{
    public int dialogueIndex; //Dialogue line where choices appear
    public string[] choices; //Player response option
    public int[] nextDialogueIndexes; //Where choice leads
>>>>>>> Stashed changes
}
