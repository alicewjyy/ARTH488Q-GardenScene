using UnityEngine;

//Code taken from https://youtu.be/eSH9mzcMRqw?si=EpW8_CilTtFi_I89
//Code adapted from https://youtu.be/eSH9mzcMRqw?si=EpW8_CilTtFi_I89
[CreateAssetMenu(fileName = "NPCDialogue", menuName = "Scriptable Objects/NPCDialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    [TextAreaAttribute]
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public bool[] endDialogueLines; //Mark where dialogue ends

    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;
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
    public int dialogueIndex;
    public string[] choices; //Player response option
    public int[] nextDialogueIndexes; //Where choice leads
}

//Adam Code
/*using UnityEngine;

//Code taken from https://youtu.be/eSH9mzcMRqw?si=EpW8_CilTtFi_I89
[CreateAssetMenu(fileName = "NPCDialogue", menuName = "Scriptable Objects/NPCDialogue")]
public class NPCDialogue : ScriptableObject
{
    public string[] npcName;
    public Sprite[] npcPortrait1;
    public Sprite[] npcPortrait2;
    public int[] spriteExpOrder1;
    public int[] spriteExpOrder2;
    public string[] dialogueLines;
    public string[] otherLines;
    public int option;
    public int[] order1;
    public int[] order2;
    public bool[] autoProgressLines;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;

}*/