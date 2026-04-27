using UnityEngine;

//Code taken from https://youtu.be/eSH9mzcMRqw?si=2HETwK3n_VBdYruZ
[CreateAssetMenu(fileName = "NPCDialogue", menuName = "Scriptable Objects/NPCDialogue")]
public class NPDCL : ScriptableObject
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

}