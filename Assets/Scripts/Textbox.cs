using UnityEngine;

public class ShowTextOnTrigger : MonoBehaviour
{
    public GameObject NewMission; 

    void Start()
    {
        if (NewMission != null)
        {
            NewMission.SetActive(false); 
        }
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
}