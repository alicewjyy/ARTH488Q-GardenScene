using UnityEngine;

public class mission_prompt : MonoBehaviour
{
    public GameObject missionPanel;
    public GameObject interactPrompt;

    private bool playerInRange = false;




    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactPrompt.SetActive(false);
    
    }

    // Update is called once per frame
    void Update()
    {
        interactPrompt.SetActive(playerInRange);

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            missionPanel.SetActive(!missionPanel.activeSelf);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            missionPanel.SetActive(false);
        }
    }
}
