using UnityEngine;

public class ShowTextOnTrigger : MonoBehaviour
{
    public GameObject NewMission; 
    public GameObject NPC;

    void Start()
    {   
            NewMission.SetActive(false); 
            NPC.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)  
    {
        if (other.CompareTag("Player"))
        {
            NewMission.SetActive(true); 
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            NewMission.SetActive(false);
        }
    }

    public void OnYesClicked()
    {
        NewMission.SetActive(false);
        NPC.SetActive(true);
    }
}